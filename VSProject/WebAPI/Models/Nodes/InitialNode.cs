using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class InitialNode : Node
    {
        public InitialNode(int id, List<Edge> outEdges) : base(id, string.Empty, new List<Edge>(), outEdges) { }

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
