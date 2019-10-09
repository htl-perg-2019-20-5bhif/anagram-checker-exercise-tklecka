using System;
using System.Collections.Generic;

namespace Anagram_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            AnagramCheckerLib agLib = new AnagramCheckerLib("");
            if (args[0].Equals("check"))
            {
                if (args.Length == 3)
                {
                    CheckAnagram(agLib, args[1], args[2]);
                } else
                {
                    Console.WriteLine("Use 'check' 'word1' 'word2'");
                }
            } else if(args[0].Equals("getKnown"))
            {
                if (args.Length == 3)
                {
                    agLib.dictfilename = args[1];
                    GetKnownAnagram(agLib, args[2]);
                }
                else
                {
                    Console.WriteLine("Use 'getKnown' 'Path' 'word'");
                }
            } else if (args[0].Equals("getPermutations"))
            {
                if (args.Length == 2)
                {
                    GenAnagrams(agLib, args[1]);
                }
                else
                {
                    Console.WriteLine("Use 'getPermutations' 'word'");
                }
            } else
            {
                Console.WriteLine("Use 'getPermutations' || 'getKnown' || 'check'");
            }
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
