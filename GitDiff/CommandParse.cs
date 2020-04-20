using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    public class CommandParse
    {
        public void parse(string userInput) //Take the user's input as an argument
        {
            var words = userInput.Split(" "); //And split it into the seperate words

            if (words[0] == "help") //Check what the first (command) word is
            {
                try
                {
                    HelpCommand.help(words[1]); //If there's a command afterwards, for specific help, attempt to use that
                }
                catch (IndexOutOfRangeException)
                {
                    HelpCommand.help(words[0]); //Else use "help" as the help argument
                }
            }
            else if (words[0] == "diff")
            {
                List<List<string[]>> contents = new List<List<string[]>>(); //Create a new empty string to put the file contents
                try
                {
                    contents = FileRead.Read(words[1], words[2]); //Attempt to read the files given
                }
                catch (IndexOutOfRangeException) //If only one file was given
                {
                    UnknownCommand.unknownArgument("diff"); //Raise an error
                    contents = FileRead.Read("nullOne.txt", "nullTwo.txt"); //Proceed with empty files to prevent later issues
                }
                catch (NullReferenceException) //If the tile is not a readable file
                {
                    UnknownCommand.errorArgument("diff");
                    contents = FileRead.Read("nullOne.txt", "nullTwo.txt");
                }
                Diff.Difference(contents); //Find the difference using the contents
            }
            else if (words[0] == "debug") //Debug allows for quick testing of the diff command
            {
                List<List<string[]>> contents = new List<List<string[]>>();
                try
                {
                    contents = FileRead.Read("test1.txt", "test2.txt"); //The only two text files used are the test files.
                }
                catch (IndexOutOfRangeException)
                {
                    UnknownCommand.unknownArgument("diff");
                }
                catch (NullReferenceException)
                {
                    UnknownCommand.errorArgument("diff");
                }
                Diff.Difference(contents); //Custom files are ignored.
            }
            else if (words[0] == "quit")
            {
                Output.writeOut("Exiting the console...");
                Environment.Exit(0); //Gracefully exit the console.
            }
            else if (words[0] == "" || words[0] == " ") //If the user accidentally enters nothing
            {
                Console.WriteLine(""); //Don't throw an error, just ignore it and move on
            }
            else
            {
                UnknownCommand.unknownCommand(words[0]); //If nothing is recognised, raise an error.
            }
        }
    }
}
