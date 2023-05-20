using Domain;
using Integrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ServiceLayer
{
    public class PostsService : IPostsService
    {
        private DataLayer.CodifinDBContext _Context { get; set; }
        private IPlaceHolderService _PlaceHolderService { get; set; }

        public PostsService(DataLayer.CodifinDBContext Context, IPlaceHolderService PlaceHolderService)
        {
            this._Context = Context;
            this._PlaceHolderService = PlaceHolderService;
        }

        public int DownloadPosts()
        {
            int Result = 0;

            try
            {
                var Posts = _PlaceHolderService.GetPlaceHolderPosts();
                var Comments = _PlaceHolderService.GetPlaceHolderComments();

                var DataToSend = Posts.Select(p => new DataLayer.Post
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Title = p.Title,
                    Body = p.Body
                });

                using (var transaction = _Context.Database.BeginTransaction())
                {
                    _Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Posts] ON;");
                    _Context.Posts.AddRange(DataToSend);
                    Result = _Context.SaveChanges();
                    _Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Posts] OFF;");
                    _Context.Database.CommitTransaction();

                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new PostsException(ex.InnerException.Message);
            }
        }

        public IQueryable<PostDTO> GetAll()
        {
            try
            {
                return _Context.Posts
                    .Include(p => p.Comments)
                    .AsNoTracking()
                    .ParsePostToDTO();
            }
            catch (Exception ex)
            {
                throw new PostsException(ex.InnerException.Message);
            }
        }
    }
}
