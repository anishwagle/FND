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
    public class PostDao : IPostDao
    {
        private readonly IMongoCollection<Post> _posts;

        public PostDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _posts = database.GetCollection<Post>("Post");
        }
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var dataResults =await _posts.FindAsync(x => true);
            return dataResults.ToList();
        }
        public async Task<IEnumerable<Post>> GetByUserAsync(string userId)
        {
            var data = await _posts.FindAsync(x => x.User.Id == userId);
            return data.ToList();
        }
        public async Task<Post> GetByIdAsync(string Id)
        {
            var data = await _posts.FindAsync(x => x.Id == Id);
            return data.FirstOrDefault();
        }


        public async Task<Post> AddAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
            return post;
        }

        public string Delete(string id)
        {
            _posts.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
