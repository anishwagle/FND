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
    public class FAQDao : IFAQDao
    {
        private readonly IMongoCollection<FAQ> _FAQs;

        public FAQDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _FAQs = database.GetCollection<FAQ>("FAQ");
        }
        public async Task<IEnumerable<FAQ>> GetFAQsAsync()
        {

            var dataResults = await _FAQs.FindAsync(x=>true);
            return dataResults.ToList();
        }

        public async Task<FAQ> GetByIdAsync( string Id)
        {
            return await _FAQs.FindAsync(x => x.Id == Id).Result.FirstOrDefaultAsync();
        }


        public async Task<FAQ> AddAsync(FAQ FAQ)
        {
            await _FAQs.InsertOneAsync(FAQ);
            return FAQ;
        }

        public string Delete(string id)
        {
            _FAQs.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
