using aspnetcoreapp.model;
using Microsoft.EntityFrameworkCore;

namespace aspnetcoreapp.data
{
    public class BloggingContext: DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
        : base (options) { }
        public DbSet<Blog> Blogs {get;set;}
        public DbSet<Post> Posts {get;set;}
    }
}