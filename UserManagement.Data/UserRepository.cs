using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using UserManagement.Models;

namespace UserManagement.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<User> _users;

        public UserRepository(string databasePath = "Users.db")
        {
            _database = new LiteDatabase(databasePath);
            _users = _database.GetCollection<User>("users");
        }

        public Task AddUser(User user)
        {
            _users.Insert(user);
            return Task.CompletedTask;
        }

        public Task UpdateUser(User user)
        {
            _users.Update(user);
            return Task.CompletedTask;
        }

        public Task<User> GetUserById(string userId)
        {
            var user = _users.FindById(userId);
            return Task.FromResult(user);
        }

        public async Task<List<User>> GetAllUsers() // Implement the new method
        {
            var users = _database.GetCollection<User>("users");
            return users.FindAll().ToList();
        }
    }
}
