using System.Collections.Generic;
using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Commands
{
    public class ExternalRequest
    {
        public string Command { get;}

        public IEnumerable<Arguments> Args { get; }

        public ExternalRequest(string command, IEnumerable<Arguments> args)
        {
            Command = command;
            Args = args;
        }
    }
}
