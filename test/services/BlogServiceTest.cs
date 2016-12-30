using aspnetcoreapp.data;
using aspnetcoreapp.service;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using aspnetcoreapp.model;

namespace test.services
{
    public class BlogServiceTest
    {
        [Fact]
        public void Add_writes_to_database()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                service.Add("http://instagram.com");
            }
            using (var context = new BloggingContext(options))
            {
                Assert.Equal(1, context.Blogs.Count());
                Assert.Equal("http://instagram.com", context.Blogs.Single().Url);
            }
        }
        [Fact]
        public void Find_searches_url()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Find_searches_url")
                .Options;
            using (var context = new BloggingContext(options))
            {
                context.Blogs.Add(new Blog { Url = "http://facebook.com/cat"});
                context.Blogs.Add(new Blog { Url = "http://facebook.com/dog"});
                context.Blogs.Add(new Blog { Url = "http://facebook.com/fish"});
                context.SaveChanges();
            }
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                var result = service.Find("cat");
                Assert.Equal(1, result.Count());
            }
        }
    }
}