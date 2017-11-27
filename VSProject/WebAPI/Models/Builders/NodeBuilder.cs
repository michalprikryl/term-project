using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Builders
{
    public static class NodeBuilder
    {
        private static ActivityDiagramNodes typeVal = ActivityDiagramNodes.Empty;
        private static String nameVal = String.Empty;
        private static List<Edge> inEdgesVal = new List<Edge>();
        private static List<Edge> outEdgesVal = new List<Edge>();

        public static void Type (ActivityDiagramNodes type)
        {
            NodeBuilder.typeVal = type ;
        }

        public static void Name (String name)
        {
            NodeBuilder.nameVal = name;
        }

        public static void InEdges (List<Edge> inEdges)
        {
            NodeBuilder.inEdgesVal = inEdges;
        }

        public static void OutEdges (List<Edge> outEdges)
        {
            NodeBuilder.outEdgesVal = outEdges;
        }

        public static Node Build ()
        {
            switch (typeVal)
            {
                case ActivityDiagramNodes.Empty:
                    NodeBuilder.ClearBuilder();
                    throw new NotSupportedException("Type for builder was not set!");
                case ActivityDiagramNodes.InitialNode:
                    NodeBuilder.ClearBuilder();
                    return new InitialNode(outEdgesVal);
                case ActivityDiagramNodes.FinalNode:
                    NodeBuilder.ClearBuilder();
                    return new FinalNode(nameVal, inEdgesVal);
                case ActivityDiagramNodes.ObjectNode:
                    NodeBuilder.ClearBuilder();
                    return new ObjectNode(nameVal, inEdgesVal, outEdgesVal);
                case ActivityDiagramNodes.DecisionNode:
                    NodeBuilder.ClearBuilder();
                    return new DecisionNode(inEdgesVal, outEdgesVal);
                case ActivityDiagramNodes.MergeNode:
                    NodeBuilder.ClearBuilder();
                    return new MergeNode(inEdgesVal, outEdgesVal);
                case ActivityDiagramNodes.JoinNode:
                    NodeBuilder.ClearBuilder();
                    return new JoinNode(inEdgesVal, outEdgesVal);
                case ActivityDiagramNodes.ForkNode:
                    NodeBuilder.ClearBuilder();
                    return new ForkNode(inEdgesVal, outEdgesVal);
                case ActivityDiagramNodes.ActionNode:
                    NodeBuilder.ClearBuilder();
                    return new ActionNode(nameVal, inEdgesVal, outEdgesVal);
            }

            return null;
        }

        private static void ClearBuilder()
        {
            NodeBuilder.nameVal = "";
            NodeBuilder.inEdgesVal = new List<Edge>();
            NodeBuilder.outEdgesVal = new List<Edge>();
            NodeBuilder.typeVal = ActivityDiagramNodes.Empty;
        }
    }
}
