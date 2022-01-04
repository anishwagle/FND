using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FND.Models;

namespace FND.DAO
{
    public interface IFAQDao
    {
        Task<FAQ> AddAsync(FAQ FAQ);
        Task<FAQ> GetByIdAsync(string Id);
        Task<IEnumerable<FAQ>> GetFAQsAsync();
        string Delete(string id);

    }
}