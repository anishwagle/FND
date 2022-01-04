
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class VideoService : IVideoService
    {
        // private readonly IMapper _mapper;
        private readonly IVideoDao _context;
        public VideoService(
            IVideoDao videoDao)
        {
            _context = videoDao;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            return await _context.GetVideosAsync();
        }

        public async Task<Video> GetByIdAsync( string id)
        {
            return await _context.GetByIdAsync(id);
        }
public async Task<Video> GetByUserAsync( string userId)
        {
            return await _context.GetByUserAsync(userId);
        }
        public async Task<Video> AddAsync(Video model)
        {

            Video response = await _context.AddAsync(model);

            return response;
        }

        public string Delete(string id)
        {
            _context.Delete(id);
            return "Deleted Successfully";
        }

    }
}