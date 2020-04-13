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
                Console.WriteLine("'help' displays information about how to use a specific command.\nFor instance, 'help diff' shows how to use diff.");
            }
            else if (command == "diff")
            {
                Console.WriteLine("'diff' returns the difference between two files.\nFor intance, 'diff fileOne.txt fileTwo.txt' will return the differences between those two files.\n'diff' takes at least two arguments.");
            }
            else if (command == "quit")
            {
                Console.WriteLine("'quit' will quit from the program.\nFor instance, 'quit' will close the console window.");
            }
            else
            {
                Console.WriteLine($"{command} not recognised. Try using 'help', 'diff' or 'quit'.");
            }
        }
    }
}
