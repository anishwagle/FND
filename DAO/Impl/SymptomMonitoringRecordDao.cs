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
    public class SymptomMonitoringRecordDao : ISymptomMonitoringRecordDao
    {
        private readonly IMongoCollection<SymptomMonitoringRecord> _symptomMonitoringRecords;

        public SymptomMonitoringRecordDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _symptomMonitoringRecords = database.GetCollection<SymptomMonitoringRecord>("SymptomMonitoringRecord");
        }
        public async Task<IEnumerable<SymptomMonitoringRecord>> GetSymptomMonitoringRecordsAsync(string userId)
        {
            var dataResults = await _symptomMonitoringRecords.FindAsync(x => x.User.Id == userId);
            return dataResults.ToList();
        }

        public async Task<SymptomMonitoringRecord> GetByIdAsync(string userId, string Id)
        {
            return await _symptomMonitoringRecords.FindAsync(x => x.Id == Id && x.User.Id == userId).Result.FirstOrDefaultAsync();
        }


        public async Task<SymptomMonitoringRecord> AddAsync(SymptomMonitoringRecord symptomMonitoringRecord)
        {
            await _symptomMonitoringRecords.InsertOneAsync(symptomMonitoringRecord);
            return symptomMonitoringRecord;
        }

        public string Delete(string id)
        {
            _symptomMonitoringRecords.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
