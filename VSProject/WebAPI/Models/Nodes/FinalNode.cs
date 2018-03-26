using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class FinalNode : Node
    {
        public FinalNode(int id, List<Edge> inEdges) : base(id)
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
                if (value.Count == 0)
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
