using System;
using System.Collections.Generic;

namespace GLibrary.Models.Nodes
{
    public class ConcreteNode : Node
    {
        public ConcreteNode(int id, bool check = true) : base(id, check) { }

        public void AddEdge(Edge e)
        {
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            if (e.InNode.Id == Id)
            {
                InEdges.Add(e);
            }
            else if (e.OutNode.Id == Id)
            {
                OutEdges.Add(e);
            }
            else
            {
                throw new ArgumentException("Edge is not connected to this node!");
            }
        }
    }
}
