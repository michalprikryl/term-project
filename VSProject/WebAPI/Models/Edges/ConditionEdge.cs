namespace WebAPI.Models
{
    public class ConditionEdge : Edge
    {
        public ConditionEdge (string name, Node inNode, Node outNode)
        {
            Name = name;
            InNode = inNode;
            OutNode = outNode;
        }

        public override string Name
        {
            get => Name;
            set => Name = value;
        }

        public override Node InNode
        {
            get => InNode;
            set => InNode = value;
        }

        public override Node OutNode
        {
            get => OutNode;
            set => OutNode = value;
        }
    }
}
