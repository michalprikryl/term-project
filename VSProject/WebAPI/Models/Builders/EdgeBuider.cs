using System;
using WebAPI.Models.Edges;

namespace WebAPI.Models.Builders
{
    public static class EdgeBuider
    {
        private static string MESSAGE = "Wrong parameters for given node type!";

        public static Edge BuildEdge(ActivityDiagramEdge edgeType, int id, string name, Node inNode, Node outNode)
        {
            if (string.IsNullOrEmpty(name))
            {
                if (inNode == null || outNode == null)
                {
                    return CreateEdge(edgeType, id);
                }
                else
                {
                    return CreateEdge(edgeType, id, inNode, outNode);
                }
            }
            else
            {
                return CreateEdge(edgeType, id, name, inNode, outNode);
            }
        }

        private static Edge CreateEdge(ActivityDiagramEdge edgeType, int id)
        {
            switch(edgeType)
            {
                case ActivityDiagramEdge.Empty:
                    return new ConcreteEdge(id, string.Empty);
                default:
                    throw new ArgumentException(MESSAGE);
            }
        }

        private static Edge CreateEdge(ActivityDiagramEdge edgeType, int id, Node inNode, Node outNode)
        {
            switch (edgeType)
            {
                case ActivityDiagramEdge.ActivityEdge:
                    return new ActivityEdge(id, inNode, outNode);
                case ActivityDiagramEdge.ObjectFlowEdge:
                    return new ObjectFlowEdge(id, inNode, outNode);
                case ActivityDiagramEdge.InterruptEdge:
                    return new InterruptEdge(id, inNode, outNode);
                default:
                    throw new ArgumentException(MESSAGE);
            }
        }

        private static Edge CreateEdge(ActivityDiagramEdge edgeType, int id, string name, Node inNode, Node outNode)
        {
            switch (edgeType)
            {
                case ActivityDiagramEdge.ConditionEdge:
                    return new ConditionEdge(id, name, inNode, outNode);
                case ActivityDiagramEdge.NamedActivityEdge:
                    return new NamedActivityEdge(id, name, inNode, outNode);
                default:
                    throw new ArgumentException(MESSAGE);
            }
        }
    }
}
