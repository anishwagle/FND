using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;
using Microsoft.AspNetCore.Mvc;

namespace FND.Services
{
    public interface IUserService
    {
        Task<IActionResult> AuthenticateAsync(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        Task<User> GetByIdAsync(string id);
        Task<IActionResult> RegisterAsync(RegisterRequest model);
        void Delete(string id);

    }
}
