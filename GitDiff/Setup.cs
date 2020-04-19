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
            logLine.logCreate();
            Output.writeOut("----- C# Git Diff Implementation -----");
            Output.writeOut("Input 'help' for directions on how to use.");
        }

    }
}
