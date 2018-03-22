using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ForkNode : Node
    {
        public ForkNode(int id, List<Edge> inEdges, List<Edge> outEdges) : base(id, string.Empty, inEdges, outEdges) { }

        public override string Name
        {
            get => name;
            set => throw new NotSupportedException("Cannot set name to fork node!");
        }

        public override List<Edge> InEdges
        {
            get => inEdges;
            set
            {
                if (outEdges.Count > 1 && value.Count > 1)
                {
                    throw new ArgumentException("Cannot set more than 1 in edge if out edges > 1");
                }

                this.inEdges = value;
            }
        }

        public override List<Edge> OutEdges
        {
            get => outEdges;
            set
            {
                if (inEdges.Count > 1 && value.Count > 1)
                {
                    throw new ArgumentException("Cannot set more than 1 out edge if in edges > 1");
                }

                this.outEdges = value;
            }
        }
    }
}
