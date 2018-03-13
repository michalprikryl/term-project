namespace WebAPI.Models
{
    public abstract class Edge
    {
        protected readonly int id;
        protected string name;
        protected Node inNode;
        protected Node outNode;

        public Edge(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get => id; }

        public abstract string Name { get; set; }
        public abstract Node InNode { get; set; }
        public abstract Node OutNode { get; set; }
    }
}
