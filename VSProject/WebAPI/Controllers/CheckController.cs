using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models.DataAPI;
using WebAPI.Parsers;

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
                var format = DataFormat.GetDataFormatByString(model.DataFormat);

                if (format != DataFormatEnum.Unsupported)
                {
                    Parser parser = new Parser(format);
                    parser.ParseData(model.Data);
                }
                else
                {
                    check.Message = "Unsupported data format.";
                }

                check.Proper = true;
            }
            catch(Exception e)
            {
                check.Message = e.Message;
            }

            return Json(check);
        }
    }
}
