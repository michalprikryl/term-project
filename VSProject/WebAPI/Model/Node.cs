using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public abstract class Node
    {
        private String name;
        private List<Edge> inEdges;
        private List<Edge> outEdges;

        public abstract string Name { get; set; }
        public abstract List<Edge> InEdges { get; set; }
        public abstract List<Edge> OutEdges { get; set; }
    }
}
