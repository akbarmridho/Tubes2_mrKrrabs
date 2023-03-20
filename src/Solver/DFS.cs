using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public class DFS : ISolver
    {
        private MazeMap mazeMap;
        private MovementHistory movement;
        private Stack<Route> available = new();
        private List<List<int>> visitedCount = new();
        private Route currRoute;
        private Coordinate lastCoordinate;
        private Movement lastMove;
        public DFS(MazeMap m) {
            this.mazeMap = m;
            this.movement = new(m);

            /** Mengisi visitedCount dengan angka 0 **/
            for(int i = 0; i < m.size; i++)
            {
                List<int> list2 = new List<int>();
                for(int j = 0; j < m.size; j++)
                {
                    list2.Add(0);
                }
                this.visitedCount.Add(list2);
            }
            AddCoordinate(new Route(false, m.StartPosition));
        }

        private void AddCoordinate(Route coord)
        {
            this.available.Push(coord);
        }

        public MovementHistory getResult() {
            return this.movement;
        }

        private bool Moveable(Coordinate c)
        {
            if(c.X < 0 || c.X >= mazeMap.size || c.Y < 0 || c.Y >= mazeMap.size)
            {
                return false;
            }

            if(mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void setVisited(Coordinate c)
        {
            this.visitedCount[c.Y][c.X]++;
        }

        private int getVisited(Coordinate c1)
        {
            return this.visitedCount[c1.Y][c1.X];
        }

        private void AvailableMovement()
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
                Tuple<int, Movement, Route> l = new(this.getVisited(left), Movement.LEFT, newRoute);
                list.Add(l);
            }

            var bottom = currRoute.CurrentCoordinate.Bottom();
            if (this.Moveable(bottom))
            {
                bool isTreasure = mazeMap.GetElement(bottom) == Element.Treasure;
                var newRoute = new Route(isTreasure, bottom, currRoute);
                Tuple<int, Movement, Route> b= new(this.getVisited(bottom), Movement.DOWN, newRoute);
                list.Add(b);
            }

            var right = currRoute.CurrentCoordinate.Right();
            if (this.Moveable(right))
            {
                bool isTreasure = mazeMap.GetElement(right) == Element.Treasure;
                var newRoute = new Route(isTreasure, right, currRoute);
                Tuple<int, Movement, Route> r = new(this.getVisited(right), Movement.RIGHT,newRoute);
                list.Add(r);
            }

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

        private void Visit()
        {
            if(this.currRoute != null)
            {
                this.lastCoordinate = this.currRoute.CurrentCoordinate;
            }
            
            this.currRoute = available.Pop();
            setVisited(this.currRoute.CurrentCoordinate);
            movement.Move(currRoute.CurrentCoordinate);
            
            AvailableMovement();
        }

        public void Solve()
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
