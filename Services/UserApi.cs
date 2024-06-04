using LearnBlazorV1.Types;
using System.Net.Http.Json;

namespace LearnBlazorV1.Services
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserType>> GetUsersAsync()
        {
            var users = await _httpClient.GetFromJsonAsync<IEnumerable<UserType>>("/api/users/");
            return users;
        }

        public async Task<UserType> GetUserDetailAsync(string id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserType>($"/api/users/{id}");
            return user;
        }

        public async Task<UserType> CreateNewUser(UserForm userForm)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", userForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserType>();
        }

        public async Task<UserType> UpdateUser(string id, UserForm userForm)
        {
            var response = await _httpClient.PutAsJsonAsync("api/users/" + id, userForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserType>();
        }

        public async Task<bool> DeleteUser(string id)
        {
            var response = await _httpClient.DeleteAsync("api/users/" + id);
            return response.IsSuccessStatusCode;
        }
    }
}
