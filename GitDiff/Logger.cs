using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Logger
    {
        private string path = "../../../../Files/log.txt";
        public class logFile : Logger
        {
            public void logCreate()
            {
                System.IO.File.WriteAllText(@path, "");
            }
            public void log(string data, string type)
            {
                System.IO.File.AppendAllText(@path, $"{type}: {data}\n");
            }
        }
    }
}
