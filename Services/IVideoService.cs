using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IVideoService
    {
        Task<Video> AddAsync(Video video);
        Task<Video> GetByUserAsync(string userId);
        Task<Video> GetByIdAsync(string Id);
        Task<IEnumerable<Video>> GetVideosAsync();
        string Delete(string id);

    }
}
