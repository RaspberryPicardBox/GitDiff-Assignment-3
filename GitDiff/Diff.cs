using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitDiff
{
    class Diff
    {
        public static void Difference(List<List<string[]>> fileContents) //Take the list of lines of text (from both files)
        {
            List<string[]> One = new List<string[]>(); //Create new lists for both seperate files
            List<string[]> Two = new List<string[]>();

            bool commence = true; //Use a flag to prevent unnecessary output if inputs are invalid

            if (fileContents == null)
            {
                commence = false; //If the content isn't there, don't commensce
            }
            else if (fileContents.Count > 0)
            {
                One = fileContents[0]; //If the content is there, split it into the two seperate files
                Two = fileContents[1];
            }

            if (commence == true)
            {
                List<List<string>> linesOne = new List<List<string>>(); //Make some new lists for the lines of text
                List<List<string>> linesTwo = new List<List<string>>();
                int maxLines = 0; //And a variable to hold the max number of lines in the two

                foreach (string[] list in One)
                {
                    foreach (string line in list)
                    {
                        List<string> words = new List<string>(line.Split(" ")); //For each line split them into their words
                        linesOne.Add(words); //And add them to the lists
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
                // ---Equalise Length of Files---
                if (linesOne.Count > linesTwo.Count)
                {
                    maxLines = linesOne.Count; //Assigning the maxLines to the number of lines in the biggets file.
                    linesTwo.Add(new List<string>()); //Add a new empty line to prevent indexing errors when comparing to the end of the list + 1
                }
                else if (linesTwo.Count > linesOne.Count)
                {
                    maxLines = linesTwo.Count;
                    linesOne.Add(new List<string>());
                }
                else
                {
                    maxLines = linesOne.Count; //If neither are larger, just use linesOne
                }

                Output.writeOut("\nFile One:");

                for (int i = 0; i < linesOne.Count; i += 1)
                {
                    for (int j = 0; j < linesOne[i].Count; j += 1)
                    {
                        Output.Write($"{linesOne[i][j]} "); //Write out the content of fileOne
                    }
                }

                Output.writeOut("\n\nFile Two:");

                for (int i = 0; i < linesTwo.Count; i += 1)
                {
                    for (int j = 0; j < linesTwo[i].Count; j += 1)
                    {
                        Output.Write($"{linesTwo[i][j]} "); //And fileTwo
                    }
                }

                Output.writeOut("\n\n----------\n");

                for (int i = 0; i < maxLines; i += 1) //For every line in the files
                {
                    Output.Write($"\n>: [Output] Line {i} "); //Write the line number
                    IEnumerable<string> differencesTwo = linesTwo[i].Except(linesOne[i]); //Find the differences between the lines in the two text files
                    IEnumerable<string> differencesOne = linesOne[i].Except(linesTwo[i]);

                    if (linesOne[i].Count < linesTwo[i].Count) //If one of the lines is smaller than the otehr
                    {
                        for (int q = linesOne[i].Count; q < linesTwo[i].Count; q++)
                        {
                            linesOne[i].Add(""); //Add empty strings onto them to make them equal length.
                        }
                    }
                    else if (linesTwo[i].Count < linesOne[i].Count)
                    {
                        for (int q = linesTwo[i].Count; q < linesOne[i].Count; q++)
                        {
                            linesTwo[i].Add("");
                        }
                    }

                    linesOne[i].Add(""); //And add an extra to prevent over-indexing like before
                    linesTwo[i].Add("");

                    for (int j = 0; j < linesOne[i].Count; j += 1) //For every word in the line
                    {
                        if (linesOne[i][j] == linesTwo[i][j])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Output.Write($"{linesOne[i][j]} "); //If theyre the same just output them
                        }
                        else if (linesTwo[i][j] == "")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Output.Write($"{linesOne[i][j]} "); //If there's nothing in fileTwo (it's gotten to the end), keep writing fileOne
                        }
                        else if (linesOne[i][j] == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Output.Write($"{linesTwo[i][j]} "); //If fileOne has reached the end, keep writing fileTwo in green (as it is an addition)
                        }
                        else if (linesOne[i][j] != linesTwo[i][j]) //If theyre not the same
                        {
                            if (differencesTwo.Contains(linesTwo[i][j])) //If the word is different to fileTwo
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Output.writeOut($"{linesTwo[i][j]} "); //It was added, so write it in green
                                if (linesTwo[i][j + 1] != linesOne[i][j]) //But if the next word isn't the same as it, it's been replaced and not inserted beforehand
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Output.Write($"{linesOne[i][j]} "); //So also say that the current word was taken away (replaced)
                                }
                            }
                            else if (differencesOne.Contains(linesOne[i][j])) //If the word is different to fileOne
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Output.Write($"{linesOne[i][j]} "); //It's been taken away, so write it in red
                            }
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White; //Reset the terminal to white
                Output.writeOut(" "); //And add a spare empty line to keep the console neat.
            }  
        }
    }
}
