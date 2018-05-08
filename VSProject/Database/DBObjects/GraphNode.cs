using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class GraphNode
    {
        public GraphNode()
        {
            GraphEdgeFromNode = new HashSet<GraphEdge>();
            GraphEdgeToNode = new HashSet<GraphEdge>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int GraphId { get; set; }
        public int NodeTypeId { get; set; }
        public int? RegionId { get; set; }
        public int DiagramNodeId { get; set; }

        public Graph Graph { get; set; }
        public NodeType NodeType { get; set; }
        public Region Region { get; set; }
        public ICollection<GraphEdge> GraphEdgeFromNode { get; set; }
        public ICollection<GraphEdge> GraphEdgeToNode { get; set; }
    }
}
