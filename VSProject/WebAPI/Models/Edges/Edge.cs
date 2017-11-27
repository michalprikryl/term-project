using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public abstract class Edge
    {
        private string name;
        private Node inNode;
        private Node outNode;

        public abstract string Name { get; set; }
        public abstract Node InNode { get; set; }
        public abstract Node OutNode { get; set; }
    }
}
