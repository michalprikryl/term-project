using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Models.DataAPI;

namespace WebAPI.Parsers.DiagramParsers
{
    public class ActivityParser : IDiagramParser
    {
        private List<MxCell> _objects;

        public List<Node> ParseDiagram(List<MxCell> objects)
        {
            List<Node> graph = new List<Node>();

            _objects = objects;

            MxCell graphObject = objects.FirstOrDefault(ne => (ne.Id == "0" || ne.Id == "1") && ne.Parent == "0");
            if (graphObject == null)
            {
                throw new ArgumentException("Graph doesn't contain initial node.");
            }
            else
            {
                //graph.Add(new InitialNode())
            }

            for (int i = 1; i < objects.Count; i++)
            {
                graphObject = objects.FirstOrDefault(ne => ne.Id == i.ToString());

                if (graphObject == null)
                {
                    break;
                }
            }

            return graph;
        }

        //private Edge FindEdge(string id)
        //{
        //    MxCell xcell = _objects.FirstOrDefault(obj => obj.Parent == "1" && obj.Edge == "1" && obj.Source == id);

        //    NamedActivityEdge edge = new NamedActivityEdge(xcell.Value, xcell.);
        //}
    }
}
