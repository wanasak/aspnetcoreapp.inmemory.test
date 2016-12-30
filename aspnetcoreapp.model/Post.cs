namespace aspnetcoreapp.model
{
    public class Post
    {
        public int ID {get;set;}
        public string Title {get;set;}
        public string Content {get;set;}
        public int BlogID {get;set;}
        public Blog Blog {get;set;}
    }
}