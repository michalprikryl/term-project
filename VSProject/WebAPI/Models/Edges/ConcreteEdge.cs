using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Edges
{
    public class ConcreteEdge : Edge
    {
        public ConcreteEdge(int id, string name) : base(id, name) { }

        public override string Name { get => name; set => this.name = value; }
        public override Node InNode { get => inNode; set => throw new NotSupportedException(); }
        public override Node OutNode { get => outNode; set => throw new NotSupportedException(); }
    }
}
