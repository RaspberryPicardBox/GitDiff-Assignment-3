using System;
using System.Collections.Generic;

// A C# implementation of the Git Diff command.
// Takes two files as an input and outputs the differences between the two.

namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput input = new UserInput();
            CommandParse commandParse = new CommandParse();
            var logLine = new Logger.logFile(); //Instantiate the loggin class, as we have an input present.

            Setup.Start(); //Call one-time run setup class to make the console pretty.
            while (true)
            {
                string command = input.In(); //Take the user's input
                logLine.log(command, "Input"); //Log it
                commandParse.parse(command); //And decide the action to take
            }
        }
    }
}
