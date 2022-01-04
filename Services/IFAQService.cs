using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IFAQService
    {
        Task<FAQ> AddAsync(FAQ FAQ);
        Task<FAQ> GetByIdAsync( string Id);
        Task<IEnumerable<FAQ>> GetFAQsAsync();
        void Delete(string id);

    }
}
