using Akka.Actor;
using Core.Messages;

namespace Core.Actors
{
    public class DomainModels : ReceiveActor
    {
        private IActorRef _posts = Context.ActorOf<Posts>();

        public DomainModels()
        {
            Receive<GetPosts>(message => { _posts.Forward(message); });
        }
    }
}
