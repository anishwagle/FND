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
    public class VideoDao : IVideoDao
    {
        private readonly IMongoCollection<Video> _videos;

        public VideoDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _videos = database.GetCollection<Video>("Video");
        }
        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            var dataResults =await _videos.FindAsync(x => true);
            return dataResults.ToList();
        }
        public async Task<IEnumerable<Video>> GetByUserAsync(string userId)
        {
             var dataResults = await _videos.FindAsync(x => x.User.Id == userId);
             return dataResults.ToList();
        }
        public async Task<Video> GetByIdAsync(string Id)
        {
           var dataResults = await _videos.FindAsync(x => x.Id == Id);
           return dataResults.FirstOrDefault();
        }


        public async Task<Video> AddAsync(Video video)
        {
            await _videos.InsertOneAsync(video);
            return video;
        }

        public string Delete(string id)
        {
            _videos.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
