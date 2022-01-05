using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IStoryDao
    {
        Task<Story> AddAsync(Story story);
        Task<IEnumerable<Story>> GetByUserAsync(string userId);
        Task<Story> GetByIdAsync(string Id);
        Task<IEnumerable<Story>> GetStorysAsync();
        string Delete(string id);

    }
}
