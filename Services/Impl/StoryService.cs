
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class StoryService : IStoryService
    {
        // private readonly IMapper _mapper;
        private readonly IStoryDao _context;
        public StoryService(
            IStoryDao storyDao)
        {
            _context = storyDao;
        }

        public async Task<IEnumerable<Story>> GetStorysAsync()
        {
            return await _context.GetStorysAsync();
        }

        public async Task<Story> GetByIdAsync( string id)
        {
            return await _context.GetByIdAsync(id);
        }
public async Task<IEnumerable<Story>> GetByUserAsync( string userId)
        {
            return await _context.GetByUserAsync(userId);
        }
        public async Task<Story> AddAsync(Story model)
        {

            Story response = await _context.AddAsync(model);

            return response;
        }

        public string Delete(string id)
        {
            _context.Delete(id);
            return "Deleted Successfully";
        }

    }
}