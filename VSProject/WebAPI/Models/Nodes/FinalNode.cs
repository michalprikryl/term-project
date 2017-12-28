using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class FinalNode : Node
    {
        public FinalNode(string name, List<Edge> inEdges)
        {
            Name = string.Empty;
            InEdges = inEdges;
            OutEdges = new List<Edge>();
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to final node!");
        }

        public override List<Edge> InEdges
        {
            get => InEdges;
            set => InEdges = value;
        }

        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => throw new NotSupportedException("Final node cannot have out edges!");
        }
    }
}
