using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace mrKrrabs.Solver
{
    public class Route
    {
        // Attributes
        private int treasureCount
        {
            get => treasures.Count;
        }
        private bool isTreasure;
        private HashSet<Coordinate> treasures;
        private Coordinate currCoordinate;
        private List<Tuple<bool, Coordinate>> prevCoordinate = new();

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
        public Coordinate PrevCoordinate()
        {
            return this.prevCoordinate[this.prevCoordinate.Count - 1].Item2;
        }
        public List<Tuple<bool, Coordinate>> PrevCoordinates
        {
            get => prevCoordinate;
        }
        public Route(bool isTreasure, Coordinate coordinate)
        {
            this.isTreasure = isTreasure;
            this.treasures = new();

            if (this.isTreasure)
            {
                this.treasures.Add(coordinate);
                
            }
            currCoordinate = coordinate;
        }

        // Methods
        public Route(bool isTreasure, Coordinate c, Route prev)
        {
            this.isTreasure = isTreasure;
            this.treasures = new(prev.treasures);

            if (this.isTreasure)
            {
                treasures.Add(c);
            }
            
            currCoordinate = c;
            prevCoordinate = new(prev.PrevCoordinates);
            prevCoordinate.Add(new(prev.isTreasure, prev.CurrentCoordinate));
        }
        
        
        
    }
}