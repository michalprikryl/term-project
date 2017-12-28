using Database;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DataAPI;
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

            DataFormatEnum format;
            switch (model.DataFormat)
            {
                case "xml":
                    format = DataFormatEnum.XML;
                    break;
                case "json":
                    format = DataFormatEnum.JSON;
                    break;
                case "xmi":
                    format = DataFormatEnum.XMI;
                    break;
                default:
                    format = DataFormatEnum.Unsupported;
                    break;
            }

            if (format != DataFormatEnum.Unsupported)
            {
                Parser parser = new Parser(format);
                parser.ParseData(model.Data);
            }
            else
            {
                response.Result = "Unsupported data format.";
            }

            return Json(response);
        }
    }
}