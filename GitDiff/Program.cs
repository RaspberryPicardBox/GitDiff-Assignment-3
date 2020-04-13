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

            Setup.Start();
            while (true)
            {
                string command = input.In();
                commandParse.parse(command);
            }
        }
    }
}
