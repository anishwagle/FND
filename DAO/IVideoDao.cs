using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IVideoDao
    {
        Task<Video> AddAsync(Video video);
        Task<Video> GetByUserAsync(string userId);
        Task<Video> GetByIdAsync(string Id);
        Task<IEnumerable<Video>> GetVideosAsync();
        string Delete(string id);

    }
}
