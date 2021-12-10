
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class SeizureMonitoringRecordService : ISeizureMonitoringRecordService
    {
        // private readonly IMapper _mapper;
        private readonly ISeizureMonitoringRecordDao _context;
        public SeizureMonitoringRecordService(
            ISeizureMonitoringRecordDao seizureMonitoringRecordDao)
        {
            _context = seizureMonitoringRecordDao;
        }

        public async Task<IEnumerable<SeizureMonitoringRecord>> GetSeizureMonitoringRecordsAsync(string userId)
        {
            return await _context.GetSeizureMonitoringRecordsAsync(userId);
        }

        public async Task<SeizureMonitoringRecord> GetByIdAsync(string userId, string id)
        {
            return await _context.GetByIdAsync(userId, id);
        }

        public async Task<SeizureMonitoringRecord> AddAsync(SeizureMonitoringRecord model)
        {

            SeizureMonitoringRecord response = await _context.AddAsync(model);

            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}