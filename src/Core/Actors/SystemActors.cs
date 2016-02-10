using Akka.Actor;

namespace Core.Actors
{
    public class SystemActors
    {
        public IActorRef DomainModels { get; private set; }

        public SystemActors(IActorRef domainModels)
        {
            DomainModels = domainModels;
        }
    }
}
