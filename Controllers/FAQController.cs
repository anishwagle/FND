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
    public class FAQController : BaseApiController
    {
        private readonly IFAQService _FAQService;
        public FAQController(IFAQService FAQService)
        {
            _FAQService = FAQService;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(FAQ model)
        {
            var response = await _FAQService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _FAQService.GetFAQsAsync();
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetAsync( [FromRoute] string Id)
        {
            var response = await _FAQService.GetByIdAsync( Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _FAQService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
