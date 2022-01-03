using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface ISeizureMonitoringRecordDao
    {
        Task<SeizureMonitoringRecord> AddAsync(SeizureMonitoringRecord seizureMonitoringRecord);
        Task<SeizureMonitoringRecord> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SeizureMonitoringRecord>> GetSeizureMonitoringRecordsAsync(string userId);
        string Delete(string id);

    }
}