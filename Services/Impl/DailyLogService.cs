
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;
using FND.DTO;

namespace FND.Services.Impl
{

    public class DailyLogService : IDailyLogService
    {
        // private readonly IMapper _mapper;
        private readonly IDailyLogDao _context;
        public DailyLogService(
            IDailyLogDao dailyLogDao)
        {
            _context = dailyLogDao;
        }

        public async Task<IEnumerable<DailyLog>> GetDailyLogsAsync(string userId)
        {
            return await _context.GetDailyLogsAsync(userId);
        }

        public async Task<DailyLog> GetByIdAsync(string userId, string id)
        {
            return await _context.GetByIdAsync(userId, id);
        }

        public async Task<DailyLog> AddAsync(DailyLog model)
        {
            DailyLog response = await _context.AddAsync(model);
            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}