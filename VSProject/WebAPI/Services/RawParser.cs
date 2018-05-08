using Database;
using System;
using WebAPI.Models.DataAPI;
using WebAPI.Models.Validators;
using WebAPI.Parsers;

namespace WebAPI.Services
{
    public static class RawParser
    {
        public static void WorkWithGraph(InputData model, TermProjectContext db, bool saving = true)
        {
            var format = DataFormat.GetDataFormatByString(model.DataFormat);

            if (format != DataFormatEnum.Unsupported)
            {
                Parser parser = new Parser(format);
                var graph = parser.ParseData(model.Data);

                PatternValidator validator = new PatternValidator(db, format, graph);
                if (!validator.Validate())
                {
                    throw new ArgumentException("Diagram is not containing any rule!");
                }

                if (saving)
                {
                    GraphToDB graphToDB = new GraphToDB(db);
                    if (model is InputDataID)
                    {
                        graphToDB.UpdateGraph(graph, model as InputDataID);
                    }
                    else
                    {
                        graphToDB.SaveGraph(graph, model);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unsupported data format.");
            }
        }
    }
}
