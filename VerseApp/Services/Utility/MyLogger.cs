using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace VerseApp.Services.Utility
{
    public class MyLogger
    {
        private static MyLogger instance;
        private static Logger logger;

        private MyLogger()
        {
        }

        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myApp").Debug(message);
            }
            else
            {
                GetLogger("myApp").Debug(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myApp").Info(message);
            }
            else
            {
                GetLogger("myApp").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myApp").Warn(message);
            }
            else
            {
                GetLogger("myApp").Warn(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myApp").Error(message);
            }
            else
            {
                GetLogger("myApp").Error(message, arg);
            }
        }
    }
}