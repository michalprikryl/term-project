using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class DecisionNode : Node
    {
        public DecisionNode(int id, List<Edge> inEdges, List<Edge> outEdges) : base(id)
        {
            Name = String.Empty;
            base.InEdges = inEdges;
            base.OutEdges = outEdges;
        }

        public override List<Edge> InEdges
        {
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Decision node cannot have zero in edges!");
                }

                base.InEdges = value;
            }
        }

        public override List<Edge> OutEdges
        {
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Decision node cannot have zero out edges!");
                }

                base.OutEdges = value;
            }
        }
    }
}
