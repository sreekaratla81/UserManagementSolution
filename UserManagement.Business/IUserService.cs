using UserManagement.Models;

namespace UserManagement.Business
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeactivateUser(string userId);
        Task<List<User>> GetAllUsers();
    }
}
