using mrKrrabs.Solver;

namespace mrKrrabs.Models
{
    public enum AvailableAlgorithm
    {
        BFS,
        DFS
    }

    public class Form
    {
        AvailableAlgorithm algorithm;
        bool useTsp;
        MazeMap map;
        int delay;

        public Form(AvailableAlgorithm algorithm, bool useTsp, MazeMap map, int delay)
        {
            this.algorithm = algorithm;
            this.useTsp = useTsp;
            this.map = map;
            this.delay = delay;
        }

        public AvailableAlgorithm Algorithm
        {
            get => algorithm;
        }
        public bool UseTsp { get => useTsp; }

        public MazeMap Map { get => map; }

        public int Delay { get => delay; }
    }
}