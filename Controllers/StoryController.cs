using System.Threading.Tasks;
using FND.DTO;
using FND.Models;
using FND.Services;
using FND.Middlewares;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 using System;
namespace FND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : BaseApiController
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(Story model)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    model.Image = fileBytes;
                }

            }

            var response = await _storyService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _storyService.GetStorysAsync();
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetAsync( [FromRoute] string Id)
        {
            var response = await _storyService.GetByIdAsync( Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-user/{userId}")]
        public async Task<IActionResult> GetByUserAsync( [FromRoute] string userId)
        {
            var response = await _storyService.GetByUserAsync( userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _storyService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
