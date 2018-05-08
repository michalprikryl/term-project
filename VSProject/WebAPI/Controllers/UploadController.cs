﻿using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAPI.Models.DataAPI;
using WebAPI.Services;

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
                RawParser.WorkWithGraph(model, _db);
            }
            catch (Exception e)
            {
                response.Result = e.Message;
            }

            return Json(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]InputDataID model)
        {
            OutputData response = new OutputData("Everything is OK - graph was saved to DB.");

            try
            {
                RawParser.WorkWithGraph(model, _db);
            }
            catch (Exception e)
            {
                response.Result = e.Message;
            }

            return Json(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody]int id)
        {
            string message;

            var graph = _db.Graph.FirstOrDefault(p => p.Id == id);
            if (graph != null)
            {
                _db.Graph.Remove(graph);
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