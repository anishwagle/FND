using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IStoryService
    {
        Task<Story> AddAsync(Story story);
        Task<Story> GetByUserAsync(string userId);
        Task<Story> GetByIdAsync(string Id);
        Task<IEnumerable<Story>> GetStorysAsync();
        string Delete(string id);

    }
}
