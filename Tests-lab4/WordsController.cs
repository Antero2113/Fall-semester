using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private WordsDictionary _wordsDictionary = new WordsDictionary();

        [HttpPost]
        public ActionResult AddWord([FromBody] string word)
        {
            _wordsDictionary.ProcessInput(word);
            return Ok();
        }

        [HttpGet("json")]
        public ActionResult<string> GetWordsJson()
        {
            return _wordsDictionary.GetJson();
        }

        [HttpPost("json")]
        public ActionResult SaveWordsJson([FromBody] string jsonString)
        {
            _wordsDictionary.LoadFromJson(jsonString);
            return Ok();
        }

        [HttpGet("xml")]
        public ActionResult<string> GetWordsXml()
        {
            return _wordsDictionary.GetXml();
        }

        [HttpPost("xml")]
        public ActionResult SaveWordsXml([FromBody] string xmlString)
        {
            _wordsDictionary.LoadFromXml(xmlString);
            return Ok();
        }

        [HttpGet("sqlite")]
        public ActionResult<List<string>> GetWordsFromSQLite()
        {
            return _wordsDictionary.GetWordsFromSQLite();
        }

        [HttpPost("sqlite")]
        public ActionResult SaveWordsToSQLite()
        {
            _wordsDictionary.SaveWordsToSQLite();
            return Ok();
        }

        
    }
}
