﻿using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Models
{
    public enum AvailableAlgorithm
    {
        BFS,
        DFS
    }

    public class Form
    {
        AvailableAlgorithm algorithm;
        bool useTsp;
        MazeMap map;

        public Form(AvailableAlgorithm algorithm, bool useTsp, MazeMap map)
        {
            this.algorithm = algorithm;
            this.useTsp = useTsp;
            this.map = map;
        }

        public AvailableAlgorithm Algorithm
        {
            get => algorithm;
        }
        public bool UseTsp { get => useTsp; }

        public MazeMap Map { get => map; }
    }
}