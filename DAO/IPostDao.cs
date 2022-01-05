using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IPostDao
    {
        Task<Post> AddAsync(Post post);
        Task<IEnumerable<Post>> GetByUserAsync(string userId);
        Task<Post> GetByIdAsync(string Id);
        Task<IEnumerable<Post>> GetPostsAsync();
        string Delete(string id);

    }
}
