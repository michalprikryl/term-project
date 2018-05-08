using Database;
using Database.DBObjects;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Models.DataAPI;
using GraphAPI = WebAPI.Models.Graphs.Graph;

namespace WebAPI.Services
{
    public class GraphToDB
    {
        private TermProjectContext _db;
        private Dictionary<string, int> _nodeTypes;

        private int WorkSpaceId
        {
            get
            {
                return _db.WorkSpace.First().Id;
            }
        }

        public GraphToDB(TermProjectContext db)
        {
            _db = db;
            _nodeTypes = new Dictionary<string, int>();
        }

        public void SaveGraph(GraphAPI graphAPI, InputData data)
        {
            Graph graph = new Graph
            {
                WorkSpaceId = WorkSpaceId,
                Xmlrepresentation = data.Data,
                Name = data.Name ?? "graph"
            };

            _db.Graph.Add(graph);
            _db.SaveChanges();

            SaveEdges(graphAPI.Edges, SaveNodes(graphAPI.Nodes, graph.Id));
        }

        private int CreateRegion()
        {
            Region region = new Region
            {
                Text = "default region"
            };

            _db.Region.Add(region);
            _db.SaveChanges();

            return region.Id;
        }

        private Dictionary<int, int> SaveNodes(List<Node> nodes, int graphId)
        {
            GraphNode graphNode;
            int regionId = CreateRegion();
            Dictionary<int, int> nodesIDsInDB = new Dictionary<int, int>();
            foreach (var node in nodes)
            {
                graphNode = new GraphNode
                {
                    Text = node.Name ?? string.Empty,
                    GraphId = graphId,
                    RegionId = regionId,
                    NodeTypeId = GetNodeTypeID(node)
                };

                _db.GraphNode.Add(graphNode);
                _db.SaveChanges();

                nodesIDsInDB.Add(node.Id, graphNode.Id);
            }

            return nodesIDsInDB;
        }

        private void SaveEdges(List<Edge> edges, Dictionary<int, int> nodesInDB)
        {
            foreach (var edge in edges)
            {
                _db.GraphEdge.Add(new GraphEdge
                {
                    Text = edge.Name ?? string.Empty,
                    FromNodeId = nodesInDB[edge.InNode.Id],
                    ToNodeId = nodesInDB[edge.OutNode.Id]
                });

                _db.SaveChanges();
            }
        }

        private int GetNodeTypeID(Node node)
        {
            int rv;
            if (node is ActionNode)
            {
                rv = NodeTypeID("Activity");
            }
            else if (node is DecisionNode)
            {
                rv = NodeTypeID("Condition");
            }
            else if (node is InitialNode)
            {
                rv = NodeTypeID("Initial");
            }
            else if (node is FinalNode)
            {
                rv = NodeTypeID("Final");
            }
            else if (node is ForkNode)
            {
                if (node.OutEdges.Count > 1)
                {
                    rv = NodeTypeID("Fork");
                }
                else
                {
                    rv = NodeTypeID("Join");
                }
            }
            else
            {
                rv = NodeTypeID("Activity");
            }

            return rv;
        }

        private int NodeTypeID(string nodeType)
        {
            int nodeTypeID;
            if (_nodeTypes.ContainsKey(nodeType))
            {
                nodeTypeID = _nodeTypes[nodeType];
            }
            else
            {
                nodeTypeID = _db.NodeType.FirstOrDefault(type => type.Name == nodeType)?.Id ?? _db.NodeType.First(type => type.Name == "Activity").Id;

                _nodeTypes.Add(nodeType, nodeTypeID);
            }

            return nodeTypeID;
        }
    }
}
