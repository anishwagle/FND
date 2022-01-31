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
    public class SMPFormController : BaseApiController
    {
        private readonly ISMPFormService _context;
        public SMPFormController(ISMPFormService context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(SMPForm model)
        {
            var response = await _context.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all/{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId)
        {
            var response = await _context.GetSMPFormsAsync(userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{userId}/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userId, [FromRoute] string Id)
        {
            var response = await _context.GetByIdAsync(userId, Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _context.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
