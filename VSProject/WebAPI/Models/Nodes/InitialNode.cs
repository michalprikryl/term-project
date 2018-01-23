using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class InitialNode : Node
    {
        public InitialNode(List<Edge> outEdges)
        {
            Name = string.Empty;
            OutEdges = outEdges;
            InEdges = new List<Edge>();
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to intial node!");
        }

        public override List<Edge> InEdges
        {
            get => InEdges;
            set => throw new NotSupportedException("Initial node cannot have input edges!");
        }

        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => OutEdges = value;
        }
    }
}
