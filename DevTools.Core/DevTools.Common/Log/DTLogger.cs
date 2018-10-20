using System;
using System.Text;
using NLog;

namespace DevTools.Common.Log
{
    public delegate void DTLoggingHandler(string message);

    public class DTLogger
    {
        private Logger logger = null;

        public DTLogger()
        {
#if DEBUG
            this.logger = LogManager.GetLogger("Debug");
#else
            this.logger = LogManager.GetLogger("Release");
#endif
        }

        private static DTLogger instance = null;

        public static DTLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DTLogger();
                }
                return instance;
            }
        }

        public event DTLoggingHandler DTLogging;

        protected virtual void OnLogging(string format, params object[] args)
        {
            if (DTLogging != null)
            {
                DTLogging(string.Format(format, args));
            }
        }

        public void Debug(string format, params object[] args)
        {
            OnLogging(format, args);
            this.logger.Debug(format, args);
        }

        public void Info(string format, params object[] args)
        {
            OnLogging(format, args);
            this.logger.Info(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            OnLogging(format, args);
            this.logger.Warn(format, args);
        }

        public void Error(Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("Error and Stack Trace:");
            StringBuilder trace = new StringBuilder();
            int level = 0;
            while (ex != null)
            {
                trace.Clear();
                string symbol = new string(' ', level * 4);
                if (level > 0)
                {
                    msg.Append(new string(' ', (level - 1) * 4));
                    msg.Append("└─");
                }
                if (ex.InnerException == null)
                {
                    msg.Append("─");
                    symbol += "  ";
                }
                else
                {
                    msg.Append("┬");
                    symbol += "│";
                }
                foreach (string item in ex.StackTrace.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    trace.Append(symbol);
                    trace.AppendLine(item);
                }
                msg.AppendLine(ex.Message);
                msg.Append(trace);
                level++;
                ex = ex.InnerException;
            }
            OnLogging(msg.ToString().Trim());
            Error(msg.ToString().Trim());
        }

        public void Error(Exception ex, string message, params object[] args)
        {
            OnLogging(message, args);
            this.logger.Error(ex, message, args);
        }

        public void Error(string format, params object[] args)
        {
            OnLogging(format, args);
            this.logger.Error(format, args);
        }
    }
}
