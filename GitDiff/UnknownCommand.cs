﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class UnknownCommand
    {
        public static void unknownCommand(string command)
        {
            Console.WriteLine($"'{command}' is an unknown command. Please use 'help'.");
        }
        public static void unknownArgument(string command)
        {
            Console.WriteLine($"{command} takes arguments. Please use 'help'.");
        }
    }
}
