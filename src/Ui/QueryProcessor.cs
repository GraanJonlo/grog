using Akka.Actor;

namespace Ui
{
    public class QueryProcessor : ReceiveActor
    {
        public QueryProcessor()
        {
            Receive<string>(message => { Sender.Tell("Hello world!"); });
        }
    }
}
