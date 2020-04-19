using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitDiff
{
    class Diff
    {
        public static void Difference(List<List<string[]>> fileContents)
        {
            List<string[]> One = new List<string[]>();
            List<string[]> Two = new List<string[]>();

            bool commence = true;

            if (fileContents == null)
            {
                commence = false;
            }
            else if (fileContents.Count > 0)
            {
                One = fileContents[0];
                Two = fileContents[1];
            }

            if (commence == true)
            {
                List<List<string>> linesOne = new List<List<string>>();
                List<List<string>> linesTwo = new List<List<string>>();
                int maxLines = 0;

                foreach (string[] list in One)
                {
                    foreach (string line in list)
                    {
                        List<string> words = new List<string>(line.Split(" "));
                        linesOne.Add(words);
                    }
                }
                foreach (string[] list in Two)
                {
                    foreach (string line in list)
                    {
                        List<string> words = new List<string>(line.Split(" "));
                        linesTwo.Add(words);
                    }
                }

                if (linesOne.Count > linesTwo.Count)
                {
                    maxLines = linesOne.Count;
                    linesTwo.Add(new List<string>());
                }
                else if (linesTwo.Count > linesOne.Count)
                {
                    maxLines = linesTwo.Count;
                    linesOne.Add(new List<string>());
                }
                else
                {
                    maxLines = linesOne.Count;
                }

                Output.writeOut("\nFile One:");

                for (int i = 0; i < linesOne.Count; i += 1)
                {
                    for (int j = 0; j < linesOne[i].Count; j += 1)
                    {
                        Output.writeOut($"{linesOne[i][j]} ");
                    }
                }

                Output.writeOut("\n\nFile Two:");

                for (int i = 0; i < linesTwo.Count; i += 1)
                {
                    for (int j = 0; j < linesTwo[i].Count; j += 1)
                    {
                        Output.writeOut($"{linesTwo[i][j]} ");
                    }
                }

                Output.writeOut("\n\n----------\n");

                for (int i = 0; i < maxLines; i += 1)
                {
                    IEnumerable<string> differencesTwo = linesTwo[i].Except(linesOne[i]);
                    IEnumerable<string> differencesOne = linesOne[i].Except(linesTwo[i]);

                    if (linesOne[i].Count < linesTwo[i].Count)
                    {
                        for (int q = linesOne[i].Count; q < linesTwo[i].Count; q++)
                        {
                            linesOne[i].Add("");
                        }
                    }
                    else if (linesTwo[i].Count < linesOne[i].Count)
                    {
                        for (int q = linesTwo[i].Count; q < linesOne[i].Count; q++)
                        {
                            linesTwo[i].Add("");
                        }
                    }

                    linesOne[i].Add("");
                    linesTwo[i].Add("");

                    for (int j = 0; j < linesOne[i].Count; j += 1)
                    {
                        if (linesOne[i][j] == linesTwo[i][j])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Output.Write($"{linesOne[i][j]} ");
                        }
                        else if (linesTwo[i][j] == "")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Output.Write($"{linesOne[i][j]} ");
                        }
                        else if (linesOne[i][j] == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Output.Write($"{linesTwo[i][j]} ");
                        }
                        else if (linesOne[i][j] != linesTwo[i][j])
                        {
                            if (differencesTwo.Contains(linesTwo[i][j]))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Output.writeOut($"{linesTwo[i][j]} ");
                                if (linesTwo[i][j + 1] != linesOne[i][j])
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Output.Write($"{linesOne[i][j]} ");
                                }
                            }
                            else if (differencesOne.Contains(linesOne[i][j]))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Output.Write($"{linesOne[i][j]} ");
                            }
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Output.writeOut(" ");
            }  
        }
    }
}
