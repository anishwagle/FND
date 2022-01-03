
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class PostService : IPostService
    {
        // private readonly IMapper _mapper;
        private readonly IPostDao _context;
        public PostService(
            IPostDao postDao)
        {
            _context = postDao;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.GetPostsAsync();
        }

        public async Task<Post> GetByIdAsync( string id)
        {
            return await _context.GetByIdAsync(id);
        }
public async Task<Post> GetByUserAsync( string userId)
        {
            return await _context.GetByUserAsync(userId);
        }
        public async Task<Post> AddAsync(Post model)
        {

            Post response = await _context.AddAsync(model);

            return response;
        }

        public string Delete(string id)
        {
            _context.Delete(id);
            return "Deleted Successfully";
        }

    }
}