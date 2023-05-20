using System.Collections.Generic;

namespace Domain
{
    public interface IPlaceHolderService
    {
        public List<PostDTO> GetPlaceHolderPosts();
        public List<CommentDTO> GetPlaceHolderComments();
    }
}
