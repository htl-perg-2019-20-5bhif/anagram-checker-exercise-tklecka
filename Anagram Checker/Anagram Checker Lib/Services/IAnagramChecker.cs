using System;
using System.Collections.Generic;

namespace Anagram_Checker
{
    public interface IAnagramChecker
    {
        public Boolean CheckAnagram(string firstString, string secondString);
        public Anagram GetKnownAnagram(string word);
        public IEnumerable<string> GeneratePermutations(string word);
    }
}