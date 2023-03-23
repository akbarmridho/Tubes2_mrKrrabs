using System;
using System.Collections.Generic;
using System.Linq;

namespace mrKrrabs.Solver
{
    class BFS
    {
        // Attributes
        protected MazeMap mazeMap;
        protected BFSResult result = new();
        protected bool TSP;

        // BFS
        private Queue<RouteBFS> available = new();
        protected RouteBFS currRoute;

        // Method
        public BFS(MazeMap m, bool TSP)
        {
            this.mazeMap = m;
            this.TSP = TSP;
            this.available.Enqueue(new RouteBFS(false, mazeMap.StartPosition, m));
        }

        public BFSResult GetResult()
        {
            return this.result;
        }

        protected bool Moveable(Coordinate c)
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

        protected List<Tuple<int, Movement, RouteBFS>> AvailableMovement(RouteBFS route)
        {
            List<Tuple<int, Movement, RouteBFS>> list = new();

            var top = route.CurrentCoordinate.Top();
            if (this.Moveable(top))
            {
                bool isTreasure = mazeMap.GetElement(top) == Element.Treasure;
                var newRoute = new RouteBFS(isTreasure, top, route);
                Tuple<int, Movement, RouteBFS> t = new(route.getVisitedRoute(top), Movement.UP, newRoute);
                list.Add(t);
            }

            var left = route.CurrentCoordinate.Left();
            if (this.Moveable(left))
            {
                bool isTreasure = mazeMap.GetElement(left) == Element.Treasure;
                var newRoute = new RouteBFS(isTreasure, left, route);
                Tuple<int, Movement, RouteBFS> l = new(route.getVisitedRoute(left), Movement.LEFT, newRoute);
                list.Add(l);
            }

            var bottom = route.CurrentCoordinate.Bottom();
            if (this.Moveable(bottom))
            {
                bool isTreasure = mazeMap.GetElement(bottom) == Element.Treasure;
                var newRoute = new RouteBFS(isTreasure, bottom, route);
                Tuple<int, Movement, RouteBFS> b = new(route.getVisitedRoute(bottom), Movement.DOWN, newRoute);
                list.Add(b);
            }

            var right = route.CurrentCoordinate.Right();
            if (this.Moveable(right))
            {
                bool isTreasure = mazeMap.GetElement(right) == Element.Treasure;
                var newRoute = new RouteBFS(isTreasure, right, route);
                Tuple<int, Movement, RouteBFS> r = new(route.getVisitedRoute(right), Movement.RIGHT, newRoute);
                list.Add(r);
            }
            return list;
        }

        protected void AddAvailableMovement(RouteBFS route)
        {
            var list = AvailableMovement(route);
            var sorted = list.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
            var minVisited = sorted.Min(x => x.Item1);

            foreach (var e in sorted)
            {
                if (route.PrevCoordinates.Count == 0 || sorted.Count == 1 || e.Item3.CurrentCoordinate != route.PrevCoordinate() && e.Item1 == minVisited)
                {
                    this.available.Enqueue(e.Item3);
                }
                else if (e.Item3.CurrentCoordinate == route.PrevCoordinate())
                {
                    if (sorted.Count > 1 && minVisited != sorted[1].Item1 && e.Item1 == minVisited)
                    {
                        this.available.Enqueue(e.Item3);
                    }
                }
            }
        }

        protected void Visit()
        {
            currRoute = available.Dequeue();
            currRoute.setVisitedRoute(currRoute.CurrentCoordinate);
            result.Move(currRoute);
            AddAvailableMovement(currRoute);
        }

        public void Solve()
        {
            int i = 0;
            do
            {
                Visit();
                i++;
            } while (available.Count > 0 && this.currRoute.TreasureCount < mazeMap.TotalTreasure);

            // Solveable
            if (mazeMap.TotalTreasure == this.currRoute.TreasureCount)
            {

                // TSP
                if (this.TSP)
                {
                    // Clear Queue
                    available.Clear();
                    AddAvailableMovement(currRoute);
                    do
                    {
                        Visit();
                    } while (available.Count > 0 && mazeMap.GetElement(this.currRoute.CurrentCoordinate) != Element.KrustyKrab);

                }

                this.result.SetSolved();
                var routes = currRoute.PrevCoordinates.ToList();
                routes.Add(new(currRoute.IsTreasure, currRoute.CurrentCoordinate));

                this.result.SetFinalRoute(routes.Select(x => x.Item2).ToList());
            }
        }
    }
}