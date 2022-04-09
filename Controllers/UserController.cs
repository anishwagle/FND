using System.Threading.Tasks;
using FND.DTO;
using FND.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest model)
        {
            var response = await _userService.AuthenticateAsync(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            var response = await _userService.RegisterAsync(model);
            return Ok(response);
        }

        [HttpPost]  
        [Route("forgotpassword")]  
        public async Task<IActionResult> GenerateResetToken([FromQuery] string userEmail)  
        {  


            var response=await _userService.GeneratePasswordResetToken(userEmail);
            return response;
       
        }  

        [HttpPost]  
        [Route("verifyotp")]  
        public async Task<IActionResult> VerifyPasswordResetToken([FromQuery] string userEmail,[FromQuery] string token )  
        {  


            var response=await _userService.VerifyPasswordResetToken(userEmail,token);
            return response;
       
        }

        

        [HttpPost]  
        [Route("resetpass")]  
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetRequest model)  
        {  

            var response=await _userService.ResetPassword(model);
            return response;
       
         }  
    }
}
