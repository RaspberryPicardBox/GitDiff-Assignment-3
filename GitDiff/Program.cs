using System;
using System.Collections.Generic;

namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput input = new UserInput();
            CommandParse commandParse = new CommandParse();
            var logLine = new Logger.logFile();

            Setup.Start();
            while (true)
            {
                string command = input.In();
                logLine.log(command, "Input");
                commandParse.parse(command);
            }
        }
    }
}
