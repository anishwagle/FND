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
    public class PostController : BaseApiController
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(Post model)
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

            var response = await _postService.AddAsync(model);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _postService.GetPostsAsync();
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetAsync( [FromRoute] string Id)
        {
            var response = await _postService.GetByIdAsync( Id);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("get-by-user/{userId}")]
        public async Task<IActionResult> GetByUserAsync( [FromRoute] string userId)
        {
            var response = await _postService.GetByUserAsync( userId);
            return Ok(CreateSuccessResponse(response));
        }
        [Authorize]
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _postService.Delete(Id);
            return Ok(CreateSuccessResponse("Deleted"));
        }
    }
}
