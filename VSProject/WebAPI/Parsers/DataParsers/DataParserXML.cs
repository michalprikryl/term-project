using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WebAPI.Models;
using WebAPI.Models.DataAPI;
using System;
using WebAPI.Parsers.DiagramParsers;
using WebAPI.Models.Nodes;
using WebAPI.Models.Edges;

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

            return parser.ParseDiagram(xml.Graph.Root.MxCells);
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
            if(xml.Graph == null || xml.Graph.Root == null || xml.Graph.Root.MxCells == null)
            {
                throw new ArgumentException("Sent xml isn't in the correct format.");
            }
            else if (xml.Graph.Root.MxCells.Count > 0)
            {
                List<Node> nodes = new List<Node>();
                List<Edge> edges = new List<Edge>();

                foreach (MxCell c in xml.Graph.Root.MxCells)
                {
                    if ("1".Equals(c.Vertex))
                    {
                        nodes.Add(new ConcreteNode(Int32.Parse(c.Id), c.Value));
                    }
                    else if ("1".Equals(c.Edge))
                    {
                        edges.Add(new ConcreteEdge(Int32.Parse(c.Id), c.Value));
                    }
                }
            }

            Console.WriteLine("DONE!");
        }
    }
}
