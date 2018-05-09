using System;
using log4net;

namespace CrossCutting.Logger.Logging
{
    public  class Logger : ILogger
    {
        private  ILog _log;
        public  ILog Log
        {
            get
            {
                if (_log == null)
                    _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                return _log;
            }
        }

        public  void LogInfo(string message)
        {
            Log.Info(message);
        }
        public  void LogInfo(string message, Exception exception)
        {
            Log.Info(message, exception);
        }

        public  void LogError(string message)
        {
            Log.Error(message);
        }
        public  void LogError(string message, Exception exception)
        {
            Log.Error(message, exception);
        }

        public  void LogFatal(string message)
        {
            Log.Fatal(message);
        }
        public  void LogFatal(string message, Exception exception)
        {
            Log.Fatal(message, exception);
        }

        public  void LogWarn(string message)
        {
            Log.Warn(message);
        }
        public  void LogWarn(string message, Exception exception)
        {
            Log.Warn(message, exception);
        }

        public  void LogDebug(string message)
        {
            Log.Debug(message);
        }
        public  void LogDebug(string message, Exception exception)
        {
            Log.Debug(message, exception);
        }
    }
}
