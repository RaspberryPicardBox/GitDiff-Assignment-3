using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Diff
    {
        public static void Difference(List<List<string>> fileContents)
        {
            List<string> One = fileContents[0];
            List<string> Two = fileContents[1];

            foreach (string word in One)
            {
                Console.WriteLine(word);
            }
        }
    }
}
