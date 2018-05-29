using System.Linq;
using Database;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Pattern;
using Database.DBObjects;
using GLibrary.Services;
using System;

namespace WebAPI.Controllers
{
    [Route("api/Pattern")]
    [Produces("application/json")]
    public class PatternController : APIController
    {
        public PatternController(TermProjectContext db) : base(db) { }

        // GET: api/Pattern
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_db.Pattern.Select(type => type.GetObject));
        }

        // GET: api/Pattern/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pattern = _db.Pattern.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                return Json(pattern.GetObject);
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
            try
            {
                if (value.Validate())
                {
                    string patternString = value.JSON.DeleteParentNodes();

                    if (PatternParser.CheckPattern(patternString))
                    {
                        message = "Pattern was saved.";
                    }
                    else
                    {
                        message = "Pattern was saved, but pattern is not consistent!";
                    }

                    Pattern pattern = new Pattern { Jsonrepresenation = patternString, Name = value.Name, Text = value.Text, PatternTypeId = value.PatternTypeID };

                    _db.Pattern.Add(pattern);
                    _db.SaveChanges();

                    id = pattern.Id;
                }
                else
                {
                    message = "Pattern wasn't saved.";
                }
            }
            catch (Exception e)
            {
                message = $"{e.Message} - pattern wasn't saved.";
            }

            return Json(new { Message = message, ID = id });
        }

        // PUT: api/Pattern/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InputPattern value)
        {
            string message;

            try
            {
                var pattern = _db.Pattern.FirstOrDefault(p => p.Id == id);
                if (pattern != null)
                {
                    if (value.JSON != null)
                    {
                        string patternString = value.JSON.DeleteParentNodes();
                        pattern.Jsonrepresenation = patternString;

                        if (PatternParser.CheckPattern(patternString))
                        {
                            message = "Pattern was updated.";
                        }
                        else
                        {
                            message = "Pattern was updated, but pattern is not consistent!";
                        }

                        if (value.Name != null)
                        {
                            pattern.Name = value.Name;
                        }

                        if (value.Text != null)
                        {
                            pattern.Text = value.Text;
                        }

                        if (value.PatternTypeID != 0)
                        {
                            pattern.PatternTypeId = value.PatternTypeID;
                        }

                        _db.SaveChanges();
                    }
                    else
                    {
                        message = "Pattern wasn't saved.";
                    }
                }
                else
                {
                    message = "Unknown pattern ID.";
                }
            }
            catch (Exception e)
            {
                message = $"{e.Message} - pattern wasn't saved.";
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
