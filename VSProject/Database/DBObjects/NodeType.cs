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
        public int DiagramTypeId { get; set; }

        public DiagramType DiagramType { get; set; }
        public ICollection<GraphNode> GraphNode { get; set; }
    }
}
