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
    public class SeizureMonitoringRecordController : BaseApiController
    {
        private readonly ISeizureMonitoringRecordService _seizureMonitoringRecordService;
        public SeizureMonitoringRecordController(ISeizureMonitoringRecordService seizureMonitoringRecordService)
        {
            _seizureMonitoringRecordService = seizureMonitoringRecordService;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(SeizureMonitoringRecord model)
        {
            var response = await _seizureMonitoringRecordService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all/{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId)
        {
            var response = await _seizureMonitoringRecordService.GetSeizureMonitoringRecordsAsync(userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{userId}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId, [FromRoute] string Id)
        {
            var response = await _seizureMonitoringRecordService.GetByIdAsync(userId, Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _seizureMonitoringRecordService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
