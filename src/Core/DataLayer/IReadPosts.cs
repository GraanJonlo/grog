using System;
using System.Collections.Generic;
using Core.Messages;
using NodaTime;

namespace Core.DataLayer
{
    public interface IReadPosts
    {
        IEnumerable<Post> GetPosts(GetPosts msg);
    }

    public class FakePostsReadModel : IReadPosts
    {
        public IEnumerable<Post> GetPosts(GetPosts msg)
        {
            var posts = new List<Post>(1)
                        {
                            new Post()
                            {
                                Author = new Author {Image = "", Name = "Andy", Slug = "andy"},
                                Content = "Hello world!",
                                PublishedTime = Instant.FromDateTimeUtc(new DateTime(2016, 2, 19, 16, 21, 0, DateTimeKind.Utc)),
                                Slug = "hello-world",
                                Tags = new List<Tag>(0),
                                Title = "Hello World!"
                            }
                        };

            return posts;
        }
    }
}
