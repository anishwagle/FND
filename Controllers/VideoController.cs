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
    public class VideoController : BaseApiController
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        [Authorize]
        [HttpVideo]
        [Route("add")]
        public async Task<IActionResult> AddAsync(Video model)
        {
            var file = Request.Form.Files[0];
            byte[] binaryContent = File.ReadAllBytes(file
            );
            model.Image=binaryContent;
            var response = await _videoService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpVideo]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _videoService.GetVideosAsync();
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpVideo]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetAsync( [FromRoute] string Id)
        {
            var response = await _videoService.GetByIdAsync( Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpVideo]
        [Route("get-by-user/{userId}")]
        public async Task<IActionResult> GetByUserAsync( [FromRoute] string userId)
        {
            var response = await _videoService.GetByUserAsync( userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpVideo]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _videoService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
