using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public enum Movement
    {
        UP,
        DOWN, 
        LEFT, 
        RIGHT
    }
    public class MovementHistory
    {
        List<Coordinate> movements = new();
        List<Coordinate> routes = new();

        public MovementHistory()
        {
        }

        public void Move(Coordinate movement)
        {
            this.movements.Add(movement);
        }

        public void SetRoute(List<Coordinate> routes)
        {
            this.routes = routes;
        }

        public List<Coordinate> Routes { get => routes; }
        public List<Coordinate> Movements { get => movements; }

        public int StepCount { get => movements.Count; }
    }
}
