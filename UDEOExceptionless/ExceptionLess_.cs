using Exceptionless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UDEOExceptionless
{
    public class ExceptionLess_
    {

        public void info(string string1)
        {

            // Submit logs
            ExceptionlessClient.Default.SubmitLog("Logging made easy");

            // You can also specify the log source and log level.
            // We recommend specifying one of the following log levels: Trace, Debug, Info, Warn, Error
            ExceptionlessClient.Default.SubmitLog(typeof(InvalidProgramException).FullName, "This is so easy", "Info");
            ExceptionlessClient.Default.CreateLog(typeof(InvalidProgramException).FullName, "This is so easy", "Info").AddTags("CiudadDelDollar").Submit();

        }

        public void error(string string1)
        {
            ExceptionlessClient.Default.CreateLog(typeof(InvalidProgramException).FullName, "This is so easy", "Error").AddTags("CiudadDelDollar").Submit();
        }
    }
}