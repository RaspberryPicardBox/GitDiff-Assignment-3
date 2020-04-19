using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Output
    {
        public static void writeOut(string message)
        {
            var logLine = new Logger.logFile();
            Console.WriteLine(message);
            logLine.log(message, "Output");
        }
        public static void Write(string message)
        {
            var logLine = new Logger.logFile();
            Console.Write(message);
            logLine.log(message, "Output");
        }
    }
}
