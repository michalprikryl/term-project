using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class JoinNode : Node
    {
        public JoinNode(List<Edge> inEdges, List<Edge> outEdges)
        {
            Name = string.Empty;
            InEdges = inEdges;
            OutEdges = outEdges;
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to join node!");
        }

        public override List<Edge> InEdges
        {
            get => InEdges;
            set => InEdges = value.Count == 1 ? value : throw new ArgumentException("Join node cannot have more or less than one in edge!");
        }

        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => OutEdges = value.Count > 0 ? value : throw new ArgumentException("Join node must have at least one out edge!");
        }
    }
}
