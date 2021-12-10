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
    public class SeizureMonitoringRecordDao : ISeizureMonitoringRecordDao
    {
        private readonly IMongoCollection<SeizureMonitoringRecord> _seizureMonitoringRecords;

        public SeizureMonitoringRecordDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _seizureMonitoringRecords = database.GetCollection<SeizureMonitoringRecord>("SeizureMonitoringRecord");
        }
        public async Task<IEnumerable<SeizureMonitoringRecord>> GetSeizureMonitoringRecordsAsync(string userId)
        {
            var dataResults = await _seizureMonitoringRecords.FindAsync(x => x.User.Id == userId);
            return dataResults.ToList();
        }

        public async Task<SeizureMonitoringRecord> GetByIdAsync(string userId, string Id)
        {
            return await _seizureMonitoringRecords.FindAsync(x => x.Id == Id && x.User.Id == userId).Result.FirstOrDefaultAsync();
        }


        public async Task<SeizureMonitoringRecord> AddAsync(SeizureMonitoringRecord seizureMonitoringRecord)
        {
            await _seizureMonitoringRecords.InsertOneAsync(seizureMonitoringRecord);
            return seizureMonitoringRecord;
        }

        public string Delete(string id)
        {
            _seizureMonitoringRecords.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
