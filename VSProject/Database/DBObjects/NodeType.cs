using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class NodeType
    {
        public NodeType()
        {
            GraphNode = new HashSet<GraphNode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Initial { get; set; }
        public bool End { get; set; }
        public int DiagramId { get; set; }

        public DiagramType Diagram { get; set; }
        public ICollection<GraphNode> GraphNode { get; set; }
    }
}
