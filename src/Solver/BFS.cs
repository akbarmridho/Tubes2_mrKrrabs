using System;
using System.Collections.Generic;

namespace mrKrrabs.Solver
{
    class BFS : ISolver
    {
        // Attributes
        private MazeMap mazeMap;
        private MovementHistory movement;
        private Queue<Coordinate> available = new();
        private Coordinate currPosition;
        private int treasureCollected;
        
        // Methods
        public BFS(MazeMap m)
        {
            this.mazeMap = m;
            this.movement = new MovementHistory(m);
            this.currPosition = new Coordinate(0, 0);
            this.treasureCollected = 0;
        }

        public void addCoordinate(Coordinate coord)
        {
            this.available.Enqueue(coord);
        }

        public MovementHistory getResult()
        {
            return this.movement;
        }

        public bool Moveable(Coordinate c)
        {
            if (mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure) {
                return true;
            }
            else {
                return false;
            }
        }

        public void AvailableMovement()
        {
            /* Mengecek prioritas */
            if (Moveable(this.currPosition.Top())){
                addCoordinate(this.currPosition.Top());
            }
            if (Moveable(this.currPosition.Left())) {
                addCoordinate(this.currPosition.Left());
            }
            if (Moveable(this.currPosition.Bottom())){
                addCoordinate(this.currPosition.Bottom());
            }
            if (Moveable(this.currPosition.Right())) {
                addCoordinate(this.currPosition.Right());
            }
        }

        public void Visit()
        {
            List<List<int>> visitedNodes;
            Coordinate visit = available.Dequeue();
            
            if (mazeMap.GetElement(visit) == Element.Treasure)
            {
                this.treasureCollected++;
            }
            
            movement.Move(visit);
        }

        public void Solve()
        {
            while(available.Count > 0 && treasureCollected < mazeMap.TotalTreasure) {
                AvailableMovement();
                Visit();
                
            }
            
            // Get route
            // Walking backwards

            // Solveable
            if (mazeMap.TotalTreasure == treasureCollected)
            {
                this.movement.Solved = true;
            }
        }
        
        
        



    }  
}