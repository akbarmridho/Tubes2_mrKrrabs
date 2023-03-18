using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public enum Movement
    {
        RIGHT = 0,
        DOWN = 1,
        LEFT = 2,
        UP = 3
    }
    public class MovementHistory
    {
        private bool solved = false;
        List<Coordinate> movements = new();
        List<Coordinate> routes = new();
        MazeMap mazeMap;

        public MovementHistory(MazeMap mazeMap)
        {
            this.mazeMap = mazeMap;
        }

        public MazeMap Maze { get { return mazeMap; } }

        public void Move(Coordinate movement)
        {
            this.movements.Add(movement);
        }

        public void Move(int row, int col)
        {
            this.movements.Add(new Coordinate(col, row));
        }

        public void SetRoute(List<Coordinate> routes)
        {
            this.routes = routes;
        }

        public bool Solved
        {
            get => solved;
            set => solved = value;
        }
        
        public List<Coordinate> Routes { get => routes; }
        public List<Coordinate> Movements { get => movements; }

        public int StepCount { get => movements.Count; }

        public int GetNodeCount()
        {
            HashSet<Coordinate> nodes = new HashSet<Coordinate>();

            foreach (Coordinate node in this.movements)
            {
                nodes.Add(node);
            }

            return nodes.Count;
        }

        public static Movement GetDirection(Coordinate start, Coordinate end)
        {
            int xDif = end.X- start.X;
            int yDif = end.Y- start.Y;

            if (xDif == 0 && yDif == -1)
            {
                return Movement.UP;
            } else if (xDif == 0 && yDif == 1)
            {
                return Movement.DOWN;
            } else if (xDif == -1 && yDif == 0)
            {
                return Movement.LEFT;
            } else if (xDif == 1 && yDif == 0)
            {
                return Movement.RIGHT;
            }

            throw new Exception("Invalid movement");
        }
    }
}
