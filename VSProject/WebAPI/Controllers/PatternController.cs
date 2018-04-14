using System.Collections.Generic;
using System.Linq;
using Database;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Pattern;
using Database.DBObjects;

namespace WebAPI.Controllers
{
    [Route("api/Pattern")]
    [Produces("application/json")]
    public class PatternController : APIController
    {
        public PatternController(TermProjectContext db) : base(db) { }

        // GET: api/Pattern
        [HttpGet]
        public IEnumerable<IActionResult> Get()
        {
            foreach (var item in _db.Pattern)
            {
                yield return Json(item);
            }
        }

        // GET: api/Pattern/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var pattern = _db.Pattern.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                return Json(pattern);
            }
            else
            {
                return Json(new { Message = "Unknown pattern ID." });
            }
        }

        // POST: api/Pattern
        [HttpPost]
        public IActionResult Post([FromBody]InputPattern value)
        {
            int? id = null;
            string message;
            if (value.Validate())
            {
                Pattern pattern = new Pattern { Jsonrepresenation = value.JSON, Name = value.Name, Text = value.Text };

                _db.Pattern.Add(pattern);
                _db.SaveChanges();

                id = pattern.Id;

                message = "Pattern was saved";
            }
            else
            {
                message = "Pattern wasn't saved.";
            }

            return Json(new { Message = message, ID = id });
        }

        // PUT: api/Pattern/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InputPattern value)
        {
            string message;

            var pattern = _db.Pattern.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                if(value.JSON != null)
                {
                    pattern.Jsonrepresenation = value.JSON; 
                }

                if (value.Name != null)
                {
                    pattern.Name = value.Name;
                }

                if (value.Text != null)
                {
                    pattern.Text = value.Text;
                }

                _db.SaveChanges();

                message = "Pattern was updated.";
            }
            else
            {
                message = "Unknown pattern ID.";
            }

            return Json(new { Message = message });
        }

        // DELETE: api/Pattern/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message;

            var pattern = _db.Pattern.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                _db.Pattern.Remove(pattern);
                _db.SaveChanges();

                message = "Pattern is successfully deleted.";
            }
            else
            {
                message = "Unknown pattern ID.";
            }

            return Json(new { Message = message });
        }
    }
}
