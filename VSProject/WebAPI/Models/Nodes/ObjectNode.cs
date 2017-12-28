using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ObjectNode : Node
    {
        public ObjectNode(string name, List<Edge> inEdges, List<Edge> outEdges)
        {
            Name = name;
            InEdges = inEdges;
            OutEdges = outEdges;
        }

        public override string Name
        {
            get => Name;
            set => Name = value;
        }

        public override List<Edge> InEdges
        {
            get => InEdges;
            set => InEdges = value.Count > 0 ? value : throw new ArgumentException("Object node cannot have zero in edges!");
        }

        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => OutEdges = value.Count > 0 ? value : throw new ArgumentException("Object node cannot have zero out edges!");
        }
    }
}
