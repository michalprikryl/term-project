using System;
using System.Collections.Generic;

namespace GLibrary.Models
{
    public class InitialNode : Node
    {
        public InitialNode(int id, List<Edge> outEdges, bool check = true) : base(id, check)
        {
            base.OutEdges = outEdges;
        }

        public override string Name
        {
            set => throw new NotSupportedException("Cannot set name to intial node!");
        }

        public override List<Edge> InEdges
        {
            set => throw new NotSupportedException("Initial node cannot have input edges!");
        }

        public override List<Edge> OutEdges
        {
            set
            {
                if (_check && value.Count == 0)
                {
                    throw new ArgumentException("Initial node cannot have zero out edges!");
                }

                base.OutEdges = value;
            }
        }
    }
}
