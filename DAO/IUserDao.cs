using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IUserDao
    {
        Task<User> AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByIdAsync(string Id);
        IEnumerable<User> GetUsers();
        string Delete(string id);

    }
}
