
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class SMRFormService : ISMRFormService
    {
        // private readonly IMapper _mapper;
        private readonly ISMRFormDao _context;
        public SMRFormService(
            ISMRFormDao sMRFormDao)
        {
            _context = sMRFormDao;
        }

        public async Task<IEnumerable<SMRForm>> GetSMRFormsAsync(string userId)
        {
            return await _context.GetSMRFormsAsync(userId);
        }

        public async Task<SMRForm> GetByIdAsync(string userId, string id)
        {
            return await _context.GetByIdAsync(userId, id);
        }

        public async Task<SMRForm> AddAsync(SMRForm model)
        {

            SMRForm response = await _context.AddAsync(model);

            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}