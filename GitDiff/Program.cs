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
            bool flag = false;

            Setup.Start();
            while (flag == false)
            {
                string command = input.In();
                commandParse.parse(command);
            }
        }
    }
}
