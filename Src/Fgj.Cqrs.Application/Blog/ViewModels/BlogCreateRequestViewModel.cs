namespace Fgj.Cqrs.Application.Blog.ViewModels
{
    public class BlogCreateRequestViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Tag { get; set; }

        public string Url { get; set; }
    }
}
