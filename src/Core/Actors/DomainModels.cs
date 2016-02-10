using Akka.Actor;
using Core.Messages;

namespace Core.Actors
{
    public class DomainModels : ReceiveActor
    {
        public DomainModels()
        {
            Receive<GetPosts>(message => { Sender.Tell("Hello world!"); });
        }
    }
}
