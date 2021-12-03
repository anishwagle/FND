using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface ISymptomMonitoringRecordDao
    {
        Task<SymptomMonitoringRecord> AddAsync(SymptomMonitoringRecord symptomMonitoringRecord);
        Task<SymptomMonitoringRecord> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SymptomMonitoringRecord>> GetSymptomMonitoringRecordsAsync(string Id);
        string Delete(string id);

    }
}