using System;

namespace WebAPI.Models
{
    public class ActivityEdge : Edge
    {
        public ActivityEdge(Node inNode, Node outNode)
        {
            Name = string.Empty;
            InNode = inNode;
            OutNode = outNode;
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Activity edge cannot have name!");
        }

        public override Node InNode
        {
            get => InNode;
            set => InNode = value;
        }

        public override Node OutNode
        {
            get => OutNode;
            set => OutNode = value;
        }
    }
}
