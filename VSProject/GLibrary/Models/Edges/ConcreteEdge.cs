using System;

namespace GLibrary.Models.Edges
{
    public class ConcreteEdge : Edge
    {
        public ConcreteEdge(int id, string name) : base(id, name) { }

        public override Node InNode
        {
            set => throw new NotSupportedException();
        }

        public override Node OutNode
        {
            set => throw new NotSupportedException();
        }
    }
}
