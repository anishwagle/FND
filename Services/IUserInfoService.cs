using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IUserInfoService
    {
        Task<UserInfo> AddAsync(UserInfo data);
        Task<UserInfo> UpdateAsync(UserInfo data);
        Task<UserInfo> GetByIdAsync(string userId);
        void Delete(string id);

    }
}
