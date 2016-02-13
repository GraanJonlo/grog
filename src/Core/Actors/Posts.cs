using System;
using System.Collections.Generic;
using Akka.Actor;
using Core.Messages;
using NodaTime;

namespace Core.Actors
{
    public class Posts : ReceiveActor
    {
        public Posts()
        {
            var posts = new List<Post>(1)
                        {
                            new Post()
                            {
                                Author = new Author {Image = "", Name = "Andy", Slug = "andy"},
                                Content = "Hello world!",
                                PublishedTime = Instant.FromDateTimeUtc(DateTime.UtcNow),
                                Slug = "hello-world",
                                Tags = new List<Tag>(0),
                                Title = "Hello World!"
                            }
                        };
            Receive<GetPosts>(message => { Sender.Tell(posts); });
        }
    }
}
