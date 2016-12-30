using System;
using aspnetcoreapp.model;

namespace aspnetcoreapp.data
{
    public class BloggingInitializer
    {
        private static BloggingContext _context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (BloggingContext)serviceProvider.GetService(typeof(BloggingContext));
            InitializeData();
        }

        private static void InitializeData()
        {
            var blog1 = new Blog
            {
                ID = 1,
                Url = "http://google.co.th"
            };
            var blog2 = new Blog
            {
                ID = 2,
                Url = "http://fabebook.com"
            };
            _context.Blogs.Add(blog1);
            _context.Blogs.Add(blog2);
            _context.SaveChanges();
        }
    }
}