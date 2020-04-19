using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Output
    {
        //An integrated alternative to "Console.Write" which includs logging.
        public static void writeOut(string message) //Writes to a new line
        {
            var logLine = new Logger.logFile();
            Console.WriteLine(message);
            logLine.log(message, "Output"); //And logs the message
        }
        public static void Write(string message) //Write to the same line.
        {
            var logLine = new Logger.logFile();
            Console.Write(message);
            logLine.log(message, "Output");
        }
    }
}
