using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class InterruptEdge : Edge
    {
        public InterruptEdge(Node inNode, Node outNode)
        {
            Name = String.Empty;
            InNode = inNode;
            OutNode = outNode;
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Interrupt edge cannot have name!");
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
