using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Setup
    {
        public static void Start()
        {
            var logLine = new Logger.logFile();
            logLine.logCreate(); //Create or overwrite the log file to be used during runtime
            Output.writeOut("----- C# Git Diff Implementation -----");
            Output.writeOut("Input 'help' for directions on how to use."); //A few niceties to help with console usability.
        }

    }
}
