namespace WebAPI.Models
{
    public class ConditionEdge : Edge
    {

        public ConditionEdge (int id, string name, Node inNode, Node outNode) : base(id, name)
        {
            this.inNode = inNode;
            this.outNode = outNode;
        }

        public override string Name { get => name; set => name = value; }

        public override Node InNode
        {
            get => inNode;
            set => inNode = value;
        }

        public override Node OutNode
        {
            get => outNode;
            set => outNode = value;
        }
    }
}
