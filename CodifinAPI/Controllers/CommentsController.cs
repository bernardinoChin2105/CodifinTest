using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodifinAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentsService _CommentsService;
        IPostsService _PostsService;

        public CommentsController(ICommentsService CommentsService, IPostsService PostsService)
        {
            _CommentsService = CommentsService;
            _PostsService = PostsService;
        }

        [HttpPost]
        [Route("initialize-data")]
        public ActionResult InitializeData()
        {
            try
            {                
                if (_PostsService.GetAll().Count() == 0)
                    return BadRequest("Se requiere ejecutar la descarga de los posts previo a la descarga de los comentarios.");

                _CommentsService.DownloadComments();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
