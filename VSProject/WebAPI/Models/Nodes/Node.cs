using System.Collections.Generic;

namespace WebAPI.Models
{
    public abstract class Node
    {
        public abstract string Name { get; set; }
        public abstract List<Edge> InEdges { get; set; }
        public abstract List<Edge> OutEdges { get; set; }
    }
}
