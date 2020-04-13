using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Diff
    {
        public static void Difference(List<List<string[]>> fileContents)
        {
            List<char> differences = new List<char>();

            List<string[]> One = fileContents[0];
            List<string[]> Two = fileContents[1];

            int indexLine = 0;
            int indexWord = 0;
            int indexChar = 0;

            foreach (string[] line in One)
            {
                foreach (string word in line)
                {
                    foreach (char character in word)
                    {
                        if (character != Two[indexLine][indexWord][indexChar])
                        {
                            differences.Add(Two[indexLine][indexWord][indexChar]);
                            //Make an object called "difference" with these ^^^ three as paramaters
                            //and then add each object to a list. Can then call on each paramater later as output.
                            //Similar to EUCalc.
                        }
                        indexChar++;
                    }
                    indexWord++;
                }
                indexLine++;
            }
        }
    }
}
