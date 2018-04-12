using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Validators
{
    public class ConsistencyValidator : IValidator
    {

        private List<Node> nodes;

        public ConsistencyValidator(List<Node> nodes)
        {
            this.nodes = nodes ?? throw new NotSupportedException("Nodes cannot be null!");
        }

        public bool Validate()
        {
            if (nodes.Count == 0)
            {
                return true;
            }

            return CheckConsistency();
        }

        private Boolean CheckConsistency()
        { 
            HashSet<NodeWrapper> nodesInProcess = new HashSet<NodeWrapper>();

            nodesInProcess.Add(new NodeWrapper(nodes.First()));

            while(true)
            {
                int count = nodesInProcess.Count;
                HashSet<NodeWrapper> temp = new HashSet<NodeWrapper>(nodesInProcess);

                foreach (NodeWrapper nw in nodesInProcess)
                {

                    if (!nw.isVisited && nw.node.OutEdges != null)
                    {
                        foreach (Edge e in nw.node.OutEdges)
                        {
                            if (!IsInNodeWrapperSet(new NodeWrapper(e.OutNode), temp)) temp.Add(new NodeWrapper(e.OutNode));
                        }
                    }

                    nw.isVisited = true;

                }

                nodesInProcess.UnionWith(temp);

                if (nodesInProcess.Count == count) break;
            }

            if (nodesInProcess.Count == nodes.Count)
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
            public Boolean isVisited;
            public Boolean allChildrenVisited;

            public NodeWrapper(Node n)
            {
                this.node = n;
                isVisited = false;
                allChildrenVisited = false;
            }

            public override bool Equals(object obj)
            {
                var wrapper = obj as NodeWrapper;
                return wrapper != null &&
                       wrapper.node.Id == this.node.Id;
            }
        }
    }
}
