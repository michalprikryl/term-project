using System.Collections.Generic;

namespace WebAPI.Models
{
    public abstract class Node
    {
        protected readonly int id;
        protected string name;
        protected List<Edge> inEdges;
        protected List<Edge> outEdges;

        public Node(int id, string name, List<Edge> inEdges, List<Edge> outEdges)
        {
            this.id = id;
            this.name = name;
            this.inEdges = inEdges;
            this.outEdges = outEdges;
        }

        public int Id { get => id; }
        public abstract string Name { get; set; }
        public abstract List<Edge> InEdges { get; set; }
        public abstract List<Edge> OutEdges { get; set; }
    }
}
