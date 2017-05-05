using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Commands
{
    public class AddExternalCommand
    {
        public ExternalCommandItem Command { get; }

        public AddExternalCommand(ExternalCommandItem command)
        {
            Command = command;
        }
    }
}
