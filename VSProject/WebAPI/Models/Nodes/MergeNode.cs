﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class MergeNode : Node
    {
        public MergeNode(List<Edge> inEdges, List<Edge> outEdges)
        {
            Name = String.Empty;
            InEdges = inEdges;
            OutEdges = outEdges;
        }

        public override string Name
        {
            get => Name;
            set => throw new NotSupportedException("Cannot set name to merge node!");
        }
        public override List<Edge> InEdges
        {
            get => InEdges;
            set => InEdges = value.Count > 0 ? value
                : throw new ArgumentException("Merge node must have at least one in edge!");
        }
        public override List<Edge> OutEdges
        {
            get => OutEdges;
            set => OutEdges = value.Count == 1 ? value
                : throw new ArgumentException("Merge node cannot have more or less than one out edge!");
        }
    }
}