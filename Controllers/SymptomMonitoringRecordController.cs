using System.Threading.Tasks;
using FND.DTO;
using FND.Models;
using FND.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymptomMonitoringRecordController : BaseApiController
    {
        private readonly ISymptomMonitoringRecordService _symptomMonitoringRecordService;
        public SymptomMonitoringRecordController(ISymptomMonitoringRecordService symptomMonitoringRecordService)
        {
            _symptomMonitoringRecordService = symptomMonitoringRecordService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(SymptomMonitoringRecord model)
        {
            var response = await _symptomMonitoringRecordService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }

        [HttpPost]
        [Route("get-all/{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId)
        {
            var response = await _symptomMonitoringRecordService.GetSymptomMonitoringRecordsAsync(userId);
            return Ok(CreateSuccessResponse(response));
        }

        [HttpPost]
        [Route("get-by-id/{userId}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId, [FromRoute] string Id)
        {
            var response = await _symptomMonitoringRecordService.GetByIdAsync(userId, Id);
            return Ok(CreateSuccessResponse(response));
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _symptomMonitoringRecordService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
