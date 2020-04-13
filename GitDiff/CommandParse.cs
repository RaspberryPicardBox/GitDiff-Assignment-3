using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class CommandParse
    {
        public void parse(string userInput)
        {
            var words = userInput.Split(" ");

            if (words[0] == "help")
            {
                HelpCommand.help(words[0]);
            }
            else if (words[0] == "diff")
            {
                Console.WriteLine("Not Implemented.");
            }
            else if (words[0] == "quit")
            {
                Console.WriteLine("QUIT");
            }
            else
            {
                UnknownCommand.unknownCommand(words[0]);
            }
        }
    }
}
