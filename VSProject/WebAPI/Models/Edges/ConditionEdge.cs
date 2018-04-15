namespace WebAPI.Models
{
    public class ConditionEdge : Edge
    {
        public ConditionEdge (int id, string name, Node inNode, Node outNode) : base(id, name)
        {
            InNode = inNode;
            OutNode = outNode;
        }
    }
}
