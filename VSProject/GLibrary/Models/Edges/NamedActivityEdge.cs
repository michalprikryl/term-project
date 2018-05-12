namespace GLibrary.Models
{
    public class NamedActivityEdge : Edge
    {
        public NamedActivityEdge(int id, string name, Node inNode, Node outNode) : base(id, name)
        {
            InNode = inNode;
            OutNode = outNode;
        }
    }
}
