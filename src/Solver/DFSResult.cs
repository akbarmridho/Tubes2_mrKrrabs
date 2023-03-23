using System.Collections.Generic;

namespace mrKrrabs.Solver
{
    public class DFSResult : IResult
    {
        private List<Coordinate> movements = new();
        private bool solved = false;

        public void Move(Coordinate movement)
        {
            this.movements.Add(movement);
        }

        public int GetStepCount()
        {
            return movements.Count - 1;
        }

        public int GetNodeCount()
        {
            return movements.Count;
        }

        public string GetRoutes()
        {
            List<Movement> steps = new List<Movement>();

            for (int i = 0; i < this.movements.Count - 1; i++)
            {
                var end = movements[i + 1];
                var start = movements[i];

                steps.Add(IResult.GetDirection(start, end));
            }

            return string.Join(" - ", steps);
        }

        public void SetSolved()
        {
            this.solved = true;
        }

        public bool IsSolved()
        {
            return this.solved;
        }

        public List<Coordinate> GetMoves()
        {
            return this.movements;
        }
    }
}
