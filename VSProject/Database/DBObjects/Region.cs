using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class Region
    {
        public Region()
        {
            GraphNode = new HashSet<GraphNode>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<GraphNode> GraphNode { get; set; }
    }
}
