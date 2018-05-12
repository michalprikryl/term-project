using System.Collections.Generic;
using GLibrary.Models;
using GLibrary.Models.DataAPI;
using GLibrary.Models.Graphs;

namespace GLibrary.Parsers.DiagramParsers
{
    interface IDiagramParser
    {
        Graph ParseDiagram(List<MxCell> sourceNodes, List<MxCell> sourceTexts, List<MxCell> sourceEdge);
    }
}
