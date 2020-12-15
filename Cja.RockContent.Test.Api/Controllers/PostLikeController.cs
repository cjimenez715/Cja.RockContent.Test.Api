using System.Threading.Tasks;
using Cja.RockContent.Test.Api.Models.Dto;
using Cja.RockContent.Test.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cja.RockContent.Test.Api.Controllers
{
    [Route("api/post-like")]
    [ApiController]
    public class PostLikeController : ControllerBase
    {
        private readonly IPostLikeService _postLikeService;
        public PostLikeController(IPostLikeService postLikeService)
        {
            _postLikeService = postLikeService;
        }

        [HttpGet("get-by-id/{id}")]
        public ActionResult<PostLikeGetDto> GetById([FromRoute] string id)
        {
            var postLike = _postLikeService.GetByIdAsync(id);
            if(postLike == null)
            {
                return NotFound();
            }

            var result = new PostLikeGetDto() { LikeCounter = postLike.LikeCounter };
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> OnPostLike([FromBody] PostLikeUpdateDto postLike)
        {
            var postLikeResult = _postLikeService.GetByIdAsync(postLike.Id);

            await _postLikeService.OnPostLike(postLike.Id, postLikeResult);

            return Ok();
        }
    }
}
