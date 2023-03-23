using System.Collections.Generic;

namespace mrKrrabs.Solver
{
    public class BFSResult : IResult
    {
        private List<RouteBFS> routeHistory = new();
        private List<Coordinate> finalRoute = new();
        private bool solved = false;
        private int nodeCount = 0;

        public void Move(RouteBFS routeBFS)
        {
            nodeCount++;
            this.routeHistory.Add(routeBFS);
        }

        public int GetNodeCount()
        {
            return nodeCount;
        }

        public string GetRoutes()
        {
            if (!this.solved)
            {
                return "";
            }

            List<Movement> steps = new List<Movement>();

            for (int i = 0; i < this.finalRoute.Count - 1; i++)
            {
                var end = finalRoute[i + 1];
                var start = finalRoute[i];

                steps.Add(IResult.GetDirection(start, end));
            }

            return string.Join(" - ", steps);
        }

        public int GetStepCount()
        {
            if (this.solved)
            {
                return finalRoute.Count - 1;
            }

            return 0;
        }

        public bool IsSolved()
        {
            return this.solved;
        }

        public void SetSolved()
        {
            this.solved = true;
        }

        public void SetFinalRoute(List<Coordinate> route)
        {
            this.finalRoute = route;
        }

        public List<Coordinate> GetFinalRoute()
        {
            return this.finalRoute;
        }

        public List<RouteBFS> GetMoves()
        {
            return this.routeHistory;
        }
    }
}
