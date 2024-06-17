// UserService.cs
using UserManagement.Data;
using UserManagement.Models;
using System.Threading.Tasks;

namespace UserManagement.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task DeactivateUser(string userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false;
                await _userRepository.UpdateUser(user);
            }
        }

        public async Task<List<User>> GetAllUsers() 
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
