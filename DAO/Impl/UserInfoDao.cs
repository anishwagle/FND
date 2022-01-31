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
    public class UserInfoDao : IUserInfoDao
    {
        private readonly IMongoCollection<UserInfo> _context;

        public UserInfoDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _context = database.GetCollection<UserInfo>("UserInfo");
        }
  

        public async Task<UserInfo> GetByIdAsync(string userId)
        {
            return await _context.FindAsync(x => x.User.Id == userId).Result.FirstOrDefaultAsync();
        }


        public async Task<UserInfo> AddAsync(UserInfo data)
        {
            await _context.InsertOneAsync(data);
            return data;
        }

        public string Delete(string id)
        {
            _context.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
