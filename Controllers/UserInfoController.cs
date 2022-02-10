using System.Threading.Tasks;
using FND.DTO;
using FND.Models;
using FND.Services;
using FND.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace FND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : BaseApiController
    {
        private readonly IUserInfoService context;
        public UserInfoController(IUserInfoService userInfoService)
        {
            context = userInfoService;
        }
        [Authorize]
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> AddAsync(UserInfo model)
        {
            var response = await context.SaveAsync(model);
            return Ok(CreateSuccessResponse(response));
        }


    
        [Authorize]
        [HttpPost]
        [Route("get-by-userid/{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId)
        {
            var response = await context.GetByIdAsync(userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            context.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
