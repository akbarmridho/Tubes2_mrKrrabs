using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace mrKrrabs.Solver
{
    public class Route
    {
        // Attributes
        private int treasureCount;
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
        
        public int TreasureCount
        {
            get => treasureCount;
        }

        public List<Tuple<bool, Coordinate>> PrevCoordinates
        {
            get => prevCoordinate;
        }
        public Route(bool isTreasure, Coordinate coordinate)
        {
            this.isTreasure = isTreasure;

            if (this.isTreasure)
            {
                this.treasureCount = 1;
            }
            else
            {
                this.treasureCount = 0;
            }
            currCoordinate = coordinate;
        }

        // Methods

        public Route(bool isTreasure, Coordinate c, Route prev)
        {
            this.isTreasure = isTreasure;

            if (this.isTreasure)
            {
                treasureCount = prev.TreasureCount + 1;
            }
            else
            {
                treasureCount = prev.TreasureCount;
            }
            currCoordinate = c;
            prevCoordinate = new(prev.PrevCoordinates);
            prevCoordinate.Add(new(prev.isTreasure, prev.CurrentCoordinate));
        }
        
        
        
    }
}

