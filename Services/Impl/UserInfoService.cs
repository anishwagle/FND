
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;

namespace FND.Services.Impl
{

    public class UserInfoService : IUserInfoService
    {
        // private readonly IMapper _mapper;
        private readonly IUserInfoDao _context;
        public UserInfoService(
            IUserInfoDao userInfoDao)
        {
            _context = userInfoDao;
        }



        public async Task<UserInfo> GetByIdAsync(string userId)
        {
            return await _context.GetByIdAsync(userId);
        }

        public async Task<UserInfo> SaveAsync(UserInfo model)
        {
            var response = new UserInfo();
            if(String.IsNullOrEmpty( model.Id))
                 response = await _context.AddAsync(model);
            else
                response = await _context.UpdateAsync(model);

            return response;
        }


        public void Delete(string id)
        {
            _context.Delete(id);
        }

    }
}