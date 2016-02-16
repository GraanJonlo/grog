using Akka.Actor;
using Core.Messages;

namespace Core.Actors
{
    public class DomainModels : ReceiveActor
    {
        private readonly IActorRef _posts;

        public DomainModels()
        {
            _posts = Context.ActorOf<Posts>();

            Receive<GetPosts>(message => { _posts.Forward(message); });
        }
    }
}
