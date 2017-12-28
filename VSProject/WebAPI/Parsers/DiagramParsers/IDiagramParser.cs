using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.DataAPI;

namespace WebAPI.Parsers.DiagramParsers
{
    interface IDiagramParser
    {
        List<Node> ParseDiagram(List<MxCell> objects);
    }
}
