using Akka.Actor;
using Core.DataLayer;
using Core.Messages;
using SimpleInjector;

namespace Core.Actors
{
    public class Posts : ReceiveActor
    {
        private readonly IReadPosts _readModel;

        public Posts(Container container)
        {
            _readModel = container.GetInstance<IReadPosts>();

            Receive<GetPosts>(message => { Sender.Tell(_readModel.GetPosts(message)); });
        }
    }
}
