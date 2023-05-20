using System.Linq;

namespace Domain
{
    public interface IPostsService
    {
        public int DownloadPosts();
        public IQueryable<PostDTO> GetAll();
    }
}
