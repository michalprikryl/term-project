using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models.Validators
{
    public class ConsistencyValidator : IValidator
    {
        private List<Node> _nodes;

        public ConsistencyValidator(List<Node> nodes)
        {
            _nodes = nodes ?? throw new NotSupportedException("Nodes cannot be null!");
        }

        public bool Validate()
        {
            if (_nodes.Count == 0)
            {
                return true;
            }

            return CheckConsistency();
        }

        private Boolean CheckConsistency()
        {
            HashSet<NodeWrapper> nodesInProcess = new HashSet<NodeWrapper>
            {
                new NodeWrapper(_nodes.First())
            };

            while (true)
            {
                int count = nodesInProcess.Count;
                HashSet<NodeWrapper> temp = new HashSet<NodeWrapper>(nodesInProcess);

                foreach (NodeWrapper nw in nodesInProcess)
                {
                    if (!nw.isVisited && nw.node.OutEdges != null)
                    {
                        foreach (Edge e in nw.node.OutEdges)
                        {
                            if (!IsInNodeWrapperSet(new NodeWrapper(e.OutNode), temp))
                            {
                                temp.Add(new NodeWrapper(e.OutNode));
                            }
                        }
                    }

                    nw.isVisited = true;
                }

                nodesInProcess.UnionWith(temp);

                if (nodesInProcess.Count == count)
                {
                    break;
                }
            }

            if (nodesInProcess.Count == _nodes.Count)
            {
                return true;
            }

            return false;
        }

        private bool IsInNodeWrapperSet(NodeWrapper wrapper, HashSet<NodeWrapper> set)
        {
            foreach (NodeWrapper n in set)
            {
                if (n.Equals(wrapper))
                {
                    return true;
                }
            }

            return false;
        }

        private class NodeWrapper
        {
            public Node node;
            public bool isVisited;
            public bool allChildrenVisited;

            public NodeWrapper(Node n)
            {
                node = n;
                isVisited = false;
                allChildrenVisited = false;
            }

            public override bool Equals(object obj)
            {
                var wrapper = obj as NodeWrapper;
                return wrapper != null && wrapper.node.Id == node.Id;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}
