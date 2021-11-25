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
            return Ok(CreateSuccessResponse(response));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model, [FromQuery] string ReferedBy)
        {
            if (!string.IsNullOrEmpty(ReferedBy))
                model.ReferedBy = ReferedBy;
            var response = await _userService.RegisterAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
    }
}
