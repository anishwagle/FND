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
    public class StoryDao : IStoryDao
    {
        private readonly IMongoCollection<Story> _storys;

        public StoryDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _storys = database.GetCollection<Story>("Story");
        }
        public async Task<IEnumerable<Story>> GetStorysAsync()
        {
            var dataResults =await _storys.FindAsync(x => true);
            return dataResults;
        }
        public async Task<Story> GetByUserAsync(string userId)
        {
            return await _storys.FindAsync(x => x.User.Id == userId);
        }
        public async Task<Story> GetByIdAsync(string Id)
        {
            return await _storys.FindAsync(x => x.Id == Id).Result.FirstOrDefault();
        }


        public async Task<Story> AddAsync(Story story)
        {
            await _storys.InsertOneAsync(story);
            return story;
        }

        public string Delete(string id)
        {
            _storys.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
