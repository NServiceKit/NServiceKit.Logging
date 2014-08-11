using System;
using System.Web;
using Elmah;

namespace NServiceKit.Logging.Elmah
{
	/// <summary>	Writes Elmah intercepting logger.  </summary>
	/// <remarks>	9/2/2011. </remarks>
	public class ElmahInterceptingLogger
		: ILog
	{
		private readonly ILog log;

		/// <summary>	Constructor. </summary>
		/// <remarks>
		/// Logs to the given Elmah ErrorLog.  Only Error and Fatal are passed along to Elmah, while all other errors will be written to the
		/// wrapped logger.
		/// </remarks>
		/// <exception cref="ArgumentNullException">	Thrown when either the wrapped ILog or Elmah ErrorLog are null. </exception>
		/// <param name="log">	   	The underlying log to write to. </param>
		/// <param name="errorLog">	The error log. </param>
		public ElmahInterceptingLogger(ILog log)
		{
			if (null == log) { throw new ArgumentNullException("log"); }

			this.log = log;
		}

		public void Debug(object message, Exception exception)
		{
			log.Debug(message, exception);
		}

		public void Debug(object message)
		{
			log.Debug(message);
		}

		public void DebugFormat(string format, params object[] args)
		{
			log.DebugFormat(format, args);
		}

		public void Error(object message, Exception exception)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(exception, HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(exception));
			}
			log.Error(message, exception);
		}

		public void Error(object message)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new System.ApplicationException(message.ToString()), HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(new System.ApplicationException(message.ToString())));
			}
			log.Error(message);
		}

		public void ErrorFormat(string format, params object[] args)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new System.ApplicationException(string.Format(format, args)), HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(new System.ApplicationException(string.Format(format, args))));
			}
			log.ErrorFormat(format, args);
		}

		public void Fatal(object message, Exception exception)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(exception, HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(exception));
			}
			log.Fatal(message, exception);
		}

		public void Fatal(object message)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new System.ApplicationException(message.ToString()), HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(new System.ApplicationException(message.ToString())));
			}
			log.Fatal(message);
		}

		public void FatalFormat(string format, params object[] args)
		{
			try {
				ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new System.ApplicationException(string.Format(format, args)), HttpContext.Current));
			}
			catch {
				ErrorLog.GetDefault(null).Log(new Error(new System.ApplicationException(string.Format(format, args))));
			}
			log.FatalFormat(format, args);
		}

		public void Info(object message, Exception exception)
		{
			log.Info(message, exception);
		}

		public void Info(object message)
		{
			log.Info(message);
		}

		public void InfoFormat(string format, params object[] args)
		{
			log.InfoFormat(format, args);
		}

		public bool IsDebugEnabled
		{
			get { return log.IsDebugEnabled; }
		}

		public void Warn(object message, Exception exception)
		{
			log.Warn(message, exception);
		}

		public void Warn(object message)
		{
			log.Warn(message);
		}

		public void WarnFormat(string format, params object[] args)
		{
			log.WarnFormat(format, args);
		}
	}
}