using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WebAPI.Models;
using WebAPI.Models.DataAPI;
using System;
using WebAPI.Parsers.DiagramParsers;
using System.Linq;

namespace WebAPI.Parsers
{
    public class DataParserXML : IDataParser
    {
        public DiagramType DiagramType { get; set; }

        public DataParserXML()
        {
            DiagramType = DiagramType.Activity;
        }

        public List<Node> ParseData(string data)
        {
            InputXML xml = SerializeXML(data);

            CheckXML(xml);

            var graph = ParseGraph(xml);

            IDiagramParser parser;
            switch (DiagramType)
            {
                case DiagramType.Activity:
                    parser = new ActivityParser();
                    break;
                default:
                    parser = new ActivityParser();
                    break;
            }

            return parser.ParseDiagram(graph.Item1, graph.Item2, graph.Item3);
        }

        private InputXML SerializeXML(string data)
        {
            InputXML xml = new InputXML();
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(data)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MxGraphModel));
                xml.Graph = serializer.Deserialize(stream) as MxGraphModel;
            }

            return xml;
        }

        private void CheckXML(InputXML xml)
        {
            if (xml.Graph == null || xml.Graph.Root == null || xml.Graph.Root.MxCells == null)
            {
                throw new ArgumentException("Sent xml isn't in the correct format.");
            }
            else if (xml.Graph.Root.MxCells.Count == 0)
            {
                throw new ArgumentException("Sent graph doesn't contains any element (node, edge).");
            }
        }

        private Tuple<List<MxCell>, List<MxCell>, List<MxCell>> ParseGraph(InputXML xml)
        {
            //nodes
            var nodes = xml.Graph.Root.MxCells.Where(cell => cell.Vertex == "1" && string.IsNullOrEmpty(cell.Connectable)).ToList();

            //edge texty, texty jsou totiz jako oddeleny element.. :D 
            var edgeTexts = xml.Graph.Root.MxCells.Where(cell => cell.Vertex == "1" && cell.Connectable == "0").ToList();

            //edges
            var edges = xml.Graph.Root.MxCells.Where(cell => cell.Edge == "1").ToList();

            return new Tuple<List<MxCell>, List<MxCell>, List<MxCell>>(nodes, edgeTexts, edges);
        }
    }
}
