using System.Collections.Generic;
using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Commands
{
    public class ExternalRequest
    {
        public string Command { get; }

        public IReadOnlyCollection<Argument> Args { get; }

        public ExternalRequest(ExternalRequestData data)
        {
            Command = data.Command;
            Args = data.Args;
        }

        public ExternalRequest(string command, IReadOnlyCollection<Argument> args)
        {
            Command = command;
            Args = args;
        }
    }
}
