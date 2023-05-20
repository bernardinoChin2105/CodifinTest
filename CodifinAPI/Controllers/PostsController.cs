using CodifinAPI.Models;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System;

namespace CodifinAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _PostsService;

        public PostsController(IPostsService PostsService)
        {
            _PostsService = PostsService;
        }

        [HttpPost]
        [Route("initialize-data")]
        public ActionResult InitializeData()
        {
            try
            {
                _PostsService.DownloadPosts();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<PostResponse>> GetAll()
        {
            try
            {
                List<PostResponse> Result = new List<PostResponse>();
                var Posts = _PostsService.GetAll().ToList();

                Result = Posts.Select(p => new PostResponse
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Title = p.Title,
                    Body = p.Body,
                    Comments = p.Comments.Select(c => new CommentResponse
                    {
                        Id = c.Id,
                        PostId = c.PostId,
                        Name = c.Name,
                        Email = c.Email,
                        Body = c.Body
                    }).ToList()
                }).ToList();

                return Ok(Result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<PaginatedPost> Get(
            [FromQuery(Name = "page-size")][Required] int PageSize,
            [FromQuery(Name = "page-number")][Required] int PageNumber,
            [FromQuery(Name = "user-id")] int UserId
        )
        {
            try
            {
                if (PageNumber == 0)
                    return BadRequest("Se esperaba PageNumber mayor a 0");

                if (PageSize == 0)
                    return BadRequest("Se esperaba PageSize mayor a 0");

                PaginatedPost Result = new PaginatedPost();
                IQueryable<PostDTO> Posts;


                //Check optimization with Predicate Builder. 
                if (UserId == 0)
                    Posts = _PostsService.GetAll();
                else
                    Posts = _PostsService.GetAll().Where(p => p.UserId == UserId);

                int ToSkip = (PageNumber - 1) * PageSize;
                int ToTake = PageSize;
                Result.TotalRows = Posts.Count();

                int TotalPages = Convert.ToInt32(Math.Ceiling((double)Result.TotalRows / (double)PageSize));

                Result.PrevPage = PageNumber - 1 >= 1 && PageNumber <= TotalPages ? (PageNumber - 1).ToString() : null;// PageNumber == 1 ? null : (PageNumber - 1).ToString();
                Result.NextPage = PageNumber >= 1 && PageNumber < TotalPages ? (PageNumber + 1).ToString() : null; //PageNumber * PageSize >= Result.TotalRows ? null : (PageNumber + 1).ToString();
                Posts.Skip(ToSkip).Take(ToTake).ToList().ForEach(p =>
                {
                    Result.Data.Add(new PostResponse
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        Title = p.Title,
                        Body = p.Body,
                        Comments = p.Comments.Select(c => new CommentResponse
                        {
                            Id = c.Id,
                            PostId = c.PostId,
                            Name = c.Name,
                            Email = c.Email,
                            Body = c.Body
                        }).ToList()
                    });
                });

                return Ok(Result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
