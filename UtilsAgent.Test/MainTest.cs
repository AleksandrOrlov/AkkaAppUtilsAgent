using Akka.Configuration;
using Akka.TestKit.NUnit3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            ExpectNoMsg();
        }
    }
}