using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface ISMPFormDao
    {
        Task<SMPForm> AddAsync(SMPForm data);
        Task<SMPForm> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SMPForm>> GetSMPFormsAsync(string userId);
        string Delete(string id);

    }
}