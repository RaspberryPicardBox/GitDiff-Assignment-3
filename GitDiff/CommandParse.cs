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
                try
                {
                    HelpCommand.help(words[1]);
                }
                catch (IndexOutOfRangeException)
                {
                    HelpCommand.help(words[0]);
                }
            }
            else if (words[0] == "diff")
            {
                List<List<string[]>> contents = new List<List<string[]>>();
                try
                {
                    contents = FileRead.Read(words[1], words[2]);
                }
                catch (IndexOutOfRangeException)
                {
                    UnknownCommand.unknownArgument("diff");
                }
                catch (NullReferenceException)
                {
                    UnknownCommand.errorArgument("diff");
                }
                Diff.Difference(contents);
            }
            else if (words[0] == "debug")
            {
                List<List<string[]>> contents = new List<List<string[]>>();
                try
                {
                    contents = FileRead.Read("test1.txt", "test2.txt");
                }
                catch (IndexOutOfRangeException)
                {
                    UnknownCommand.unknownArgument("diff");
                }
                catch (NullReferenceException)
                {
                    UnknownCommand.errorArgument("diff");
                }
                Diff.Difference(contents);
            }
            else if (words[0] == "quit")
            {
                Console.WriteLine("Exiting the console...");
                Environment.Exit(0);
            }
            else if (words[0] == "" || words[0] == " ")
            {
                Console.WriteLine("");
            }
            else
            {
                UnknownCommand.unknownCommand(words[0]);
            }
        }
    }
}
