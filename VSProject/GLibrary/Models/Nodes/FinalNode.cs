using System;
using System.Collections.Generic;

namespace GLibrary.Models
{
    public class FinalNode : Node
    {
        public FinalNode(int id, List<Edge> inEdges, bool check = true) : base(id, check)
        {
            base.InEdges = inEdges;
        }

        public override string Name
        {
            set => throw new NotSupportedException("Cannot set name to final node!");
        }

        public override List<Edge> InEdges
        {
            set
            {
                if (_check && value.Count == 0)
                {
                    throw new ArgumentException("Final node cannot have zero in edges!");
                }

                base.InEdges = value;
            }
        }

        public override List<Edge> OutEdges
        {
            set => throw new NotSupportedException("Final node cannot have out edges!");
        }
    }
}
