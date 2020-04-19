using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class UnknownCommand 
    {
        //A broad class for all kinds of errors
        public static void unknownCommand(string command)
        {
            Output.writeOut($"'{command}' is an unknown command. Please use 'help'."); //If the command isn't recognised
        }
        public static void unknownArgument(string command)
        {
            Output.writeOut($"{command} takes arguments. Please use 'help'."); //If the command takes arguments
        }
        public static void errorArgument(string command)
        {
            if (command == "diff") //This can be tailored to each type of command for varies responses.
            {
                Output.writeOut("Diff takes text files as arguments. Please use 'help'."); //Or if the command takes specific arguments
            }
        }
    }
}
