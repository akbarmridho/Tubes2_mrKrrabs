using System;
using System.Collections.Generic;
using System.Linq;

namespace mrKrrabs.Solver
{
    public class DFS
    {
        private MazeMap mazeMap;
        private DFSResult result = new();
        private List<List<int>> visitedCount = new();
        private Route currentRoute;
        private bool TSP;
        private Stack<Route> available = new();

        public DFS(MazeMap m, bool TSP)
        {
            for (int i = 0; i < m.size; i++)
            {
                List<int> list2 = new();
                for (int j = 0; j < m.size; j++)
                {
                    list2.Add(0);
                }
                this.visitedCount.Add(list2);
            }

            this.mazeMap = m;
            this.TSP = TSP;
            AddCoordinate(new Route(false, m.StartPosition));
        }

        public DFSResult GetResult()
        {
            return this.result;
        }

        private bool Moveable(Coordinate c)
        {
            if (c.X < 0 || c.X >= mazeMap.size || c.Y < 0 || c.Y >= mazeMap.size)
            {
                return false;
            }

            if (mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure || mazeMap.GetElement(c) == Element.KrustyKrab)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetVisited(Coordinate c)
        {
            this.visitedCount[c.Y][c.X]++;
        }

        protected int GetVisited(Coordinate c1)
        {
            return this.visitedCount[c1.Y][c1.X];
        }

        private void AddCoordinate(Route coord)
        {
            this.available.Push(coord);
        }

        private void AddAvailableMovement(Route route)
        {
            var list = AvailableMovement(route);
            var sorted = list.OrderByDescending(x => x.Item1).ThenByDescending(x => x.Item2).ToList();

            foreach (var e in sorted)
            {
                var temp = currentRoute.PrevCoordinate();
                if (e.Item3.CurrentCoordinate == currentRoute.PrevCoordinate() && sorted.Count > 1)
                {
                    continue;
                }
                this.available.Push(e.Item3);

            }
        }

        private List<Tuple<int, Movement, Route>> AvailableMovement(Route route)
        {
            List<Tuple<int, Movement, Route>> list = new();

            var top = route.CurrentCoordinate.Top();
            if (this.Moveable(top))
            {
                bool isTreasure = mazeMap.GetElement(top) == Element.Treasure;
                var newRoute = new Route(isTreasure, top, route);
                Tuple<int, Movement, Route> t = new(this.GetVisited(top), Movement.UP, newRoute);
                list.Add(t);
            }

            var left = route.CurrentCoordinate.Left();
            if (this.Moveable(left))
            {
                bool isTreasure = mazeMap.GetElement(left) == Element.Treasure;
                var newRoute = new Route(isTreasure, left, route);
                Tuple<int, Movement, Route> l = new(this.GetVisited(left), Movement.LEFT, newRoute);
                list.Add(l);
            }

            var bottom = route.CurrentCoordinate.Bottom();
            if (this.Moveable(bottom))
            {
                bool isTreasure = mazeMap.GetElement(bottom) == Element.Treasure;
                var newRoute = new Route(isTreasure, bottom, route);
                Tuple<int, Movement, Route> b = new(this.GetVisited(bottom), Movement.DOWN, newRoute);
                list.Add(b);
            }

            var right = route.CurrentCoordinate.Right();
            if (this.Moveable(right))
            {
                bool isTreasure = mazeMap.GetElement(right) == Element.Treasure;
                var newRoute = new Route(isTreasure, right, route);
                Tuple<int, Movement, Route> r = new(this.GetVisited(right), Movement.RIGHT, newRoute);
                list.Add(r);
            }

            return list;
        }

        protected void Visit()
        {
            this.currentRoute = available.Pop();
            SetVisited(this.currentRoute.CurrentCoordinate);
            result.Move(currentRoute.CurrentCoordinate);
            AddAvailableMovement(currentRoute);
        }

        public void Solve()
        {
            do
            {
                Visit();
            } while (available.Count > 0 && this.currentRoute.TreasureCount < mazeMap.TotalTreasure);

            // Get route

            // Solveable
            if (mazeMap.TotalTreasure == this.currentRoute.TreasureCount)
            {
                if (this.TSP)
                {
                    do
                    {
                        Visit();
                    } while (available.Count > 0 && mazeMap.GetElement(this.currentRoute.CurrentCoordinate) != Element.KrustyKrab);

                }

                this.result.SetSolved();
            }
        }
    }
}
