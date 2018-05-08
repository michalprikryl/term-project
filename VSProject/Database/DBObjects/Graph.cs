using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class Graph
    {
        public Graph()
        {
            GraphNode = new HashSet<GraphNode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkSpaceId { get; set; }
        public string Xmlrepresentation { get; set; }

        public WorkSpace WorkSpace { get; set; }
        public ICollection<GraphNode> GraphNode { get; set; }

        public object GetObject
        {
            get
            {
                return new { Id, Name, Xmlrepresentation, WorkSpaceId };
            }
        }
    }
}
