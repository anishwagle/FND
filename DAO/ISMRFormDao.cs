using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface ISMRFormDao
    {
        Task<SMRForm> AddAsync(SMRForm data);
        Task<SMRForm> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SMRForm>> GetSMRFormsAsync(string userId);
        string Delete(string id);

    }
}