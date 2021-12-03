
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class SymptomMonitoringRecordService : ISymptomMonitoringRecordService
    {
        // private readonly IMapper _mapper;
        private readonly ISymptomMonitoringRecordDao _context;
        public SymptomMonitoringRecordService(
            ISymptomMonitoringRecordDao symptomMonitoringRecordDao)
        {
            _context = symptomMonitoringRecordDao;
        }

        public async Task<IEnumerable<SymptomMonitoringRecord>> GetSymptomMonitoringRecordsAsync(string userId)
        {
            return await _context.GetSymptomMonitoringRecordsAsync(userId);
        }

        public async Task<SymptomMonitoringRecord> GetByIdAsync(string userId, string id)
        {
            return await _context.GetByIdAsync(userId, id);
        }

        public async Task<SymptomMonitoringRecord> AddAsync(SymptomMonitoringRecord model)
        {

            SymptomMonitoringRecord response = await _context.AddAsync(model);

            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}