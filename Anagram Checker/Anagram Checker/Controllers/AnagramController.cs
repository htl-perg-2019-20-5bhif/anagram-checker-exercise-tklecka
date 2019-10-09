using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Anagram_Checker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnagramController : ControllerBase
    {
        [HttpGet]
        [Route("/api/checkAnagram")]
        public ActionResult<string> GetCheckAnagrams([FromBody]string w1)
        {
            string w2 = "asd";
            if (w1.Equals(String.Empty) || w2.Equals(String.Empty))
            {
                return BadRequest();
            }
            AnagramCheckerLib agLib = new AnagramCheckerLib(@"../Dict.csv");
            if (agLib.CheckAnagram(w1, w2))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/api/getKnownAnagrams")]
        public ActionResult<string> GetKnownAnagrams([FromQuery] string w)
        {
            if (w is null)
            {
                return BadRequest();
            }
            AnagramCheckerLib agLib = new AnagramCheckerLib(@"../Dict.csv");
            Anagram anagram = agLib.GetKnownAnagram(w);
            if (anagram == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(anagram);
            }
        }

        [HttpGet]
        [Route("/api/getPermutations")]
        public ActionResult<string> GetPermutations([FromQuery] string w)
        {
            if (w is null)
            {
                return BadRequest();
            }
            AnagramCheckerLib agLib = new AnagramCheckerLib(@"../Dict.csv");
            IEnumerable<string> anagrams = agLib.GeneratePermutations(w);
            if (anagrams != null)
            {
                return Ok(anagrams);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
