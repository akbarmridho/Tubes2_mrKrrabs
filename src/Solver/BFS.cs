using System;
using System.Collections.Generic;
using System.Linq;

namespace mrKrrabs.Solver
{
    class BFS : BaseSolver
    {
        // Attributes
        private Queue<Route> available = new();
        
        // Method
        public BFS(MazeMap m) : base(m)
        {
            this.available.Enqueue(new Route(false, mazeMap.StartPosition));
        }

        protected override void AddAvailableMovement(Route route)
        {
            var list = AvailableMovement(route);
            var sorted = list.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            foreach(var e in sorted)
            {
                if(e.Item3.CurrentCoordinate != route.PrevCoordinate())
                {
                    this.available.Enqueue(e.Item3);
                }
            }
        }

        protected override void Visit()
        {
            currRoute = available.Dequeue();
            setVisited(this.currRoute.CurrentCoordinate);
            movement.Move(currRoute.CurrentCoordinate);
            AddAvailableMovement(currRoute);
        }

        public override void Solve()
        {
            do
            {
                Visit();
            } while (available.Count > 0 && this.currRoute.TreasureCount < mazeMap.TotalTreasure);

            // Solveable
            if (mazeMap.TotalTreasure == this.currRoute.TreasureCount)
            {
                this.movement.Solved = true;
                var routes = currRoute.PrevCoordinates.ToList();
                routes.Add(new(currRoute.IsTreasure, currRoute.CurrentCoordinate));

                this.movement.SetRoute(routes.Select(x => x.Item2).ToList());
            }
        }
    }  
}