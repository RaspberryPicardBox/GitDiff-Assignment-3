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
            List<string[]> One = new List<string[]>();
            List<string[]> Two = new List<string[]>();
            if (fileContents.Count > 0)
            {
                One = fileContents[0];
                Two = fileContents[1];
            }
            else
            {
                
            }

            int indexLine = 0;
            int indexWord = 0;
            int indexChar = 0;

            int lenOne = One[0][0].Length;
            int lenTwo = Two[0][0].Length;

            if (lenOne >= lenTwo)
            {
                foreach (string[] line in One)
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
            else if (lenTwo > lenOne)
            {
                foreach (string[] line in Two)
                {
                    foreach (string word in line)
                    {
                        foreach (char character in word)
                        {
                            if (character != One[indexLine][indexWord][indexChar])
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

            foreach (Differences difference in differences)
            {
                Console.WriteLine($"Difference: {difference}");
            }
        }
    }
}
