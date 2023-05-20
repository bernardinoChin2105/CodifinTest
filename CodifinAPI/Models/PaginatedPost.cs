using System.Collections.Generic;

namespace CodifinAPI.Models
{
    public class PaginatedPost
    {
        public int TotalRows { get; set; }
        public string PrevPage { get; set; }
        public string NextPage { get; set; }
        public List<PostResponse> Data { get; set; }
        public PaginatedPost()
        {
            Data = new List<PostResponse>();
        }
    }
}
