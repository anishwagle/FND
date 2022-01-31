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
    public class SMPFormDao : ISMPFormDao
    {
        private readonly IMongoCollection<SMPForm> _context;

        public SMPFormDao(IOptions<AppSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _context = database.GetCollection<SMPForm>("SMPForm");
        }
        public async Task<IEnumerable<SMPForm>> GetSMPFormsAsync(string userId)
        {
            var dataResults = await _context.FindAsync(x => x.User.Id == userId);
            return dataResults.ToList();
        }

        public async Task<SMPForm> GetByIdAsync(string userId, string Id)
        {
            return await _context.FindAsync(x => x.Id == Id && x.User.Id == userId).Result.FirstOrDefaultAsync();
        }


        public async Task<SMPForm> AddAsync(SMPForm symptomMonitoringRecord)
        {
            await _context.InsertOneAsync(symptomMonitoringRecord);
            return symptomMonitoringRecord;
        }

        public string Delete(string id)
        {
            _context.FindOneAndDelete(x => x.Id == id);
            return "Deleted";
        }
    }
}
