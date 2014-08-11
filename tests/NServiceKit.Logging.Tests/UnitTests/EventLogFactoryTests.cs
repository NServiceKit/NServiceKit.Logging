using NServiceKit.Logging.EventLog;
using NServiceKit.Logging.Log4Net;
using NUnit.Framework;

namespace NServiceKit.Logging.Tests.UnitTests
{
    [TestFixture]
    public class EventLogFactoryTests
    {
        [Test]
        public void EventLogFactoryTest()
        {
            EventLogFactory factory = new EventLogFactory("NServiceKit.Logging.Tests", "Application");
            ILog log = factory.GetLogger(GetType());
            Assert.IsNotNull(log);
            Assert.IsNotNull(log as EventLogger);

            factory = new EventLogFactory("NServiceKit.Logging.Tests");
            log = factory.GetLogger(GetType());
            Assert.IsNotNull(log);
            Assert.IsNotNull(log as EventLogger);
        }
    }
}