using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class FileRead
    {
        public static List<List<string[]>> Read(string fileOne, string fileTwo)
        {
            if (fileOne.Contains(".txt") && fileTwo.Contains(".txt"))
            {
                List<string[]> contentsOne = new List<string[]>();
                List<string[]> contentsTwo = new List<string[]>();
                List<List<string[]>> contentsAll = new List<List<string[]>>();
                try
                {
                    string[] contentsFileOne = System.IO.File.ReadAllLines($@"../../../../Files/{fileOne}");
                    contentsOne.Add(contentsFileOne);
                }
                catch (Exception)
                {
                    Output.writeOut($"File name {fileOne} is invalid.");
                    return null;
                }
                try
                {
                    string[] contentsFileTwo = System.IO.File.ReadAllLines($@"../../../../Files/{fileTwo}");
                    contentsTwo.Add(contentsFileTwo);
                }
                catch (Exception)
                {
                    Output.writeOut($"File name {fileTwo} is invalid.");
                    return null;
                }
                contentsAll.Add(contentsOne);
                contentsAll.Add(contentsTwo);
                return contentsAll;
            }
            else
            {
                Output.writeOut($"File names don't contain .txt...");
                return null;
            }
            
        }
    }
}
