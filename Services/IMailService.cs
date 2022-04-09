using System.Collections.Generic;
using System.Threading.Tasks;
using FND.DTO;
using FND.Models;

namespace FND.Services
{
    public interface IMailService
{
    Task SendEmailAsync(string email,string subject, string body);
}
}