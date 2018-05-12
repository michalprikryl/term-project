using System;

namespace GLibrary.Models
{
    public class ActivityEdge : Edge
    {
        public ActivityEdge(int id, Node inNode, Node outNode) : base(id, string.Empty)
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
