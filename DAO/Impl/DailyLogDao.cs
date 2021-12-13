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
    public class DailyLogDao : IDailyLogDao
    {
        private readonly IMongoCollection<DailyLog> _dailyLogs;

        public DailyLogDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _dailyLogs = database.GetCollection<DailyLog>("DailyLog");
        }
        public async Task<IEnumerable<DailyLog>> GetDailyLogsAsync(string userId)
        {
            var dataResults = await _dailyLogs.FindAsync(x => x.User.Id == userId);
            return dataResults.ToList();
        }

        public async Task<DailyLog> GetByIdAsync(string userId, string Id)
        {
            return await _dailyLogs.FindAsync(x => x.Id == Id && x.User.Id == userId).Result.FirstOrDefaultAsync();
        }
        public async Task<DailyLog> GetByTypeAsync(string userId, string type)
        {
            return await _dailyLogs.FindAsync(x => x.Type == type && x.User.Id == userId).Result.FirstOrDefaultAsync();
        }

        public async Task<DailyLog> AddAsync(DailyLog dailyLog)
        {
            await _dailyLogs.InsertOneAsync(dailyLog);
            return dailyLog;
        }
        public async Task<DailyLog> UpdateAsync(DailyLog dailyLog)
        {
            var filter = Builders<DailyLog>.Filter.Eq(s => s.Id, dailyLog.Id);
            await _dailyLogs.ReplaceOneAsync(filter, dailyLog);
            return dailyLog;
        }

        public string Delete(string id)
        {
            _dailyLogs.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
