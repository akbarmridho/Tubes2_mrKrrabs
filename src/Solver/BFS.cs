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
        private List<List<int>> visitedCount = new();
        private Route currRoute;
        // private int treasureCollected;
        
        // Methods
        public BFS(MazeMap m)
        {
            this.mazeMap = m;
            this.movement = new MovementHistory(m);
            // this.treasureCollected = 0;
            //addCoordinate(new Route(false, m.StartPosition));
            this.currRoute = new Route(false, m.StartPosition);
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
            if (c.X < 0 || c.X >= mazeMap.size || c.Y < 0 || c.Y >= mazeMap.size)
            {
                return false;
            }
            if (mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure) {
                return true;
            }
            else {
                return false;
            }
        }
        
        public void setVisited(Coordinate c)
        {
            this.visitedCount[c.X][c.Y]++;
        }
        
        public int getVisited(Coordinate c1)
        {
            return this.visitedCount[c1.Y][c1.X];
        }

        public void AvailableMovement()
        {
            List<Tuple<int, Movement, Route>> list = new();
            
            var top = currRoute.CurrentCoordinate.Top();
            if (this.Moveable(top))
            {
                bool isTreasure = mazeMap.GetElement(top) == Element.Treasure;
                var newRoute = new Route(isTreasure, top, currRoute);
                Tuple<int, Movement, Route> t = new(this.getVisited(top), Movement.UP, newRoute);
                list.Add(t);
            }
            
            var left = currRoute.CurrentCoordinate.Left();
            if (this.Moveable(left))
            {
                bool isTreasure = mazeMap.GetElement(left) == Element.Treasure;
                var newRoute = new Route(isTreasure, left, currRoute);
                Tuple<int, Movement, Route> t = new(this.getVisited(top), Movement.LEFT, newRoute);
                list.Add(t);
            }
            
            var bottom = currRoute.CurrentCoordinate.Bottom();
            if (this.Moveable(bottom))
            {
                bool isTreasure = mazeMap.GetElement(bottom) == Element.Treasure;
                var newRoute = new Route(isTreasure, bottom, currRoute);
                Tuple<int, Movement, Route> t = new(this.getVisited(top), Movement.DOWN, newRoute);
                list.Add(t);
            }
            
            var right = currRoute.CurrentCoordinate.Right();
            if (this.Moveable(right))
            {
                bool isTreasure = mazeMap.GetElement(right) == Element.Treasure;
                var newRoute = new Route(isTreasure, right, currRoute);
                Tuple<int, Movement, Route> t = new(this.getVisited(right), Movement.RIGHT, newRoute);
                list.Add(t);
            }
            
            
        }

        public void Visit()
        {
            List<List<int>> visitedNodes;
            Route visit = available.Dequeue();
            
            /*
            if (mazeMap.GetElement(visit.CurrentCoordinate) == Element.Treasure)
            {
                
                this.treasureCollected++;
            }
            */
            movement.Move(visit.CurrentCoordinate);
        }

        public void Solve()
        {
            while(available.Count > 0 && this.currRoute.TreasureCount < mazeMap.TotalTreasure) {
                Visit();
                AvailableMovement();
            }
            
            // Get route
            // Walking backwards

            // Solveable
            if (mazeMap.TotalTreasure == this.currRoute.TreasureCount)
            {
                this.movement.Solved = true;
            }
        }
    }  
}