using Akka.Actor;
using Core.Messages;
using SimpleInjector;

namespace Core.Actors
{
    public class DomainModels : ReceiveActor
    {
        private readonly IActorRef _posts;

        public DomainModels(Container container)
        {
            _posts = Context.ActorOf(Props.Create(() => new Posts(container)), "posts");

            Receive<GetPosts>(message => { _posts.Forward(message); });
        }
    }
}
