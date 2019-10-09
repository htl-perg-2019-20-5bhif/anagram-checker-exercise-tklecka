using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Anagram_Checker.Controllers
{
    public class Word
    {
        [Required]
        public string W1 { get; set; }

        [Required]
        public string W2 { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class AnagramController : ControllerBase
    {
        private readonly IAnagramChecker agLib;
        private readonly ILogger<AnagramController> logger;

        public AnagramController(IAnagramChecker agLib, ILogger<AnagramController> logger)
        {
            this.agLib = agLib;
            this.logger = logger;
        }

        [HttpGet]
        [Route("/api/checkAnagram")]
        public ActionResult<string> GetCheckAnagrams([FromBody]Word w)
        {
            if (w.W1.Equals(String.Empty) || w.W2.Equals(String.Empty))
            {
                return BadRequest();
            }
            if (agLib.CheckAnagram(w.W1, w.W2))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/api/getKnownAnagrams")]
        public ActionResult<string> GetKnownAnagrams([FromQuery] string w)
        {
            if (w is null)
            {
                return BadRequest();
            }
            Anagram anagram = agLib.GetKnownAnagram(w);
            if (anagram == null)
            {
                logger.LogWarning("No anagrams found for " + w);
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
