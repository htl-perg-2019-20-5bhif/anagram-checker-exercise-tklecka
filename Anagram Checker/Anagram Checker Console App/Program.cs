using System;
using System.Collections.Generic;

namespace Anagram_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            AnagramCheckerLib agLib = new AnagramCheckerLib(@"Dict.csv");
            //TODO args
        }

        public static void CheckAnagram(AnagramCheckerLib agLib, string w1, string w2)
        {
            Boolean isAnagram = agLib.CheckAnagram(w1, w2);
            if (isAnagram)
            {
                Console.WriteLine("\"" + w1 + "\" and \"" + w2 + "\" are anagrams");
            }
            else
            {
                Console.WriteLine("\"" + w1 + "\" and \"" + w2 + "\" are no anagrams");
            }
        }

        public static void GetKnownAnagram(AnagramCheckerLib agLib, string word)
        {
            Anagram ag = agLib.GetKnownAnagram(word);
            if (ag != null)
            {
                Console.WriteLine(ag.W1 + "\n" + ag.W2);
            }
            else
            {
                Console.WriteLine("No known anagrams found");
            }
        }

        public static void GenAnagrams(AnagramCheckerLib agLib, string word)
        {
            IEnumerable<string> list = agLib.GeneratePermutations(word);
            foreach (string lw in list)
            {
                Console.Write(lw + " ");
            }
            Console.WriteLine();
        }
    }
}
