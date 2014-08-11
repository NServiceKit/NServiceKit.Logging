using NServiceKit.Logging.Log4Net;
using NUnit.Framework;

namespace NServiceKit.Logging.Tests.UseCases
{
    [TestFixture]
    public class UsingLog4Net
    {
        [Test]
        public void Log4NetUseCase()
        {
            LogManager.LogFactory = new Log4NetFactory();
            ILog log = LogManager.GetLogger(GetType());

            log.Debug("Debug Event Log Entry.");
            log.Warn("Warning Event Log Entry.");
        }
    }
}