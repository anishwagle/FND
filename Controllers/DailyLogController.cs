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
    public class DailyLogController : BaseApiController
    {
        private readonly IDailyLogService _dailyLogService;
        public DailyLogController(IDailyLogService dailyLogService)
        {
            _dailyLogService = dailyLogService;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(DailyLog model)
        {
            var response = await _dailyLogService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all/{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId)
        {
            var response = await _dailyLogService.GetDailyLogsAsync(userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{userId}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId, [FromRoute] string Id)
        {
            var response = await _dailyLogService.GetByIdAsync(userId, Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _dailyLogService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
