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
        Task<IActionResult> GeneratePasswordResetToken(string email);
        Task<IActionResult> VerifyPasswordResetToken(string userEmail,string token);
        Task<IActionResult> ResetPassword(PasswordResetRequest resetReq);
        void Delete(string id);

    }
}
