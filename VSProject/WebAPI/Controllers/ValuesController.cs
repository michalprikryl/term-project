using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : APIController
    {
        public ValuesController(TermProjectContext db) : base(db) { }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var language = _db.Language.First();

            return new string[] { language.Iso6391code, language.Iso6393code };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var language = _db.Language.First(l => l.Iso6391code == id);

            return $"Your selected language is {language.Name}.";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
