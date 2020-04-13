using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class UserInput
    {
        public string In()
        {
            Console.Write(">: [Input] ");
            string UserInput = Console.ReadLine();
            return UserInput.ToLower();
        }
    }
}
