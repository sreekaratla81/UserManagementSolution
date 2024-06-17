////using Microsoft.AspNetCore.Mvc.Testing;
////using System.Net.Http;
////using System.Text.Json;
////using System.Text;
////using System.Threading.Tasks;
////using UserManagement.Models;
////using Xunit;

////namespace UserManagement.API.Tests
////{
////    public class UsersControllerTests : IClassFixture<WebApplicationFactory<Program>>
////    {
////        private readonly HttpClient _client;

////        public UsersControllerTests(WebApplicationFactory<Program> factory)
////        {
////            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
////            {
////                BaseAddress = new Uri("http://localhost:44375")
////            });
////        }

////        [Fact]
////        public async Task CreateUser_ShouldReturnOk()
////        {
////            // Arrange
////            var user = new User { Id = "1", FirstName = "John", LastName = "Doe" };
////            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

////            // Act
////            var response = await _client.PostAsync("/api/users", content);

////            // Assert
////            response.EnsureSuccessStatusCode();
////        }

////        [Fact]
////        public async Task UpdateUser_ShouldReturnOk()
////        {
////            // Arrange: Ensure the user exists before updating
////            var initialUser = new User { Id = "1", FirstName = "Jane", LastName = "Doe" };
////            var initialContent = new StringContent(JsonSerializer.Serialize(initialUser), Encoding.UTF8, "application/json");
////            await _client.PostAsync("/api/users", initialContent);

////            // Arrange: Prepare the updated user details
////            var updatedUser = new User { Id = "1", FirstName = "John", LastName = "Doe" };
////            var updatedContent = new StringContent(JsonSerializer.Serialize(updatedUser), Encoding.UTF8, "application/json");

////            // Act
////            var response = await _client.PutAsync("/api/users/1", updatedContent);

////            // Assert
////            response.EnsureSuccessStatusCode();
////        }

////        [Fact]
////        public async Task DeactivateUser_ShouldReturnOk()
////        {
////            // Arrange: Ensure the user exists before deleting
////            var initialUser = new User { Id = "1", FirstName = "Jane", LastName = "Doe" };
////            var initialContent = new StringContent(JsonSerializer.Serialize(initialUser), Encoding.UTF8, "application/json");
////            await _client.PostAsync("/api/users", initialContent);

////            // Act: Attempt to delete the user
////            var response = await _client.DeleteAsync("/api/users/1");

////            // Assert
////            response.EnsureSuccessStatusCode();
////        }

////        [Fact]
////        public async Task GetAllUsers_ShouldReturnOk()
////        {
////            // Arrange: Ensure there are users in the database
////            var initialUser1 = new User { Id = "1", FirstName = "Jane", LastName = "Doe" };
////            var initialUser2 = new User { Id = "2", FirstName = "John", LastName = "Smith" };

////            var initialContent1 = new StringContent(JsonSerializer.Serialize(initialUser1), Encoding.UTF8, "application/json");
////            var initialContent2 = new StringContent(JsonSerializer.Serialize(initialUser2), Encoding.UTF8, "application/json");

////            await _client.PostAsync("/api/users", initialContent1);
////            await _client.PostAsync("/api/users", initialContent2);

////            // Act: Get all users
////            var response = await _client.GetAsync("/api/users");

////            // Assert
////            response.EnsureSuccessStatusCode();
////        }
////    }
////}
