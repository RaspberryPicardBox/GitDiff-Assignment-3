using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class HelpCommand
    {
        public static void help(string command)
        {
            if (command == "help")
            {
                Output.writeOut("'help' displays information about how to use a specific command.\nFor instance, 'help diff' shows how to use diff.");
            }
            else if (command == "diff")
            {
                Output.writeOut("'diff' returns the difference between two files.\nFor intance, 'diff fileOne.txt fileTwo.txt' will return the differences between those two files.\n'diff' takes at least two arguments.");
            }
            else if (command == "quit")
            {
                Output.writeOut("'quit' will quit from the program.\nFor instance, 'quit' will close the console window.");
            }
            else
            {
                UnknownCommand.unknownCommand(command); //If the command isn't listed in the help command, raise an error.
            }
        }
    }
}
