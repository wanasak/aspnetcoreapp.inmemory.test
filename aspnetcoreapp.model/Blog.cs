using System.Collections.Generic;

namespace aspnetcoreapp.model
{
    public class Blog
    {
        public int ID {get;set;}
        public string Url {get;set;}
        public List<Post> Posts {get;set;}
    }
}