using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ForkNode : Node
    {
        public ForkNode(int id, List<Edge> inEdges, List<Edge> outEdges) : base(id, string.Empty, inEdges, outEdges) { }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to fork node!");
        }

        public override List<Edge> InEdges
        {
            get => InEdges;
            set => InEdges = value.Count == 1 ? value : throw new ArgumentException("Fork node cannot have more or less than one in edge!");
        }

        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => OutEdges = value.Count > 0 ? value : throw new ArgumentException("Fork node must have at least one out edge!");
        }
    }
}
