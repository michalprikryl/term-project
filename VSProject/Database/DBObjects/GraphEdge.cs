using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class GraphEdge
    {
        public int Id { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
        public string Text { get; set; }
        public int DiagramEdgeId { get; set; }

        public GraphNode FromNode { get; set; }
        public GraphNode ToNode { get; set; }
    }
}
