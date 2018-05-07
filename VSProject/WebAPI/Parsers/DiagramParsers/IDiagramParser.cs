using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.DataAPI;
using WebAPI.Models.Graphs;

namespace WebAPI.Parsers.DiagramParsers
{
    interface IDiagramParser
    {
        Graph ParseDiagram(List<MxCell> sourceNodes, List<MxCell> sourceTexts, List<MxCell> sourceEdge);
    }
}
