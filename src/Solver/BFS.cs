using System;
using System.Collections.Generic;

namespace mrKrrabs.Solver
{
    class BFS : ISolver
    {
        // Attributes
        private MazeMap mazeMap;
        private MovementHistory movement;
        private Queue<Route> available = new();
        private Coordinate currPosition;
        private Route currRoute;
        private int treasureCollected;
        
        // Methods
        public BFS(MazeMap m)
        {
            this.mazeMap = m;
            this.movement = new MovementHistory(m);
            this.currPosition = new Coordinate(0, 0);
            this.treasureCollected = 0;
            addCoordinate(new Route(false, m.StartPosition));
        }

        public void addCoordinate(Route route)
        {
            this.available.Enqueue(route);
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
                Coordinate p = this.currPosition.Top();
                bool isTreasure = mazeMap.GetElement(p) == Element.Treasure;
                var newRoute = new Route(isTreasure, p, currRoute);
                addCoordinate(newRoute);
            }
            if (Moveable(this.currPosition.Left())) {
                Coordinate p = this.currPosition.Top();
                bool isTreasure = mazeMap.GetElement(p) == Element.Treasure;
                var newRoute = new Route(isTreasure, p, currRoute);
                addCoordinate(newRoute);
            }
            if (Moveable(this.currPosition.Bottom())){
                Coordinate p = this.currPosition.Top();
                bool isTreasure = mazeMap.GetElement(p) == Element.Treasure;
                var newRoute = new Route(isTreasure, p, currRoute);
                addCoordinate(newRoute);
            }
            if (Moveable(this.currPosition.Right())) {
                Coordinate p = this.currPosition.Top();
                bool isTreasure = mazeMap.GetElement(p) == Element.Treasure;
                var newRoute = new Route(isTreasure, p, currRoute);
                addCoordinate(newRoute);
            }
        }

        public void Visit()
        {
            List<List<int>> visitedNodes;
            Route visit = available.Dequeue();
            
            if (mazeMap.GetElement(visit.CurrentCoordinate) == Element.Treasure)
            {
                this.treasureCollected++;
            }
            movement.Move(visit.CurrentCoordinate);
        }

        public void Solve()
        {
            while(available.Count > 0 && treasureCollected < mazeMap.TotalTreasure) {
                Visit();
                AvailableMovement();
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