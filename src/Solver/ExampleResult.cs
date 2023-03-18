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
        public ExampleResult() { }

        public MovementHistory getResult()
        {
            MovementHistory history = new();

            history.Move(new Coordinate(0, 0));
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
                new Coordinate(0, 1),
                new Coordinate(1, 1),
                new Coordinate(2, 1),
                new Coordinate(2, 2),
                new Coordinate(2, 3),
                new Coordinate(1, 3)
            };

            history.SetRoute(route);

            return history;
        }
    }
}
