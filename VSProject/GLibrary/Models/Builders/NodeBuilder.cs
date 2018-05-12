using System;
using System.Collections.Generic;

namespace GLibrary.Models.Builders
{
    public static class NodeBuilder
    {

        public static Node BuildNode(ActivityDiagramNodes type, int id, string name, bool check)
        {
            if (string.IsNullOrEmpty(name))
            {
                if (type == ActivityDiagramNodes.FinalNode || type == ActivityDiagramNodes.InitialNode)
                {
                    return CreateNode(type, id, new List<Edge>(), check);
                }
                else
                {
                    return CreateNode(type, id, new List<Edge>(), new List<Edge>(), check);
                }
            }
            else
            {
                return CreateNode(type, id, name, new List<Edge>(), new List<Edge>(), check);
            }
        }

        private static Node CreateNode(ActivityDiagramNodes type, int id, List<Edge> inEdges, List<Edge> outEdges, bool check)
        { 
            switch (type)
            {
                case ActivityDiagramNodes.ForkNode:
                    return new ForkNode(id, inEdges, outEdges, check);
                case ActivityDiagramNodes.DecisionNode:
                    return new DecisionNode(id, inEdges, outEdges, check);
                default:
                    throw new ArgumentException("Wrong parameters for given node type!");
            }
        }

        private static Node CreateNode(ActivityDiagramNodes type, int id, string name, List<Edge> inEdges, List<Edge> outEdges, bool check)
        {
            switch (type)
            {
                case ActivityDiagramNodes.ObjectNode:
                    return new ObjectNode(id, name, inEdges, outEdges, check);
                case ActivityDiagramNodes.ActionNode:
                    return new ActionNode(id, name, inEdges, outEdges, check);
                default:
                    throw new ArgumentException("Wrong parameters for given node type!");
            }
        }

        private static Node CreateNode(ActivityDiagramNodes type, int id, List<Edge> edges, bool check)
        {
            switch (type)
            {
                case ActivityDiagramNodes.InitialNode:
                    return new InitialNode(id, edges, check);
                case ActivityDiagramNodes.FinalNode:
                    return new FinalNode(id, edges, check);
                default:
                    throw new ArgumentException("Wrong parameters for given node type!");
            }
        }

        //ConcreteNode node = null;

        //public static ConcreteNode Id(int id)
        //{
        //    return new ConcreteNode(id);
        //}

        //public static void Type(ActivityDiagramNodes type)
        //{
        //    _typeVal = type;
        //}

        //public static void Name(string name)
        //{
        //    _nameVal = name;
        //}

        //public static void InEdges(List<Edge> inEdges)
        //{
        //    _inEdgesVal = inEdges;
        //}

        //public static void OutEdges(List<Edge> outEdges)
        //{
        //    _outEdgesVal = outEdges;
        //}

        //public static Node Build()
        //{
        //    Node n = null;

        //    try
        //    {
        //        switch (_typeVal)
        //        {
        //            case ActivityDiagramNodes.Empty:
        //                throw new NotSupportedException("Type for builder was not set!");
        //            case ActivityDiagramNodes.InitialNode:
        //                n = new InitialNode(_id, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.FinalNode:
        //                n = new FinalNode(_id, _nameVal, _inEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.ObjectNode:
        //                n = new ObjectNode(_id, _nameVal, _inEdgesVal, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.DecisionNode:
        //                n = new DecisionNode(_id, _inEdgesVal, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.MergeNode:
        //                n = new MergeNode(_id, _inEdgesVal, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.JoinNode:
        //                n = new JoinNode(_id, _inEdgesVal, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.ForkNode:
        //                n = new ForkNode(_id, _inEdgesVal, _outEdgesVal);
        //                break;
        //            case ActivityDiagramNodes.ActionNode:
        //                n = new ActionNode(_id, _nameVal, _inEdgesVal, _outEdgesVal);
        //                break;
        //        }
        //    } finally
        //    {
        //        ClearBuilder();
        //    }

        //    return null;
        //}

        //private static void ClearBuilder()
        //{
        //    _id = 0;
        //    _nameVal = string.Empty;
        //    _inEdgesVal = new List<Edge>();
        //    _outEdgesVal = new List<Edge>();
        //    _typeVal = ActivityDiagramNodes.Empty;
        //}
    }
}
