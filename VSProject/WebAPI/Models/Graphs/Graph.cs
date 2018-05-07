using System.Collections.Generic;

namespace WebAPI.Models.Graphs
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
