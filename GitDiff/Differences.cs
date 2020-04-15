using System;
using System.Collections.Generic;
using System.Text;

namespace GitDiff
{
    class Differences
    {
        public string letter_ { get; set; }
        public int indexLine_ { get; set; }
        public int indexWord_ { get; set; }
        public int indexChar_ { get; set; }

        public Differences(string letter, int indexLine, int indexWord, int indexChar)
        {
            letter_ = letter;
            indexLine_ = indexLine;
            indexWord_ = indexWord;
            indexChar_ = indexChar;
        }
    }
}
