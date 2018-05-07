using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models.DataAPI;
using WebAPI.Models.Validators;
using WebAPI.Parsers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : APIController
    {
        public UploadController(TermProjectContext db) : base(db) { }

        [HttpPost]
        public IActionResult Post([FromBody]InputData model)
        {
            OutputData response = new OutputData("Everything is OK.");

            try
            {
                var format = DataFormat.GetDataFormatByString(model.DataFormat);

                if (format != DataFormatEnum.Unsupported)
                {
                    Parser parser = new Parser(format);
                    var graph = parser.ParseData(model.Data);

                    PatternValidator validator = new PatternValidator(_db, format, graph);
                    if (!validator.Validate())
                    {
                        response.Result = "Diagram is not containing any rule!";
                    }
                }
                else
                {
                    response.Result = "Unsupported data format.";
                }
            }
            catch (Exception e)
            {
                response.Result = e.Message;
            }

            return Json(response);
        }
    }
}