using Microsoft.CodeAnalysis.CSharp.Syntax;
using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class ResultViewModel: ViewModelBase
    {
        MovementHistory result;

        public int StepCount { get; set; }
        public int NodeCount { get; set; }
        public string TimeExec { get; set; }
        public string Route { get; set; }
        public string AlgorithmDesc { get; set; }

        public ResultViewModel(MovementHistory result, float timeExec, bool useDfs, bool useTsp)
        {
            this.result = result;
            this.StepCount = result.StepCount;
            this.NodeCount = result.GetNodeCount();

            if (timeExec > 1000)
            {
                this.TimeExec = string.Format("{0:0.00}", timeExec) + " s";
            } else
            {
                this.TimeExec = string.Format("{0:0.00}", timeExec) + " ms";
            }

            if (useDfs)
            {
                this.AlgorithmDesc = "Depth First Search (DFS)";
            } else
            {
                this.AlgorithmDesc = "Breadth First Search (BFS)";
            }

            if (useTsp)
            {
                this.AlgorithmDesc += " dengan TSP";
            } else
            {
                this.AlgorithmDesc += " tanpa TSP";
            }

            List<Movement> route = new List<Movement>();

            for(int i = 0; i < result.Routes.Count - 1; i++)
            {
                var end = result.Routes[i+1];
                var start = result.Routes[i];

                route.Add(MovementHistory.GetDirection(start, end));
            }

            this.Route = string.Join(" - ", route);
        }
    }
}
