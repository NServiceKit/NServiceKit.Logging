using NServiceKit.Logging.EventLog;
using NServiceKit.Logging.Log4Net;
using NUnit.Framework;

namespace NServiceKit.Logging.Tests.UseCases
{
    [TestFixture]
    public class UsingEventLog
    {
        [Test]
        public void EventLogUseCase()
        {
            LogManager.LogFactory = new EventLogFactory("NServiceKit.Logging.Tests", "Application");
            ILog log = LogManager.GetLogger(GetType());

            log.Debug("Start Logging...");
        }
    }
}