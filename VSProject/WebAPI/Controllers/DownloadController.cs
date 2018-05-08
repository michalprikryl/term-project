using System.Linq;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/Download")]
    [Produces("application/json")]
    public class DownloadController : APIController
    {
        public DownloadController(TermProjectContext db) : base(db) { }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_db.Graph.Select(type => type.GetObject));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var graph = _db.Graph.FirstOrDefault(p => p.Id == id);
            if (graph != null)
            {
                return Json(graph.GetObject);
            }
            else
            {
                return Json(new { Message = "Unknown graph ID." });
            }
        }
    }
}
