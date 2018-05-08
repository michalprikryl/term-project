using Database;
using Database.DBObjects;
using System;
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

        #region Save new Graph
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
            int regionId = CreateRegion();
            Dictionary<int, int> nodesIDsInDB = new Dictionary<int, int>();
            foreach (var node in nodes)
            {
                nodesIDsInDB.Add(node.Id, CreateNodeInDB(node, graphId, regionId));
            }

            return nodesIDsInDB;
        }

        private void SaveEdges(List<Edge> edges, Dictionary<int, int> nodesInDB)
        {
            foreach (var edge in edges)
            {
                CreateEdgeInDB(nodesInDB, edge);
            }
        }
        #endregion

        #region Update graph
        public void UpdateGraph(GraphAPI graphAPI, InputDataID data)
        {
            Graph graph = _db.Graph.FirstOrDefault(g => g.Id == data.GraphID);
            if (graph != null)
            {
                graph.Name = data.Name;
                graph.Xmlrepresentation = data.Data;

                _db.SaveChanges();

                UpdateEdges(graphAPI.Edges, UpdateNodes(graphAPI.Nodes, graph.Id), graph.Id);
            }
            else
            {
                throw new ArgumentException("Unknown graph ID!");
            }
        }

        private Dictionary<int, int> UpdateNodes(List<Node> nodes, int graphId)
        {
            int nodeId;
            GraphNode graphNode;
            int regionId = GetGraphRegionId(graphId);
            Dictionary<int, int> nodesIDsInDB = new Dictionary<int, int>();
            foreach (var node in nodes)
            {
                graphNode = _db.GraphNode.FirstOrDefault(n => n.GraphId == graphId && n.DiagramNodeId == node.Id);
                if (graphNode != null)
                {
                    nodeId = graphNode.Id;

                    graphNode.Text = node.Name;
                    graphNode.NodeTypeId = GetNodeTypeID(node);

                    _db.SaveChanges();
                }
                else
                {
                    nodeId = CreateNodeInDB(node, graphId, regionId);
                }

                nodesIDsInDB.Add(node.Id, nodeId);
            }

            return nodesIDsInDB;
        }

        private void UpdateEdges(List<Edge> edges, Dictionary<int, int> nodesInDB, int graphId)
        {
            GraphEdge graphEdge;
            foreach (var edge in edges)
            {
                graphEdge = _db.GraphEdge.FirstOrDefault(e => e.DiagramEdgeId == edge.Id && e.FromNode.GraphId == graphId);
                if(graphEdge != null)
                {
                    graphEdge.Text = edge.Name;
                    graphEdge.FromNodeId = nodesInDB[edge.InNode.Id];
                    graphEdge.ToNodeId = nodesInDB[edge.OutNode.Id];

                    _db.SaveChanges();
                }
                else
                {
                    CreateEdgeInDB(nodesInDB, edge);
                }
            }
        }
        #endregion

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

        private int GetGraphRegionId(int graphId)
        {
            return _db.GraphNode.FirstOrDefault(g => g.GraphId == graphId)?.RegionId ?? CreateRegion();
        }

        private int CreateNodeInDB(Node node, int graphId, int regionId)
        {
            GraphNode graphNode = new GraphNode
            {
                Text = node.Name,
                GraphId = graphId,
                RegionId = regionId,
                NodeTypeId = GetNodeTypeID(node)
            };

            _db.GraphNode.Add(graphNode);
            _db.SaveChanges();

            return graphNode.Id;
        }

        private void CreateEdgeInDB(Dictionary<int, int> nodesInDB, Edge edge)
        {
            _db.GraphEdge.Add(new GraphEdge
            {
                Text = edge.Name,
                FromNodeId = nodesInDB[edge.InNode.Id],
                ToNodeId = nodesInDB[edge.OutNode.Id]
            });

            _db.SaveChanges();
        }
    }
}
