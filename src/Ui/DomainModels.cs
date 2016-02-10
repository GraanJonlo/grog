using Akka.Actor;

namespace Ui
{
    public class DomainModels : ReceiveActor
    {
        public DomainModels()
        {
            Receive<string>(message => { Sender.Tell("Hello world!"); });
        }
    }
}
