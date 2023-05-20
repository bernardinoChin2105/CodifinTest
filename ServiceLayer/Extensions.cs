using Domain;
using System.Linq;

namespace ServiceLayer
{
    public static class Extensions
    {
        public static IQueryable<PostDTO> ParsePostToDTO(this IQueryable<DataLayer.Post> Posts)
        {
            return Posts.Select(p => new PostDTO
            {
                Id = p.Id,
                UserId = p.UserId,
                Title = p.Title,
                Body = p.Body,
                Comments = p.Comments.Select(c => new CommentDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PostId = c.PostId,
                    Email = c.Email,
                    Body = c.Body
                }).ToList()
            });
        }

        public static IQueryable<CommentDTO> ParseCommentToDTO(this IQueryable<DataLayer.Comment> Comments)
        {            
            return Comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Name = c.Name,
                PostId = c.PostId,
                Email = c.Email,
                Body = c.Body
            });
        }
    }
}
