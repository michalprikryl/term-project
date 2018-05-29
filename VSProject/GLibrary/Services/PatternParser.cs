using GLibrary.Models.Graphs;
using GLibrary.Models.Validators;
using GLibrary.Parsers;

namespace GLibrary.Services
{
    public static class PatternParser
    {
        public static bool CheckPattern(string pattern, DataFormatEnum format = DataFormatEnum.XML)
        {
            Parser parser = new Parser(format, false);
            Graph graph = parser.ParseData(pattern);

            return new ConsistencyValidator(graph.Nodes).Validate();
        }
    }
}
