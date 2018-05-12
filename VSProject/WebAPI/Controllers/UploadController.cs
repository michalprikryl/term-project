using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAPI.Models.DataAPI;
using GLibrary.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : APIController
    {
        public UploadController(TermProjectContext db) : base(db) { }

        [HttpPost]
        public IActionResult Post([FromBody]InputData model)
        {
            OutputData response = new OutputData("Everything is OK - graph was saved to DB.");

            try
            {
                RawParser.WorkWithGraph(model.GetLibraryModel(), _db);
            }
            catch (Exception e)
            {
                response.Result = e.Message;
            }

            return Json(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InputDataID model)
        {
            OutputData response = new OutputData("Everything is OK - graph was updated to DB.");

            try
            {
                RawParser.WorkWithGraph(model.GetLibraryModel(), _db);
            }
            catch (Exception e)
            {
                response.Result = e.Message;
            }

            return Json(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message;

            var graph = _db.Graph.FirstOrDefault(p => p.Id == id);
            if (graph != null)
            {
                _db.GraphEdge.RemoveRange(_db.GraphEdge.Where(e => e.FromNode.GraphId == id));
                _db.GraphNode.RemoveRange(_db.GraphNode.Where(e => e.GraphId == id));
                _db.Graph.Remove(graph);
                _db.Region.Remove(_db.Region.First(r => r.GraphNode.Any(n => n.GraphId == id)));

                _db.SaveChanges();

                message = "Graph is successfully deleted.";
            }
            else
            {
                message = "Unknown pattern ID.";
            }

            return Json(new { Message = message });
        }
    }
}