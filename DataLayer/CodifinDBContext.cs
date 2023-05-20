using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CodifinDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }


        public CodifinDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
