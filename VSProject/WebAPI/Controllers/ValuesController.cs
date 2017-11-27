using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using System.IO;

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
            //var language = _db.Language.First(l => l.Iso6391code == id);

            TestXML xml = new TestXML
            {
                Text = "nic",
                AdditionalData = "some other data"
            };

            using (FileStream stream = new FileStream(@"C:\Users\Michal\OneDrive\Learn\out.txt", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(TestXML));
                ser.Serialize(stream, xml);
            }

            //return $"Your selected language is {language.Name}.";
            return "";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(TestXML model)
        {
            return Json(new { response = true });
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

    public class TestXML
    {
        public string Text { get; set; }
        public string AdditionalData { get; set; }
    }
}
