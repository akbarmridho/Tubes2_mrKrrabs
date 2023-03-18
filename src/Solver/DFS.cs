using System;
using System.Collections.Generic;
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
        public DFS(MazeMap m) {
            this.mazeMap = m;
            this.movement = new(m);

            /** Mengisi visitiedCount dengan angka 0 **/
            for(int i = 0; i < m.size; i++)
            {
                List<int> list2 = new List<int>();
                for(int j = 0; j < m.size; j++)
                {
                    list2.Add(0);
                }
                this.visitedCount.Add(list2);
            }
            addCoordinate(new Route(false, m.StartPosition));
        }

        public void addCoordinate(Route coord)
        {
            this.available.Push(coord);
        }

        public MovementHistory getResult() {
            return this.movement;
        }

       

        public bool Moveable(Coordinate c)
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
        public void setVisited(Coordinate c)
        {
            this.visitedCount[c.X][c.Y]++;
        }

        public int getVisited(Coordinate c1)
        {
            return this.visitedCount[c1.Y][c1.X];
        }

        public bool checkPriority(Coordinate c1, Coordinate c2)
        {
            if(getVisited(c1) < getVisited(c2))
            {
                return true;
            }
            return false;
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
                Tuple<int, Movement, Route> l = new(this.getVisited(top), Movement.LEFT, newRoute);
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
                Tuple<int, Movement, Route> r = new(this.getVisited(bottom), Movement.RIGHT,newRoute);
                list.Add(r);
            }

            var sorted = list.OrderByDescending(x => x.Item1).OrderByDescending(x => x.Item2).ToList();

            foreach(var e in sorted)
            {
                this.available.Push(e.Item3);
            }
        }

        public void Visit()
        {
            List<List<int>> visitedNodes;
            Route visit = available.Pop();
            movement.Move(visit.CurrentCoordinate);
        }

        public void Solve()
        {
            while (available.Count > 0 && this.currRoute.TreasureCount < mazeMap.TotalTreasure)
            {
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
