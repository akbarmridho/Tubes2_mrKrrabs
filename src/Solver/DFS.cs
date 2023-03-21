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
                List<List<Coordinate>> temp = new List<List<Coordinate>>();
                List<Coordinate> final = new List<Coordinate>();
                int i = 0;
                int totalFound = 0;
                while (totalFound < mazeMap.TotalTreasure)
                {
                    List<Coordinate> c = new List<Coordinate>();

                    Coordinate temp2 = routes[i].Item2;
                    while (!mazeMap.treasureCoordinates.Contains(routes[i].Item2))
                    {
                        c.Add(temp2);
                        i++;
                        temp2 = routes[i].Item2;
                    }
                    mazeMap.treasureCoordinates.Remove(temp2);
                    c.Add(temp2);
                    i++;
                    temp.Add(c);
                    totalFound++;
                }
                foreach (List<Coordinate> c in temp)
                {
                    int j = 0;
                    List<Coordinate> temp2 = new List<Coordinate>();

                    while (j < c.Count)
                    {
                        Coordinate curr = c[j];
                        if (!IsMember(curr, temp2))
                        {
                            temp2.Add(curr);
                            j++;
                        }
                        else
                        {
                            temp2.Remove(c[j - 1]);
                            while (IsMember(c[j], temp2))
                            {
                                temp2.Remove(c[j]);
                                j++;
                            }
                            temp2.Add(c[j - 1]);

                        }
                    }
                    final.AddRange(temp2);
                }
                this.movement.SetRoute(final.ToList());


            }
        }
    }
}
