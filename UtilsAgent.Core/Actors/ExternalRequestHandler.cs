using System.Collections.Generic;
using Akka.Actor;
using UtilsAgent.Core.Commands;
using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Actors
{
    public class ExternalRequestHandler : ReceiveActor
    {
        private IReadOnlyCollection<ExternalCommandItem> _externalCommands;

        public ExternalRequestHandler()
        {
            _externalCommands = new List<ExternalCommandItem>();

            Receive<ExternalRequest>(msg =>
            {
                
            });

            Receive<ExternalRequest>(msg =>
            {

            });
        }
    }
}
