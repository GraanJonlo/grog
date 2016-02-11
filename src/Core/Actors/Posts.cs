using Akka.Actor;
using Core.Messages;

namespace Core.Actors
{
    public class Posts : ReceiveActor
    {
        public Posts()
        {
            Receive<GetPosts>(message => { Sender.Tell("Hello world!"); });
        }
    }
}
