using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class UserInput
    {
        public string In()
        {
            Output.Write(">: [Input] "); //Make the output seem console clearer by showing when input is necessary
            string UserInput = Console.ReadLine();
            return UserInput.ToLower(); //Make all input lower-case to remove the need for case sensitivity
        }
    }
}
