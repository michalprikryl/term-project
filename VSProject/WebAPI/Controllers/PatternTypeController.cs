using System.Linq;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/PatternType")]
    [Produces("application/json")]
    public class PatternTypeController : APIController
    {
        public PatternTypeController(TermProjectContext db) : base(db) { }

        // GET: api/PatternType
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_db.PatternType.Select(type => type.GetObject));
        }

        // GET: api/PatternType/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pattern = _db.PatternType.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                return Json(pattern.GetObject);
            }
            else
            {
                return Json(new { Message = "Unknown pattern ID." });
            }
        }
    }
}
