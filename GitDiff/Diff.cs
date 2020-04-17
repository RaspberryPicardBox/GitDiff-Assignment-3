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

            if (fileContents.Count > 0)
            {
                One = fileContents[0];
                Two = fileContents[1];
            }
            else
            {
                
            }

            List<List<string>> linesOne = new List<List<string>>();
            List<List<string>> linesTwo = new List<List<string>>();

            foreach(string[] list in One)
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

            Console.WriteLine("File One:");

            for (int i = 0; i < linesOne.Count; i += 1)
            {
                for (int j = 0; j < linesOne[i].Count; j += 1)
                {
                    Console.Write($"{linesOne[i][j]} ");
                }
            }

            Console.WriteLine("\n\nFile Two:");

            for (int i = 0; i < linesTwo.Count; i += 1)
            {
                for (int j = 0; j < linesTwo[i].Count; j += 1)
                {
                    Console.Write($"{linesTwo[i][j]} ");
                }
            }

            Console.WriteLine("\n\n----------\n");

            for (int i = 0; i < linesOne.Count; i += 1)
            {
                IEnumerable<string> differencesTwo = linesTwo[i].Except(linesOne[i]);
                IEnumerable<string> differencesOne = linesOne[i].Except(linesTwo[i]);

                for (int j = 0; j < linesOne[i].Count; j += 1)
                {
                    if (differencesOne.Contains(linesOne[i][j]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"-{linesOne[i][j]} ");
                    }
                    else if (differencesTwo.Contains(linesOne[i][j]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"+{linesOne[i][j]} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{linesOne[i][j]} ");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
        }
    }
}
