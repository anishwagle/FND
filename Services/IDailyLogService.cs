using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IDailyLogService
    {
        Task<DailyLog> AddAsync(DailyLog dailyLog);
        Task<DailyLog> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<DailyLog>> GetDailyLogsAsync(string Id);
        void Delete(string id);

    }
}
