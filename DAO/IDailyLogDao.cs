
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IDailyLogDao
    {
        Task<DailyLog> AddAsync(DailyLog dailyLog);
        Task<DailyLog> UpdateAsync(DailyLog dailyLog);
        Task<DailyLog> GetByIdAsync(string userId, string Id);
        Task<DailyLog> GetByTypeAsync(string userId, string type);
        Task<IEnumerable<DailyLog>> GetDailyLogsAsync(string Id);
        string Delete(string id);
    }
}