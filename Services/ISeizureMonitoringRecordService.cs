using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface ISeizureMonitoringRecordService
    {
        Task<SeizureMonitoringRecord> AddAsync(SeizureMonitoringRecord seizureMonitoringRecord);
        Task<SeizureMonitoringRecord> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SeizureMonitoringRecord>> GetSeizureMonitoringRecordsAsync(string Id);
        void Delete(string id);

    }
}
