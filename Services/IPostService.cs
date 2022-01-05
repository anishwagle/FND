using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IPostService
    {
        Task<Post> AddAsync(Post post);
        Task<IEnumerable<Post>> GetByUserAsync(string userId);
        Task<Post> GetByIdAsync(string Id);
        Task<IEnumerable<Post>> GetPostsAsync();
        string Delete(string id);

    }
}
