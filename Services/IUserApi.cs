using LearnBlazorV1.Types;

namespace LearnBlazorV1.Services
{
    public interface IUserApi
    {
        Task<IEnumerable<UserType>> GetUsersAsync();

        Task<UserType> GetUserDetailAsync(string id);

        Task<UserType> CreateNewUser(UserForm user);

        Task<UserType> UpdateUser(string id, UserForm user);

        Task<bool> DeleteUser(string id);
    }
}
