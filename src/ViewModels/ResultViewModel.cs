using mrKrrabs.Solver;

namespace mrKrrabs.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        IResult result;

        public int StepCount { get; set; }
        public int NodeCount { get; set; }
        public string TimeExec { get; set; }
        public string Route { get; set; }
        public string AlgorithmDesc { get; set; }

        public ResultViewModel(IResult result, float timeExec, bool useDfs, bool useTsp)
        {
            this.result = result;
            this.StepCount = result.GetStepCount();
            this.NodeCount = result.GetNodeCount();

            if (timeExec > 1000)
            {
                this.TimeExec = string.Format("{0:0.00}", timeExec / 1000.0) + " s";
            }
            else
            {
                this.TimeExec = string.Format("{0:0.00}", timeExec) + " ms";
            }

            if (useDfs)
            {
                this.AlgorithmDesc = "Depth First Search (DFS)";
            }
            else
            {
                this.AlgorithmDesc = "Breadth First Search (BFS)";
            }

            if (useTsp)
            {
                this.AlgorithmDesc += " dengan TSP";
            }
            else
            {
                this.AlgorithmDesc += " tanpa TSP";
            }

            if (this.result.IsSolved())
            {
                this.Route = this.result.GetRoutes();
            }
            else
            {
                this.Route = "Rute tidak ditemukan";
            }
        }
    }
}
