using System;
using Akka.Actor;
using UtilsAgent.Core.Commands;

namespace UtilsAgent.Core.Dto
{
    public class ExternalCommandItem
    {
        public string CommandText { get; set; }

        public ActorPath ActorPath { get; set; }

        public Func<ExternalRequest, BaseExternalCommand> CreateInstance { get; set; }
    }
}
