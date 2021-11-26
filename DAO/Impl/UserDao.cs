using FND.Helpers;
using FND.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FND.DAO.Impl
{
    public class UserDao : IUserDao
    {
        private readonly IMongoCollection<User> _users;

        public UserDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>("User");
        }
        public IEnumerable<User> GetUsers()
        {
            var dataResults = _users.Find(x => true).ToList();
            return dataResults;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _users.FindAsync(x => x.Email == email).Result.FirstOrDefaultAsync();
        }
        public async Task<User> GetByIdAsync(string Id)
        {
            return await _users.FindAsync(x => x.Id == Id).Result.FirstOrDefaultAsync();
        }


        public async Task<User> AddAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public string Delete(string id)
        {
            _users.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
