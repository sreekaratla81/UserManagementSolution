using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using UserManagement.Models;
using Xunit;

namespace UserManagement.Data.Tests
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _repository;

        public UserRepositoryTests()
        {
            // Use an in-memory LiteDB instance for testing
            var memoryStream = new MemoryStream();
            _repository = new UserRepository(":memory:"); // Use in-memory database
        }

        [Fact]
        public async Task AddUser_ShouldAddUser()
        {
            // Arrange
            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };

            // Act
            await _repository.AddUser(user);
            var createdUser = await _repository.GetUserById("1");

            // Assert
            Assert.NotNull(createdUser);
            Assert.Equal("John", createdUser.FirstName);
        }

        [Fact]
        public async Task UpdateUser_ShouldModifyUserDetails()
        {
            // Arrange
            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };
            await _repository.AddUser(user);
            user.FirstName = "Jane";

            // Act
            await _repository.UpdateUser(user);
            var updatedUser = await _repository.GetUserById("1");

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal("Jane", updatedUser.FirstName);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser()
        {
            // Arrange
            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };
            await _repository.AddUser(user);

            // Act
            var fetchedUser = await _repository.GetUserById("1");

            // Assert
            Assert.NotNull(fetchedUser);
            Assert.Equal("John", fetchedUser.FirstName);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var user1 = new User { Id = "1", FirstName = "John", LastName = "Doe" };
            var user2 = new User { Id = "2", FirstName = "Jane", LastName = "Doe" };
            await _repository.AddUser(user1);
            await _repository.AddUser(user2);

            // Act
            var users = await _repository.GetAllUsers();

            // Assert
            Assert.Equal(2, users.Count);
        }
    }
}
