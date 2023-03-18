using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace mrKrrabs.Solver
{
    public class Route
    {
        // Attributes
        private bool isTreasure;
        private Coordinate currCoordinate;
        private List<Tuple<bool,Coordinate>> prevCoordinate = new();

        public bool IsTreasure
        {
            get => isTreasure;
        }

        public Coordinate CurrentCoordinate
        {
            get => currCoordinate;
        }

        public List<Tuple<bool, Coordinate>> PrevCoordinates
        {
            get => prevCoordinate;
        }
        public Route(bool isTreasure, Coordinate coordinate)
        {
            this.isTreasure = isTreasure;
            currCoordinate = coordinate;
        }

        // Methods

        public Route(bool isTreasure, Coordinate c, Route prev)
        {
            this.isTreasure = isTreasure;
            currCoordinate = c;
            prevCoordinate = new(prev.PrevCoordinates);
            prevCoordinate.Add(new(prev.isTreasure, prev.CurrentCoordinate));
        }
        
        
        
    }
}

