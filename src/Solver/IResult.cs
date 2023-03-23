using System;

namespace mrKrrabs.Solver
{
    public enum Movement
    {
        RIGHT = 0,
        DOWN = 1,
        LEFT = 2,
        UP = 3
    }

    public interface IResult
    {
        public int GetStepCount();
        public int GetNodeCount();
        public string GetRoutes();

        public void SetSolved();

        public bool IsSolved();

        public static Movement GetDirection(Coordinate start, Coordinate end)
        {
            int xDif = end.X - start.X;
            int yDif = end.Y - start.Y;

            if (xDif == 0 && yDif == -1)
            {
                return Movement.UP;
            }
            else if (xDif == 0 && yDif == 1)
            {
                return Movement.DOWN;
            }
            else if (xDif == -1 && yDif == 0)
            {
                return Movement.LEFT;
            }
            else if (xDif == 1 && yDif == 0)
            {
                return Movement.RIGHT;
            }

            throw new Exception("Invalid movement");
        }
    }
}
