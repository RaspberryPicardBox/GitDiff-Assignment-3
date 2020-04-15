using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Diff
    {
        public static void Difference(List<List<string[]>> fileContents)
        {
            List<Differences> differences = new List<Differences>();

            List<string[]> One = fileContents[0];
            List<string[]> Two = fileContents[1];

            int indexLine = 0;
            int indexWord = 0;
            int indexChar = 0;

            foreach (string[] line in Two)
            {
                foreach (string word in line)
                {
                    foreach (char character in word)
                    {
                        if (character != Two[indexLine][indexWord][indexChar])
                        {
                            Differences difference = new Differences(character.ToString(), indexLine, indexWord, indexChar);
                            differences.Add(difference);
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
