
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class SMPFormService : ISMPFormService
    {
        // private readonly IMapper _mapper;
        private readonly ISMPFormDao _context;
        public SMPFormService(
            ISMPFormDao sMRFormDao)
        {
            _context = sMRFormDao;
        }

        public async Task<IEnumerable<SMPForm>> GetSMPFormsAsync(string userId)
        {
            return await _context.GetSMPFormsAsync(userId);
        }

        public async Task<SMPForm> GetByIdAsync(string userId, string id)
        {
            return await _context.GetByIdAsync(userId, id);
        }

        public async Task<SMPForm> AddAsync(SMPForm model)
        {

            SMPForm response = await _context.AddAsync(model);

            return response;
        }

        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}