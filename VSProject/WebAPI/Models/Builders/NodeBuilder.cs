using System;
using System.Collections.Generic;

namespace WebAPI.Models.Builders
{
    public static class NodeBuilder
    {
        private static ActivityDiagramNodes _typeVal = ActivityDiagramNodes.Empty;
        private static string _nameVal = string.Empty;
        private static List<Edge> _inEdgesVal = new List<Edge>();
        private static List<Edge> _outEdgesVal = new List<Edge>();

        public static void Type(ActivityDiagramNodes type)
        {
            _typeVal = type;
        }

        public static void Name(string name)
        {
            _nameVal = name;
        }

        public static void InEdges(List<Edge> inEdges)
        {
            _inEdgesVal = inEdges;
        }

        public static void OutEdges(List<Edge> outEdges)
        {
            _outEdgesVal = outEdges;
        }

        public static Node Build()
        {
           /* switch (_typeVal)
            {
                case ActivityDiagramNodes.Empty:
                    ClearBuilder();
                    throw new NotSupportedException("Type for builder was not set!");
                case ActivityDiagramNodes.InitialNode:
                    ClearBuilder();
                    return new InitialNode(_outEdgesVal);
                case ActivityDiagramNodes.FinalNode:
                    ClearBuilder();
                    return new FinalNode(_nameVal, _inEdgesVal);
                case ActivityDiagramNodes.ObjectNode:
                    ClearBuilder();
                    return new ObjectNode(_nameVal, _inEdgesVal, _outEdgesVal);
                case ActivityDiagramNodes.DecisionNode:
                    ClearBuilder();
                    return new DecisionNode(_inEdgesVal, _outEdgesVal);
                case ActivityDiagramNodes.MergeNode:
                    ClearBuilder();
                    return new MergeNode(_inEdgesVal, _outEdgesVal);
                case ActivityDiagramNodes.JoinNode:
                    ClearBuilder();
                    return new JoinNode(_inEdgesVal, _outEdgesVal);
                case ActivityDiagramNodes.ForkNode:
                    ClearBuilder();
                    return new ForkNode(_inEdgesVal, _outEdgesVal);
                case ActivityDiagramNodes.ActionNode:
                    ClearBuilder();
                    return new ActionNode(_nameVal, _inEdgesVal, _outEdgesVal);
            } */

            return null;
        }

        private static void ClearBuilder()
        {
            _nameVal = string.Empty;
            _inEdgesVal = new List<Edge>();
            _outEdgesVal = new List<Edge>();
            _typeVal = ActivityDiagramNodes.Empty;
        }
    }
}
