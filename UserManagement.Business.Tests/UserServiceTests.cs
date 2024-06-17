using Moq;
using UserManagement.Business;
using UserManagement.Data;
using UserManagement.Models;
using Xunit;

namespace UserManagement.Business.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepository.Object);
        }

        [Fact]
        public async Task CreateUser_ShouldAddUser()
        {
            // Arrange
            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };

            // Act
            await _userService.CreateUser(user);

            // Assert
            _mockRepository.Verify(r => r.AddUser(It.Is<User>(u => u.Id == "1")), Times.Once);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdateUser()
        {
            // Arrange
            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };

            // Act
            await _userService.UpdateUser(user);

            // Assert
            _mockRepository.Verify(r => r.UpdateUser(It.Is<User>(u => u.Id == "1")), Times.Once);
        }

        [Fact]
        public async Task DeactivateUser_ShouldDeactivateUser()
        {
            // Arrange
            var user = new User { Id = "1", IsActive = true };
            _mockRepository.Setup(r => r.GetUserById("1")).ReturnsAsync(user);

            // Act
            await _userService.DeactivateUser("1");

            // Assert
            _mockRepository.Verify(r => r.UpdateUser(It.Is<User>(u => u.Id == "1" && u.IsActive == false)), Times.Once);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnUsers()
        {
            // Arrange
            var users = new List<User> { new User { Id = "1", FirstName = "John" } };
            _mockRepository.Setup(r => r.GetAllUsers()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsers();

            // Assert
            Assert.Equal(users, result);
        }
    }
}
