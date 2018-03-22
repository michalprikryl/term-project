using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Nodes
{
    public class ConcreteNode : Node
    {
        public ConcreteNode(int id) : base(id, String.Empty, new List<Edge>(), new List<Edge>()) {}

        public override string Name { get => this.name; set => this.name = value; }
        public override List<Edge> InEdges { get => inEdges; set => this.inEdges = value; }
        public override List<Edge> OutEdges { get => outEdges; set => this.outEdges = value; }

        public void AddEdge(Edge e)
        {
            if (e == null) throw new ArgumentNullException();

            if (e.InNode.Id == this.Id)
            {
                InEdges.Add(e);
            } else if (e.OutNode.Id == this.Id)
            {
                OutEdges.Add(e);
            } else
            {
                throw new ArgumentException("Edge is not connected to this node!");
            }
        }
    }
}
