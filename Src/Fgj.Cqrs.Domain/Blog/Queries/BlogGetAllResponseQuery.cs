using System;

namespace Fgj.Cqrs.Domain.Blog.Queries
{
    public class BlogGetAllResponseQuery
    {
        public DateTime Date { get; }

        public string Guid { get; }

        public string Title { get; }

        public string Description { get; }

        public string Image { get; }

        public string Tag { get; }

        public string Url { get; }

        public BlogGetAllResponseQuery(DateTime date, string guid, string title, string description, string image, string tag, string url)
        {
            Date = date;
            Guid = guid;
            Title = title;
            Description = description;
            Image = image;
            Tag = tag;
            Url = url;
        }
    }
}
