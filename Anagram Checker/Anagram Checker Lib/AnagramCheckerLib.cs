using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Anagram_Checker_Lib
{
    public class AnagramCheckerLib
    {
        private readonly string dictfilename;
        private List<string> dict;
        public AnagramCheckerLib(string dictfilename)
        {
            this.dictfilename = dictfilename;
        }

        public Boolean CheckAnagram(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
                return false;

            var s1Array = firstString.ToLower().ToCharArray();
            var s2Array = firstString.ToLower().ToCharArray();

            Array.Sort(s1Array);
            Array.Sort(s2Array);

            firstString = new string(s1Array);
            secondString = new string(s2Array);

            return firstString == secondString;
        }

        public IEnumerable<string> GetKnownAnagram()
        {

            return null;
        }

        public async Task<string> ReadDictAsync()
        {
            string dictContent;
            try
            {
                dictContent = await System.IO.File.ReadAllTextAsync(dictfilename);
            }
            catch (FileNotFoundException ex)
            {
                //TODO Log ex
                throw;
            }

            return dictContent;
        }



        public void GetDict(string dictText)
        {

        }

    }
}
