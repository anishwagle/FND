using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        Task<User> GetByIdAsync(string id);
        Task<User> RegisterAsync(RegisterRequest model);
        void Delete(string id);

    }
}
