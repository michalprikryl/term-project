using System;

namespace WebAPI.Models
{
    public class InterruptEdge : Edge
    {
        public InterruptEdge(int id, Node inNode, Node outNode) : base(id, string.Empty)
        {
            InNode = inNode;
            OutNode = outNode;
        }

        public override string Name
        {
             set => throw new NotSupportedException();
        }
    }
}
