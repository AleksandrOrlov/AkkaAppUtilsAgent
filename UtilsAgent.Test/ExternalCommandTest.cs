using System;
using System.Collections.Generic;
using Akka.Actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilsAgent.Actors;
using UtilsAgent.Core.Commands;
using UtilsAgent.Core.Dto;
using UtilsAgent.Core.Interfaces;
using UtilsAgent.ExternalCommands;
using UtilsAgent.Services.Serializer;

namespace UtilsAgent.Test
{
    [TestClass]
    public class ExternalCommandTest : BaseTest
    {
        private ExternalRequestData GetRequestData(bool isCorrectCommand = true, bool isCorrectArgs = true)
        {
            return new ExternalRequestData
            {
                Command = isCorrectCommand ? "clone-company" : "bad",
                Args = new List <Argument>
                {
                    new Argument {Key = "companyId", Value = isCorrectArgs ? "company12345" : string.Empty},
                    new Argument {Key = "copyCount", Value = isCorrectArgs ? "5" : "-1"}
                }
            };
        }
        private ExternalRequest GetCorrectRequest(bool isCorrectArgs = true)
        {
            return new ExternalRequest(GetRequestData(true, isCorrectArgs));
        }

        private string GetCorrectXml()
        {
            return Serializer.Serialize(GetRequestData());
        }

        private ExternalRequest GetInCorrectRequest()
        {
            return new ExternalRequest(GetRequestData(false, false));
        }

        private IActorRef InitExternalHandler()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            actor.Tell(new AddExternalCommand(new ExternalCommandItem
            {
                CommandText = "clone-company",
                ActorPath = actor.Path,
                CreateInstance = r => new ExternalCloneCompany(r)
            }), TestActor);

            actor.Tell(new AddExternalCommand(new ExternalCommandItem
            {
                CommandText = "bad",
                ActorPath = actor.Path
            }), TestActor);

            return actor;
        }

        [TestMethod]
        public void Should_Complete_Valid_Xml_Send()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(GetCorrectXml(), TestActor);

                ExpectMsg<Completed>();
            });
        }

        [TestMethod]
        public void Should_Fail_Bad_String_Send()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell("bad string", TestActor);

                ExpectMsg<Failed>((msg, sender) => msg.Message == "Bad format");
            });
        }

        [TestMethod]
        public void Should_Fail_Empty_String_Send()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(string.Empty, TestActor);

                ExpectMsg<Failed>((msg, sender) => msg.Message == "Message is empty");
            });
        }

        [TestMethod]
        public void Should_Complete_Valid_Request_Send()
        {
            var actor = InitExternalHandler();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(GetCorrectRequest(), TestActor);

                ExpectMsg<Completed>();
            });
        }

        [TestMethod]
        public void Should_Fail_NotDefined_CreateInstance_Request_Send()
        {
            var actor = InitExternalHandler();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(GetInCorrectRequest(), TestActor);

                ExpectMsg<Failed>((msg, sender) => msg.Message == "Command create func not defined");
            });
        }

        [TestMethod]
        public void Should_Fail_NotExist_Command_Request_Send()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(GetInCorrectRequest(), TestActor);

                ExpectMsg<Failed>((msg, sender) => msg.Message == "Command not found");
            });
        }

        [TestMethod]
        public void Should_Fail_NotValid_Command_Request_Send()
        {
            var actor = InitExternalHandler();

            Within(TimeSpan.FromSeconds(1), () =>
            {
                actor.Tell(GetCorrectRequest(false), TestActor);

                ExpectMsg<IValidationCommandResult>((msg, sender) => msg.HasError && msg.ValidationErrors.Count == 2);
            });
        }

        [TestMethod]
        public void Should_NoMsg_Add_ExternalCommand()
        {
            var actor = ActorOf<ExternalRequestHandler>();

            actor.Tell(new AddExternalCommand(new ExternalCommandItem()), TestActor);

            ExpectNoMsg(TimeSpan.FromSeconds(1));
        }
    }
}
