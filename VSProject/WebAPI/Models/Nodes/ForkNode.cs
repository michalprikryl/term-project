using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ForkNode : Node
    {
        public ForkNode(int id, List<Edge> inEdges, List<Edge> outEdges, bool check = true) : base(id, check)
        {
            base.InEdges = inEdges;
            base.OutEdges = outEdges;
        }

        public override string Name
        {
            set => throw new NotSupportedException("Cannot set name to fork node!");
        }

        public override List<Edge> InEdges
        {
            set
            {
                if (_check && OutEdges.Count > 1 && value.Count > 1)
                {
                    throw new ArgumentException("Cannot set more than 1 in edge if out edges > 1");
                }

                base.InEdges = value;
            }
        }

        public override List<Edge> OutEdges
        {
            set
            {
                if (_check && InEdges.Count > 1 && value.Count > 1)
                {
                    throw new ArgumentException("Cannot set more than 1 out edge if in edges > 1");
                }

                base.OutEdges = value;
            }
        }
    }
}
