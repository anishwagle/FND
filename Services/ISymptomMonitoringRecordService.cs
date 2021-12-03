using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface ISymptomMonitoringRecordService
    {
        Task<SymptomMonitoringRecord> AddAsync(SymptomMonitoringRecord symptomMonitoringRecord);
        Task<SymptomMonitoringRecord> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SymptomMonitoringRecord>> GetSymptomMonitoringRecordsAsync(string Id);
        void Delete(string id);

    }
}
