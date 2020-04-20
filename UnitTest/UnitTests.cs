using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitDiff;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CommandParseTests() //Should fail, as nonesense inputs should be handled gracefully
        {
            CommandParse parser = new CommandParse();
            string[] userInput = new string[5];
            userInput[0] = "help";
            userInput[1] = "diff test1.txt test2.txt";
            userInput[2] = "debug";
            userInput[3] = "quit";
            userInput[4] = "nonesenseWi|hSp3cialCh@rs";

            foreach (string input in userInput)
            {
                Assert.ThrowsException<System.Exception>(() => parser.parse(input));
            }
        }
        [TestMethod]
        public void FileReadTests() //Should fail, as invalid file names should be handled gracefully
        {
            string[] inputOne = new string[2];
            string[] inputTwo = new string[2];
            inputOne[0] = "test1.txt";
            inputOne[1] = "test2.txt";
            inputTwo[0] = "noFile.txt";
            inputTwo[1] = "namedThis.txt";
            
            for (int i = 0; i < inputOne.Length; i++)
            {
                Assert.ThrowsException<System.Exception>(() => FileRead.Read(inputOne[i], inputTwo[i]));
            }
        }
        [TestMethod]
        public void DiffTests() //Should fail, as fileRead should handle invalid file names
        {
            List<List<string[]>> contents = new List<List<string[]>>();
            List<List<string[]>> invalidContents = new List<List<string[]>>();
            contents = FileRead.Read("test1.txt", "test2.txt");
            invalidContents = FileRead.Read("notA.txt", "realFile.txt");

            Assert.ThrowsException<System.Exception>(() => Diff.Difference(contents));
            Assert.ThrowsException<System.Exception>(() => Diff.Difference(invalidContents));
        }
    }
}
