using System;


namespace CrossCutting.Logger.Logging
{
    public interface ILogger
    {

        void LogInfo(string message);


        void LogInfo(string message, Exception exception);


        void LogError(string message);


        void LogError(string message, Exception exception);


        void LogFatal(string message);


        void LogFatal(string message, Exception exception);


        void LogWarn(string message);


        void LogWarn(string message, Exception exception);


        void LogDebug(string message);


        void LogDebug(string message, Exception exception);
    }
}
