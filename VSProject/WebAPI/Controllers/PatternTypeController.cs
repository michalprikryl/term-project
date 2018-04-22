using System.Collections.Generic;
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
        public IEnumerable<IActionResult> Get()
        {
            foreach (var item in _db.PatternType)
            {
                yield return Json(item);
            }
        }

        // GET: api/PatternType/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var pattern = _db.PatternType.FirstOrDefault(p => p.Id == id);
            if (pattern != null)
            {
                return Json(pattern);
            }
            else
            {
                return Json(new { Message = "Unknown pattern ID." });
            }
        }
    }
}
