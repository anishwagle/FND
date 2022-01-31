using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IUserInfoDao
    {
        Task<UserInfo> AddAsync(UserInfo data);
        Task<UserInfo> GetByIdAsync(string userId);
        string Delete(string id);

    }
}