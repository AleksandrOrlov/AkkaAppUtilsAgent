using Akka.Configuration;
using Akka.TestKit.NUnit3;

namespace UtilsAgent.Test
{
    public abstract class BaseTest : TestKit
    {
        protected BaseTest()
            : base(ConfigurationFactory.Load().WithFallback(DefaultConfig))
        {
            
        }
    }
}
