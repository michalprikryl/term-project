using System;
using System.Collections.Generic;
using System.Linq;
using GLibrary.Models;
using GLibrary.Builders;
using GLibrary.Models.DataAPI;
using GLibrary.Models.Graphs;
using GLibrary.Models.Validators;

namespace GLibrary.Parsers.DiagramParsers
{
    public class ActivityParser : IDiagramParser
    {
        private bool _check;

        public Graph Graph { get; set; }

        public ActivityParser(bool check)
        {
            _check = check;

            Graph = new Graph
            {
                Nodes = new List<Node>(),
                Edges = new List<Edge>()
            };
        }

        public Graph ParseDiagram(List<MxCell> sourceNodes, List<MxCell> sourceTexts, List<MxCell> sourceEdges)
        {
            //nodes
            CreateNodes(sourceNodes);

            //edges
            CreateEdges(sourceTexts, sourceEdges);

            //assign edges to nodes
            AssignEdgesToNodes();

            if (_check)
            {
                Node graphObject = Graph.Nodes.FirstOrDefault(ne => ne.InEdges == null);
                if (!(graphObject is InitialNode))
                {
                    throw new ArgumentException("Graph doesn't contain initial node.");
                }

                graphObject = Graph.Nodes.FirstOrDefault(ne => ne.OutEdges == null);
                if (!(graphObject is FinalNode))
                {
                    throw new ArgumentException("Graph doesn't contain final node.");
                }

                if (!new ConsistencyValidator(Graph.Nodes).Validate())
                {
                    throw new NotSupportedException("Diagram is not consistent!");
                }
            }

            return Graph;
        }

        private void CreateNodes(List<MxCell> sourceNodes)
        {
            foreach (MxCell cell in sourceNodes)
            {
                ActivityDiagramNodes type = StringUtils.ParseNodeTypeFromXmlStyle(cell.Style);

                Graph.Nodes.Add(NodeBuilder.BuildNode(type, int.Parse(cell.Id), cell.Value, _check));
            }
        }

        private void AssignEdgesToNodes()
        {
            foreach (var node in Graph.Nodes)
            {
                if (node.InEdges != null)
                {
                    node.InEdges = Graph.Edges.Where(edge => edge.OutNode.Id == node.Id).ToList();
                }

                if (node.OutEdges != null)
                {
                    node.OutEdges = Graph.Edges.Where(edge => edge.InNode.Id == node.Id).ToList();
                }
            }
        }

        private void CreateEdges(List<MxCell> sourceTexts, List<MxCell> sourceEdges)
        {
            string edgeText;
            int source, target;
            foreach (MxCell cell in sourceEdges)
            {
                edgeText = sourceTexts.FirstOrDefault(text => text.Parent == cell.Id)?.Value;

                ActivityDiagramEdge type = StringUtils.ParseEdgeTypeFromXmlText(edgeText);

                if(cell.Source == null || cell.Target == null)
                {
                    throw new ArgumentException("Graph contains an edge without source/target node.");
                }

                source = int.Parse(cell.Source);
                target = int.Parse(cell.Target);

                Graph.Edges.Add(EdgeBuider.BuildEdge(type, int.Parse(cell.Id), edgeText, Graph.Nodes.FirstOrDefault(node => node.Id == source), Graph.Nodes.FirstOrDefault(node => node.Id == target)));
            }
        }
    }
}
