using LearnBlazorV1.Services;
using LearnBlazorV1.Types;
using Microsoft.AspNetCore.Components;

namespace LearnBlazorV1.Pages
{
    public partial class UserManager : ComponentBase
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUserApi UserApi { get; set; }

        private IEnumerable<UserType> Users = [];

        private UserFilter UserFilter = new UserFilter();

        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await FilterUserAsync();
        }

        protected async Task FilterUserAsync()
        {
            isLoading = true;
            Users = await UserApi.GetUsersAsync();
            Users = Users.Where(user =>
                (string.IsNullOrEmpty(UserFilter.Name) || user.Name.Contains(UserFilter.Name)) &&
                (string.IsNullOrEmpty(UserFilter.Email) || user.Email.Contains(UserFilter.Email)) &&
                (UserFilter.Age == 0 || user.Age == UserFilter.Age)
            ).ToList();
            isLoading = false;
        }

        protected void GoToDetails(string id)
        {
            NavigationManager.NavigateTo($"/user/{id}");
        }

        private bool isOpenAddUser = false;

        private void ToggleAddUser()
        {
            isOpenAddUser = !isOpenAddUser;
        }
    }
}

