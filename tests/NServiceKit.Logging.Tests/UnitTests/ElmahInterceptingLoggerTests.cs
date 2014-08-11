﻿using System;
using NUnit.Framework;
using Rhino.Mocks;
using NServiceKit.Logging.Elmah;

namespace NServiceKit.Logging.Tests.UnitTests
{
	[TestFixture]
	public class ElmahInterceptingLoggerTests
	{
		[Test]
		public void ElmahInterceptingLoggerTest()
		{
			var wrappedLogger = MockRepository.GenerateStub<ILog>();
			ILog log = new ElmahInterceptingLogger(wrappedLogger);
			Assert.IsNotNull(log);
		}

		[Test]
		public void ElmahInterceptingLogger_LoggingTest()
		{
			string message = "Error Message";
			Exception ex = new Exception();
			string messageFormat = "Message Format: message: {0}, exception: {1}";

			var wrappedLogger = MockRepository.GenerateStub<ILog>();
			ILog log = new ElmahInterceptingLogger(wrappedLogger);
			Assert.IsNotNull(log);

			log.Debug(message);
			log.Debug(message, ex);
			log.DebugFormat(messageFormat, message, ex.Message);

			log.Error(message);
			log.Error(message, ex);
			log.ErrorFormat(messageFormat, message, ex.Message);

			log.Fatal(message);
			log.Fatal(message, ex);
			log.FatalFormat(messageFormat, message, ex.Message);

			log.Info(message);
			log.Info(message, ex);
			log.InfoFormat(messageFormat, message, ex.Message);

			log.Warn(message);
			log.Warn(message, ex);
			log.WarnFormat(messageFormat, message, ex.Message);
		}
	}
}
