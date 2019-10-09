using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Anagram_Checker
{
    public class AnagramCheckerLib : IAnagramChecker
    {
        List<Anagram> dict = new List<Anagram>();
        private readonly string dictfilename;
        public AnagramCheckerLib(string dictfilename)
        {
            this.dictfilename = dictfilename;
        }

        public Boolean CheckAnagram(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
            {
                return false;
            }

            var s1Array = firstString.ToLower().ToCharArray();
            var s2Array = secondString.ToLower().ToCharArray();

            Array.Sort(s1Array);
            Array.Sort(s2Array);

            firstString = new string(s1Array);
            secondString = new string(s2Array);

            if (firstString.Equals(secondString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Anagram GetKnownAnagram(string word)
        {
            GetAnagramsFromDictionaryAsync();
            foreach (Anagram anagram in dict)
            {
                if (anagram.W1.ToLower().Equals(word.ToLower()) || anagram.W2.ToLower().Equals(word.ToLower()))
                {
                    return anagram;
                }
            }
            return null;
        }

        private async Task<string> ReadDictAsync()
        {
            string dictContent;
            try
            {
                dictContent = await System.IO.File.ReadAllTextAsync(dictfilename);
            }
            catch (FileNotFoundException ex)
            {
                throw (ex);
            }

            return dictContent;
        }

        private async void GetAnagramsFromDictionaryAsync()
        {
            try
            {
                string dictionary = await ReadDictAsync();
                string[] anagrams = dictionary.Replace("\r", string.Empty).Split("\n");
                foreach (string pair in anagrams)
                {
                    string[] anagramsSplited = pair.Split(";");
                    if (anagramsSplited.Length >= 2)
                    {
                        dict.Add(new Anagram(anagramsSplited[0], anagramsSplited[1]));
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw (ex);
            }
        }

        public IEnumerable<string> GeneratePermutations(string word)
        {
            char[] charArray = word.ToLower().ToCharArray();
            int n = charArray.Length;
            List<string> permutations = new List<string>();

            GenerateHeapPermutations(n, charArray, permutations);
            return permutations;
        }

        private void GenerateHeapPermutations(int n, char[] charArray, List<string> sList)
        {
            if (n == 1)
            {
                sList.Add(new string(charArray));
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    GenerateHeapPermutations(n - 1, charArray, sList);

                    int indexToSwapWithLast = (n % 2 == 0 ? i : 0);
                    // swap the positions of two characters
                    var temp = charArray[indexToSwapWithLast];
                    charArray[indexToSwapWithLast] = charArray[n - 1];
                    charArray[n - 1] = temp;
                }

                GenerateHeapPermutations(n - 1, charArray, sList);
            }
        }
    }
}
