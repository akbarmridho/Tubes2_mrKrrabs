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
        public DFS(MazeMap m, bool TSP) : base(m, TSP) {
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
        public bool IsMember(Coordinate c, List <Coordinate> r)
        {
            if(r.Count == 0) { return false; }
            
            for (int i = 0;i < r.Count; i++)
            {
                if(c == r[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDuplicate(List<Coordinate> c)
        {
            for(int i = 0;i < c.Count; i++)
            {
                for(int j = c.Count-1; j > i; j--)
                {
                    if (c[i] == c[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DeleteDuplicate(List<Coordinate> c)
        {
            int start = -9999;
            int end =-9999;
            bool found = false;
            for(int i = 0; i < c.Count; i++)
            {
                for(int k = c.Count-1;k > i; k--)
                {
                    if(c[i] == c[k])
                    {
                        start = i;
                        end = k;
                        found = true;
                        break;
                        
                    }
                }
                if(found) { break; }
            }
            if(end != -9999 && start != -9999)
            {
                for (int i = end; i > start; i--)
                {
                    c.RemoveAt(i);
                }
            }
            
        }

        public override void Solve()
        {
            do
            {
                Visit();
            } while (available.Count > 0 && this.currRoute.TreasureCount < mazeMap.TotalTreasure);
            
            // Get route

            // Solveable
            if (mazeMap.TotalTreasure == this.currRoute.TreasureCount)
            {
                if (this.TSP)
                {
                    do
                    {
                        Visit();
                    } while (available.Count > 0 && mazeMap.GetElement(this.currRoute.CurrentCoordinate) != Element.KrustyKrab);

                }
                this.movement.Solved = true;
                var routes = currRoute.PrevCoordinates.ToList();
                
                routes.Add(new(currRoute.IsTreasure, currRoute.CurrentCoordinate));
                this.movement.SetRoute(routes.Select(x => x.Item2).ToList());
            }
        }
    }
}
