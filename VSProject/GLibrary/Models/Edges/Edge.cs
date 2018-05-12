namespace GLibrary.Models
{
    public abstract class Edge
    {
        private readonly int _id;
        private string _name;
        private Node _inNode;
        private Node _outNode;

        public Edge(int id, string name)
        {
            _id = id;
            _name = name;
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

        public virtual Node InNode
        {
            get => _inNode;
            set => _inNode = value;
        }

        public virtual Node OutNode
        {
            get => _outNode;
            set => _outNode = value;
        }
    }
}
