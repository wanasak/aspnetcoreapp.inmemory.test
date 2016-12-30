using System.Collections.Generic;
using System.Linq;
using aspnetcoreapp.data;
using aspnetcoreapp.model;

namespace aspnetcoreapp.service
{
    public class BlogService
    {
        private readonly BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context;
        }
        public void Add(string url)
        {
            var blog = new Blog { Url = url };
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
        public IEnumerable<Blog> Find(string term)
        {
            return _context.Blogs
                .Where(b => b.Url.Contains(term))
                .OrderBy(b => b.Url)
                .ToList(); 
        }
    }
}