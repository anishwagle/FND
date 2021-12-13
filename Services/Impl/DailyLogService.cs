
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

        public async Task<DailyLog> AddAsync(DailyLogRequest model)
        {
            var data = await _context.GetByTypeAsync(model.User.Id, model.Type);
            if (data == null)
            {
                data = new DailyLog
                {
                    Type = model.Type,
                    User = model.User,
                    Logs = new List<Log>()
                };
                var log = new Log
                {
                    Time = model.Log.Time,
                    Rate = model.Log.Rate,
                    Field = model.Log.Field
                };

                data.Logs.Add(log);

                return await _context.AddAsync(data);
            }
            else
            {
                var log = new Log
                {
                    Time = model.Log.Time,
                    Rate = model.Log.Rate,
                    Field = model.Log.Field
                };

                data.Logs.Add(log);
                return await _context.UpdateAsync(data);
            }
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}