using System.Collections.Generic;
using NodaTime;

namespace Core
{
    public class Post
    {
        public Author Author { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public Instant PublishedTime { get; set; }
        public List<Tag> Tags { get; set; }
        public string Content { get; set; }
    }
}
