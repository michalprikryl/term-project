using Database;
using System.Collections.Generic;
using GLibrary.Models.Pattern;
using GLibrary.Parsers;

namespace GLibrary.Services
{
    public static class PatternToGraph
    {
        public static List<GraphPattern> GetPatterns(TermProjectContext db, DataFormatEnum format)
        {
            Parser parser = new Parser(format, false);
            List<GraphPattern> patterns = new List<GraphPattern>();
            foreach (var item in db.Pattern)
            {
                patterns.Add(new GraphPattern { Graph = parser.ParseData(item.Jsonrepresenation), PatternTypeId = item.PatternTypeId });
            }

            return patterns;
        }
    }
}
