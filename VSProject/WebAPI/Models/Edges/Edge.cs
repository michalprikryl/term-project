namespace WebAPI.Models
{
    public abstract class Edge
    {
        public abstract string Name { get; set; }
        public abstract Node InNode { get; set; }
        public abstract Node OutNode { get; set; }
    }
}
