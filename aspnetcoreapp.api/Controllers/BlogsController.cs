using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.data;

namespace aspnetcoreapp.api.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController: Controller
    {
        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            var blogs = _context.Blogs  
                .Include(b => b.Posts)
                .ToList();
            var response = blogs.Select(b => new{
                id = b.ID,
                Url = b.Url,
                post = b.Posts.Select(p => p.Content)
            });
            return Ok(response);
        }
    }
}