using RestSharp;
using System;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace Integrations
{
    public class PlaceHolderService : IPlaceHolderService
    {
        public string BaseUrl => "https://jsonplaceholder.typicode.com";

        private string PostsUrl => $"{BaseUrl}/posts";

        private string CommentsUrl => $"{BaseUrl}/comments";

        public List<PostDTO> GetPlaceHolderPosts()
        {
            try
            {
                var Client = new RestClient(PostsUrl);
                var Response = Client.Execute<List<Post>>(new RestRequest());
                return Response.Data.Select(p => new PostDTO
                {
                    Id = p.Id,
                    Body = p.Body,
                    Title = p.Title,
                    UserId = p.UserId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PlaceHolderException(ex.InnerException.Message);
            }

        }

        public List<CommentDTO> GetPlaceHolderComments()
        {
            try
            {
                var Client = new RestClient(CommentsUrl);
                var Response = Client.Execute<List<Comment>>(new RestRequest());
                return Response.Data.Select(c => new CommentDTO
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    Body = c.Body,
                    Email = c.Email,
                    Name = c.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PlaceHolderException(ex.InnerException.Message);
            }
        }

    }
}
