using System;
using Akka.Configuration;
using Akka.Dispatch.SysMsg;
using Akka.Event;
using Akka.TestKit.NUnit3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Targets;
using NUnit.Framework;
using UtilsAgent.CompanyCloning;

namespace UtilsAgent.Test
{
    [TestClass]
    public class MainTest : TestKit
    {
        public MainTest()
            : base(ConfigurationFactory.Load().WithFallback(DefaultConfig))
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            //var container = new UnityContainer();
            //container.RegisterType<ISourceData, SourceData>();
            
            //Sys.AddDependencyResolver(new UnityDependencyResolver(container, Sys));

            //var a = ActorOf(Sys.DI().Props<CloneFullCompany>(), "Worker1");
            
            //a.Tell(new StartCloningCompany("asf"), null);
            

            var message = "fsa";

            var testActor = ActorOf<TestMsgActor>("Worker1");

            Within(TimeSpan.FromSeconds(1), () =>
            {
                testActor.Tell(message, TestActor);
                ExpectMsg<string>((msg, sender) => msg == message + " OK");
            });
        }
    }
}