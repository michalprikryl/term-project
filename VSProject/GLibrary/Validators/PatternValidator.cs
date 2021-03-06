﻿using Database;
using System.Collections.Generic;
using System.Linq;
using GLibrary.Models.Graphs;
using GLibrary.Parsers;
using GLibrary.Services;

namespace GLibrary.Models.Validators
{
    public class PatternValidator : IValidator
    {
        private TermProjectContext _db;
        private DataFormatEnum _format;
        private Graph _graph;

        public PatternValidator(TermProjectContext db, DataFormatEnum format, Graph graph)
        {
            _db = db;
            _graph = graph;
            _format = format;
        }

        public bool Validate()
        {
            var patternGraphs = PatternToGraph.GetPatterns(_db, _format);

            Node firstNode;
            List<int> foundPatterns = new List<int>();
            foreach (var pattern in patternGraphs)
            {
                firstNode = pattern.Graph.Nodes.First();

                foreach (var node in _graph.Nodes)
                {
                    if (node.Name == firstNode.Name)
                    {
                        if (FindNodes(firstNode, node))
                        {
                            foundPatterns.Add(pattern.PatternTypeId);
                        }
                    }
                }
            }

            return foundPatterns.Count != 0 || patternGraphs.Count == 0;
        }

        private bool FindNodes(Node patterns, Node graphs)
        {
            bool rv = true;

            if (patterns.OutEdges == null && graphs.OutEdges == null)
            {
                goto end;
            }
            else if ((patterns.OutEdges != null && graphs.OutEdges == null) || (patterns.OutEdges == null && graphs.OutEdges != null))
            {
                rv = false;
                goto end;
            }

            foreach (var patternEdge in patterns.OutEdges)
            {
                foreach (var graphsEdge in graphs.OutEdges)
                {
                    if (graphsEdge.OutNode != null && patternEdge.OutNode != null && graphsEdge.OutNode.Name == patternEdge.OutNode.Name)
                    {
                        rv = FindNodes(graphsEdge.OutNode, patternEdge.OutNode);
                        if (rv)
                        {
                            goto end;
                        }
                    }
                    else
                    {
                        rv = false;
                    }
                }
            }

            end:

            return rv;
        }
    }
}
