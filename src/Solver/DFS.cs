using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public class DFS : BaseSolver
    {
       
        private Stack<Route> available = new();
        public DFS(MazeMap m) : base(m) {
            AddCoordinate(new Route(false, m.StartPosition));
        }

        private void AddCoordinate(Route coord)
        {
            this.available.Push(coord);
        }

        protected override void AddAvailableMovement(Route route)
        {
            var list = AvailableMovement(route);
            var sorted = list.OrderByDescending(x => x.Item1).ThenByDescending(x => x.Item2).ToList();

            foreach(var e in sorted)
            {
                var temp = currRoute.PrevCoordinate();
                if (e.Item3.CurrentCoordinate == currRoute.PrevCoordinate() && sorted.Count > 1) 
                {
                    continue;
                }
                this.available.Push(e.Item3);
              
            }
        }

        protected override void Visit()
        {

            this.currRoute = available.Pop();
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
   

            // Get route
            // Walking backwards

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
