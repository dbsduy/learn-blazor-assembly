using LearnBlazorV1.Services;
using LearnBlazorV1.Types;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace LearnBlazorV1.Pages
{
    public partial class UserDetail : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IUserApi UserApi { get; set; }

        public UserForm UserForm = new UserForm();

        private UserType User;

        private bool isEdited = false;

        private bool isLoading = false;

        private bool isDeleteConfirm = false;

        protected override async Task OnInitializedAsync()
        {
            await FetchUserDetails();
        }

        private async Task FetchUserDetails()
        {
            isLoading = true;
            User = await UserApi.GetUserDetailAsync(Id);
            isLoading = false;
        }

        private void ToggleEditUser()
        {
            isEdited = !isEdited;
        }

        private void ToggleDeleteConfirm()
        {
            isDeleteConfirm = !isDeleteConfirm;
        }

        protected override void OnParametersSet()
        {
            UserForm = new UserForm
            {
                Name = User.Name,
                Email = User.Email,
                Age = User.Age
            };

        }

        private async Task UpdateUserAsync()
        {
            isLoading = true;
            var result = await UserApi.UpdateUser(User.Id, UserForm);
            if (!string.IsNullOrEmpty(result.Id))
            {
                await FetchUserDetails();
                ToggleEditUser();
            }
            isLoading = false;
        }
    }
}
