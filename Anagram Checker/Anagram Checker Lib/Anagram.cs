using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram_Checker
{
    public class Anagram
    {
        public string W1 { get; set; }
        public string W2 { get; set; }

        public Anagram(string w1, string w2)
        {
            this.W1 = w1;
            this.W2 = w2;
        }
    }
}
