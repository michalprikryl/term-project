using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class FinalNode : Node
    {
        public FinalNode(string name, List<Edge> inEdges)
        {
            Name = String.Empty;
            InEdges = inEdges;
            OutEdges = new List<Edge>();
        }

        public override string Name {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to final node!");
        }
        public override List<Edge> InEdges {
            get => InEdges;
            set => InEdges = value;
        }
        public override List<Edge> OutEdges {
            get => OutEdges;
            set => throw new NotSupportedException("Final node cannot have out edges!");
        }
    }
}
