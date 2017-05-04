using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Event;

namespace UtilsAgent.CompanyCloning
{
    public class TestMsgActor : ReceiveActor
    {
        public TestMsgActor()
        {
            Receive<string>(msg =>
            {
                var log = Context.GetLogger();
                log.Warning("Message Recieve: " + msg);
                Sender.Tell(msg + " OK");
            });
        }
    }
}
