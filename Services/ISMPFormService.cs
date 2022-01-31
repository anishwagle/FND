using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface ISMPFormService
    {
        Task<SMPForm> AddAsync(SMPForm data);
        Task<SMPForm> GetByIdAsync(string userId, string Id);
        Task<IEnumerable<SMPForm>> GetSMPFormsAsync(string Id);
        void Delete(string id);

    }
}
