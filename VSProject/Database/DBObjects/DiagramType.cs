using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class DiagramType
    {
        public DiagramType()
        {
            NodeType = new HashSet<NodeType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<NodeType> NodeType { get; set; }
    }
}
