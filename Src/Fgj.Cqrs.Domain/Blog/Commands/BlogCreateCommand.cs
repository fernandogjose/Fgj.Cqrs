using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Blog.Commands
{
    public class BlogCreateCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public string Title { get; }

        public string Description { get; }

        public string Image { get; }

        public string Tag { get; }

        public string Url { get; }

        public BlogCreateCommand(string title, string description, string image, string tag, string url)
        {
            Title = title;
            Description = description;
            Image = image;
            Tag = tag;
            Url = url;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Title))
            {
                Errors.Add("Title is required");
            }

            if (string.IsNullOrEmpty(Description))
            {
                Errors.Add("Description is required");
            }

            if (string.IsNullOrEmpty(Tag))
            {
                Errors.Add("Tag is required");
            }

            if (string.IsNullOrEmpty(Url))
            {
                Errors.Add("Url is required");
            }
        }
    }
}
