using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class FileRead
    {
        public static List<List<string[]>> Read(string fileOne, string fileTwo)
        {
            if (fileOne.Contains(".txt") && fileTwo.Contains(".txt")) //Check to make sure both are text files
            {
                List<string[]> contentsOne = new List<string[]>(); //Initialise new lists
                List<string[]> contentsTwo = new List<string[]>();
                List<List<string[]>> contentsAll = new List<List<string[]>>(); //And one for the contents of both combined
                try //Attempt to read the content of the file
                {
                    string[] contentsFileOne = System.IO.File.ReadAllLines($@"../../../../Files/{fileOne}"); //Only looking at this particular path
                    contentsOne.Add(contentsFileOne);
                }
                catch (Exception) //And catch the exception if something is wrong, such as the file not existing or being corrupt
                {
                    Output.writeOut($"File name {fileOne} is invalid.");
                    return null; //Return something to satisfy the return state
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
                return contentsAll; //Contents all is returned with two lists of the file's contents
            }
            else
            {
                Output.writeOut($"File names don't contain .txt...");
                return null;
            }
            
        }
    }
}
