using Database;
using GLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models.DataAPI;

namespace WebAPI.Controllers
{
    [Route("api/Check")]
    [Produces("application/json")]
    public class CheckController : APIController
    {
        public CheckController(TermProjectContext db) : base(db) { }

        [HttpPost]
        public IActionResult Post([FromBody]InputData model)
        {
            CheckData check = new CheckData { Message = string.Empty, Proper = false };

            try
            {
                RawParser.WorkWithGraph(model.GetLibraryModel(), _db, false);

                check.Proper = true;
            }
            catch (Exception e)
            {
                check.Message = e.Message;
            }

            return Json(check);
        }
    }
}
