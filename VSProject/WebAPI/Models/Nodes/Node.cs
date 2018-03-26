using System.Collections.Generic;

namespace WebAPI.Models
{
    public abstract class Node
    {
        private readonly int _id;
        private string _name;
        private List<Edge> _inEdges;
        private List<Edge> _outEdges;

        public Node(int id)
        {
            _id = id;
        }

        public int Id
        {
            get => _id;
        }

        public virtual string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual List<Edge> InEdges
        {
            get => _inEdges;
            set => _inEdges = value;
        }

        public virtual List<Edge> OutEdges
        {
            get => _outEdges;
            set => _outEdges = value;
        }
    }
}
