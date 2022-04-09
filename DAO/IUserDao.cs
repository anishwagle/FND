using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IUserDao
    {
        Task<User> AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(string Id);
        IEnumerable<User> GetUsers();
        Task<User> UpdateAsync(User user);
        string Delete(string id);

    }
}
