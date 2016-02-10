using Akka.Actor;

namespace Ui
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
