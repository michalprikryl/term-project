using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Models.Builders;
using WebAPI.Models.DataAPI;
using WebAPI.Models.Validators;

namespace WebAPI.Parsers.DiagramParsers
{
    public class ActivityParser : IDiagramParser
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public ActivityParser()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public List<Node> ParseDiagram(List<MxCell> sourceNodes, List<MxCell> sourceTexts, List<MxCell> sourceEdges)
        {
            //nodes
            CreateNodes(sourceNodes);

            //edges
            CreateEdges(sourceTexts, sourceEdges);

            //assign edges to nodes
            AssignEdgesToNodes();

            Node graphObject = Nodes.FirstOrDefault(ne => ne.InEdges == null);
            if (!(graphObject is InitialNode))
            {
                throw new ArgumentException("Graph doesn't contain initial node.");
            }

            graphObject = Nodes.FirstOrDefault(ne => ne.OutEdges == null);
            if (!(graphObject is FinalNode))
            {
                throw new ArgumentException("Graph doesn't contain final node.");
            }

            //nepamatuju si proc jsem dal navratovou hodnotu, tak to tu necham

            if (!new ConsistencyValidator(this.Nodes).Validate())
            {
                throw new NotSupportedException("Diagram is not consistent!");
            }

            return new List<Node>();
        }

        private void CreateNodes(List<MxCell> sourceNodes)
        {
            foreach (MxCell cell in sourceNodes)
            {
                ActivityDiagramNodes type = StringUtils.ParseNodeTypeFromXmlStyle(cell.Style);

                Nodes.Add(NodeBuilder.BuildNode(type, int.Parse(cell.Id), cell.Value));
            }
        }

        private void AssignEdgesToNodes()
        {
            foreach (var node in Nodes)
            {
                if (node.InEdges != null)
                {
                    node.InEdges = Edges.Where(edge => edge.OutNode.Id == node.Id).ToList();
                }

                if (node.OutEdges != null)
                {
                    node.OutEdges = Edges.Where(edge => edge.InNode.Id == node.Id).ToList();
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

                source = int.Parse(cell.Source);
                target = int.Parse(cell.Target);
                Edges.Add(EdgeBuider.BuildEdge(type, int.Parse(cell.Id), edgeText, Nodes.FirstOrDefault(node => node.Id == source), Nodes.FirstOrDefault(node => node.Id == target)));
            }
        }
    }
}
