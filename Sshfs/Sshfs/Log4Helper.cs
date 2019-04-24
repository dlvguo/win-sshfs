using log4net;
using System;

namespace Sshfs
{
    public enum LogType
    {
        INFO = 0,
        DEBUG,
        ERROR,
        WARN,
        FATAL
    }

    public class LogHelper
    {
        private const string DEBUG_LOGGER_NAME = "LogDebug";
        private const string ERROR_LOGGER_NAME = "LogError";
        private const string WARN_LOGGER_NAME = "LogWarn";
        private const string INFO_LOGGER_NAME = "LogInfo";
        private const string FATAL_LOGGER_NAME = "LogFatal";

        private static ILog GetLogger(LogType type)
        {
            ILog log = null;
            switch (type)
            {
                case LogType.DEBUG:
                    log = LogManager.GetLogger(DEBUG_LOGGER_NAME);
                    break;
                case LogType.ERROR:
                    log = LogManager.GetLogger(ERROR_LOGGER_NAME);
                    break;
                case LogType.FATAL:
                    log = LogManager.GetLogger(FATAL_LOGGER_NAME);
                    break;
                case LogType.INFO:
                    log = LogManager.GetLogger(INFO_LOGGER_NAME);
                    break;
                case LogType.WARN:
                    log = LogManager.GetLogger(WARN_LOGGER_NAME);
                    break;
            }
            if (log == null)
                throw new ArgumentNullException("LogType不存在" + type);
            return log;
        }
        //记录Debug日志信息
        public static void WriteDebug(object message)
        {
            ILog debugLog = GetLogger(LogType.DEBUG);
            debugLog.Debug(message);
        }
        public static void WriteDebug(object message, Exception exception)
        {
            ILog debugLog = GetLogger(LogType.DEBUG);
            debugLog.Debug(message, exception);
        }
        //记录Error日志信息
        public static void WriteError(string message)
        {
            ILog errorLog = GetLogger(LogType.ERROR);
            errorLog.Error(message);
        }
        public static void WriteError(object message, Exception exception)
        {
            ILog errorLog = GetLogger(LogType.ERROR);
            errorLog.Error(message, exception);
        }
        //记录Info日志信息
        public static void WriteInfo(object message)
        {
            ILog infoLog = GetLogger(LogType.INFO);
            infoLog.Info(message);
        }
        public static void WriteInfo(object message, Exception exception)
        {
            ILog infoLog = GetLogger(LogType.INFO);
            infoLog.Info(message, exception);
        }
        //记录Warn日志信息
        public static void WriteWarn(object message)
        {
            ILog warnLog = GetLogger(LogType.WARN);
            warnLog.Warn(message);
        }
        public static void WriteWarn(object message, Exception exception)
        {
            ILog warnLog = GetLogger(LogType.WARN);
            warnLog.Warn(message, exception);
        }
        //记录Fatal日志信息
        public static void WriteFatal(object message)
        {
            ILog fatalLog = GetLogger(LogType.FATAL);
            fatalLog.Fatal(message);
        }
        public static void WriteFatal(object message, Exception exception)
        {
            ILog fatalLog = GetLogger(LogType.FATAL);
            fatalLog.Fatal(message, exception);
        }
    }
}