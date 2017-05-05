using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.Event;
using UtilsAgent.Core.Commands;
using UtilsAgent.Core.Dto;
using UtilsAgent.Services.Serializer;

namespace UtilsAgent.Actors
{
    public class ExternalRequestHandler : ReceiveActor
    {
        private readonly List<ExternalCommandItem> _externalCommands = new List<ExternalCommandItem>();
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public ExternalRequestHandler()
        {
            Receive<string>(msg => StringAction(msg));

            Receive<ExternalRequest>(msg => ExternalRequestAction(msg));

            Receive<AddExternalCommand>(msg =>
            {
                _externalCommands.Add(msg.Command);
            });

            ReceiveAny(msg =>
            {
                _log.Warning($"Unknown type of message {msg.GetType()}");
            });
        }

        private void ExternalRequestAction(ExternalRequest msg)
        {
            var command = _externalCommands.FirstOrDefault(c => c.CommandText == msg.Command);

            if (command == null)
            {
                Sender.Tell(new Failed("Command not found"));
                return;
            }

            if (command.CreateInstance == null)
            {
                Sender.Tell(new Failed("Command create func not defined"));
                return;
            }

            var internalCommand = command.CreateInstance(msg);

            var validationResult = internalCommand.Validate();
            if (validationResult != null && validationResult.HasError)
            {
                Sender.Tell(validationResult);
                return;
            }

            var actor = Context.System.ActorSelection(command.ActorPath);
            actor.Tell(internalCommand);

            Sender.Tell(new Completed(), Self);
        }

        private void StringAction(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                Sender.Tell(new Failed("Message is empty"), Self);
                _log.Error("Incorrect message input");
                return;
            }

            try
            {
                var request = Serializer.Deserialize<ExternalRequestData>(msg);
                Self.Tell(new ExternalRequest(request));
                Sender.Tell(new Completed());
            }
            catch (Exception e)
            {
                _log.Error(e, "Incorrect message format");
                Sender.Tell(new Failed("Bad format"), Self);
            }
        }
    }
}
