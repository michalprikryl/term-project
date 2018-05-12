using Database;
using System;
using GLibrary.Models.DataAPI;
using GLibrary.Models.Validators;
using GLibrary.Parsers;

namespace GLibrary.Services
{
    public static class RawParser
    {
        public static void WorkWithGraph(GraphInputData model, TermProjectContext db, bool saving = true)
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
                    if (model is GraphInputDataID)
                    {
                        graphToDB.UpdateGraph(graph, model as GraphInputDataID);
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
