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
        int x;
        int y;
        readonly int startX;
        readonly int startY;
        List<Movement> movements = new List<Movement>();
        List<Tuple<int, int>> movementCoordinates = new List<Tuple<int, int>>();
        List<Movement> routes = new List<Movement>();
        List<Tuple<int, int>> routeCoordinates = new List<Tuple<int, int>>();

        public MovementHistory(int startX, int startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.x = startX;
            this.y = startY;
        }

        public void Move(Movement movement)
        {
            switch(movement)
            {
                case Movement.UP:
                    this.y--;
                    break;
                case Movement.DOWN:
                    this.y--;
                    break;
                case Movement.LEFT:
                    this.x--;
                    break;
                case Movement.RIGHT:
                    this.x++;
                    break;
            }

            this.movements.Add(movement);
            this.movementCoordinates.Add(new Tuple<int,int>(this.x, this.y));
        }

        public void SetRoute(List<Movement> routes)
        {
            this.routes = routes;
            this.x = this.startX; 
            this.y = this.startY;

            foreach(var movement in this.routes)
            {
                switch (movement)
                {
                    case Movement.UP:
                        this.y--;
                        break;
                    case Movement.DOWN:
                        this.y--;
                        break;
                    case Movement.LEFT:
                        this.x--;
                        break;
                    case Movement.RIGHT:
                        this.x++;
                        break;
                }

                this.movementCoordinates.Add(new Tuple<int, int>(this.x, this.y));
            }
        }

        public List<Tuple<int,int>> RouteCoordinates { get => routeCoordinates; }
        public List<Tuple<int, int>> MovementCoordinates { get => movementCoordinates; }

        public int StepCount { get => movementCoordinates.Count; }
    }
}
