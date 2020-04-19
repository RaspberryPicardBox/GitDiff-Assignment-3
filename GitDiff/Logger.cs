using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Logger
    {
        private string path = "../../../../Files/log.txt"; //Define the log file path. Useful if the position or file type needs changing.
        public class logFile : Logger
        {
            public void logCreate() //Create a new log file, or overwrite the last one
            {
                System.IO.File.WriteAllText(@path, "");
            }
            public void log(string data, string type) //Append new data to the current file
            {
                System.IO.File.AppendAllText(@path, $"{type}: {data}\n"); //We take the data type (input, output etc) and the content.
            }
        }
    }
}
