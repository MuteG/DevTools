using System;
using NLog;

namespace DevTools.Common.Log
{
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

        public void Debug(string format, params object[] args)
        {
            this.logger.Debug(format, args);
        }

        public void Info(string format, params object[] args)
        {
            this.logger.Info(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            this.logger.Warn(format, args);
        }

        public void Error(Exception ex, string message, params object[] args)
        {
            this.logger.Error(ex, message, args);
        }

        public void Error(string format, params object[] args)
        {
            this.logger.Error(format, args);
        }
    }
}
