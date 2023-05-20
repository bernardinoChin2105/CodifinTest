using System.Collections.Generic;

namespace CodifinAPI.Models
{
    public class PostResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public List<CommentResponse> Comments { get; set; }

        public PostResponse()
        {
            Comments = new List<CommentResponse>();
        }
    }
}