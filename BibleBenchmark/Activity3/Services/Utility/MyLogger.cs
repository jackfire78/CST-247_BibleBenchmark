using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3.Services.Utility {
    public class MyLogger : ILogger {

        //Singleton pattewrn example. Only one instanse of this class can be instanciated
        private static MyLogger instance; //singleton design pattern. Single instance of this class
        private static Logger logger;  //static variable to hold a single instance of nLog logger

        //Single design pattern - private constructor
        private MyLogger() {

        }

        //Single design pattern - this function creates and instance of the class if it has not yet been instanciated. If the class already 
        //exists in the program, then send them the reference to the original.
        public static MyLogger GetInstance() {
            if (instance == null) {
                instance = new MyLogger();
            }
            return instance;
        }

        private Logger GetLogger(string theLogger) {
            if(MyLogger.logger == null) {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }



        public void Debug(string message, string arg = null) {
            if(arg == null) {
                GetLogger("myAppLoggerRules").Debug(message);
            } else {
                GetLogger("myAppLoggerRules").Debug(message, arg);
            }
        }

        public void Error(string message, string arg = null) {
            if (arg == null) {
                GetLogger("myAppLoggerRules").Error(message);
            } else {
                GetLogger("myAppLoggerRules").Error(message, arg);
            }
        }

        public void Info(string message, string arg = null) {
            if (arg == null) {
                GetLogger("myAppLoggerRules").Info(message);
            } else {
                GetLogger("myAppLoggerRules").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null) {
            if (arg == null) {
                GetLogger("myAppLoggerRules").Warn(message);
            } else {
                GetLogger("myAppLoggerRules").Warn(message, arg);
            }
        }



    }


}