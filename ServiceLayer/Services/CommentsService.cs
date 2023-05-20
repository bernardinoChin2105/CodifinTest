using Domain;
using Integrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ServiceLayer
{
    public class CommentsService : ICommentsService
    {
        private DataLayer.CodifinDBContext _Context { get; set; }
        private IPlaceHolderService _PlaceHolderService { get; set; }

        public CommentsService(DataLayer.CodifinDBContext Context, IPlaceHolderService PlaceHolderService)
        {
            this._Context = Context;
            this._PlaceHolderService = PlaceHolderService;
        }

        public int DownloadComments()
        {
            int Result = 0;

            try
            {                
                var Comments = _PlaceHolderService.GetPlaceHolderComments();

                var DataToSend = Comments.Select(c => new DataLayer.Comment
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Body = c.Body,
                    PostId = c.PostId
                });

                using (var transaction = _Context.Database.BeginTransaction())
                {
                    _Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Comments] ON;");
                    _Context.Comments.AddRange(DataToSend);
                    Result = _Context.SaveChanges();
                    _Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Comments] OFF;");
                    _Context.Database.CommitTransaction();

                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new CommentsException(ex.InnerException.Message);
            }
        }      
    }
}
