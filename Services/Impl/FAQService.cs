
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class FAQService : IFAQService
    {
        // private readonly IMapper _mapper;
        private readonly IFAQDao _context;
        public FAQService(
            IFAQDao FAQDao)
        {
            _context = FAQDao;
        }

        public async Task<IEnumerable<FAQ>> GetFAQsAsync()
        {
            return await _context.GetFAQsAsync();
        }

        public async Task<FAQ> GetByIdAsync( string id)
        {
            return await _context.GetByIdAsync( id);
        }

        public async Task<FAQ> AddAsync(FAQ model)
        {

            FAQ response = await _context.AddAsync(model);

            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}