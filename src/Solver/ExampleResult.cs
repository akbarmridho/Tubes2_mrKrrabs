using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public class ExampleResult : ISolver
    {
        MazeMap mazeMap;
        public ExampleResult(MazeMap m) {
            this.mazeMap = m;
        }

        public MovementHistory getResult()
        {
            MovementHistory history = new(this.mazeMap);

            history.Move(0, 0);
            history.Move(0, 1);
            history.Move(1, 1);
            history.Move(2, 1);
            history.Move(3, 1);
            history.Move(2, 1);
            history.Move(2, 2);
            history.Move(2, 3);
            history.Move(1, 3);

            List<Coordinate> route = new()
            {
                new Coordinate(0, 0),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
                new Coordinate(1, 2),
                new Coordinate(2, 2),
                new Coordinate(3, 2),
                new Coordinate(3, 1)
            };

            history.SetRoute(route);

            return history;
        }
    }
}
