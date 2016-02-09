using Akka.Actor;

namespace Ui
{
    public class SystemActors
    {
        public IActorRef QueryProcessor { get; private set; }

        public SystemActors(IActorRef queryProcessor)
        {
            QueryProcessor = queryProcessor;
        }
    }
}
