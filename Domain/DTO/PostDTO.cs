using System.Collections.Generic;

namespace Domain
{
    public class PostDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }

        public PostDTO()
        {
            Comments = new List<CommentDTO>();
        }
    }
}