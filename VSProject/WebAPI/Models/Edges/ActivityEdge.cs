using System;

namespace WebAPI.Models
{
    public class ActivityEdge : Edge
    {
        public ActivityEdge(int id, Node inNode, Node outNode) : base(id, string.Empty)
        {
            this.inNode = inNode;
            this.outNode = outNode;
        }

        public override string Name { get => name; set => throw new System.NotSupportedException(); }

        public override Node InNode
        {
            get => inNode;
            set => inNode = value;
        }

        public override Node OutNode
        {
            get => outNode;
            set => outNode = value;
        }
    }
}
