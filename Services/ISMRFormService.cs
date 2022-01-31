using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface ISMRFormService
    {
        Task<SMRForm> AddAsync(SMRForm data);
        Task<SMRForm> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SMRForm>> GetSMRFormsAsync(string Id);
        void Delete(string id);

    }
}
