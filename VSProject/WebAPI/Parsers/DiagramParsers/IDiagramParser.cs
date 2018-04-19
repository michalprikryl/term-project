using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.DataAPI;

namespace WebAPI.Parsers.DiagramParsers
{
    interface IDiagramParser
    {
        List<Node> ParseDiagram(List<MxCell> sourceNodes, List<MxCell> sourceTexts, List<MxCell> sourceEdge);
    }
}
