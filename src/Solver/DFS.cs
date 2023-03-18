using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public class DFS : ISolver
    {
        private MazeMap mazeMap;
        private List<List<int>> visitedCount = new();
        private MovementHistory movement;
        private Stack<Coordinate> available = new();
        private Coordinate currentPosition; 
        private int treasureCollected;
        public DFS(MazeMap m) {
            this.mazeMap = m;
            this.movement = new(m);

            /** Mengisi visitiedCount dengan angka 0 **/
            for(int i = 0; i < m.size; i++)
            {
                List<int> list2 = new List<int>();
                for(int j = 0; j < m.size; j++)
                {
                    list2.Add(0);
                }
                this.visitedCount.Add(list2);
            }
            this.currentPosition = m.StartPosition;
            this.treasureCollected = 0;
        }

        public void addCoordinate(Coordinate coord)
        {
            this.available.Push(coord);
        }

        public MovementHistory getResult() {
            return this.movement;
        }

        public void setVisited(Coordinate c)
        {
            this.visitedCount[c.X][c.Y]++;
        }

        public bool Moveable(Coordinate c)
        {
            if(c.X < 0 || c.X >= mazeMap.size || c.Y < 0 || c.Y >= mazeMap.size)
            {
                return false;
            }

            if(mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getVisited(Coordinate c1)
        {
            return this.visitedCount[c1.Y][c1.X];
        }

        public bool checkPriority(Coordinate c1, Coordinate c2)
        {
            if(getVisited(c1) < getVisited(c2))
            {
                return true;
            }
            return false;
        }

        public void AvailableMovement()
        {
            List<Tuple<int, Movement, Coordinate>> list = new();

            var top = currentPosition.Top();
            if (this.Moveable(top))
            {
                Tuple<int, Movement, Coordinate> t = new(this.getVisited(top), Movement.UP, top);
                list.Add(t);
            }

            var left = currentPosition.Left();
            if (this.Moveable(left))
            {
                Tuple<int, Movement, Coordinate> l = new(this.getVisited(left), Movement.LEFT, left);
                list.Add(l);
            }

            var bottom = currentPosition.Bottom();
            if (this.Moveable(bottom))
            {
                Tuple<int, Movement, Coordinate> b = new(this.getVisited(bottom), Movement.DOWN, bottom);
                list.Add(b);
            }

            var right = currentPosition.Right();
            if (this.Moveable(right))
            {
                Tuple<int, Movement, Coordinate> b = new(this.getVisited(bottom), Movement.RIGHT, right);
                list.Add(b);
            }

            var sorted = list.OrderByDescending(x => x.Item1).OrderByDescending(x => x.Item2).ToList();

            foreach(var e in sorted)
            {
                this.available.Push(e.Item3);
            }
        }

        public void Visit()
        {
            Coordinate visit = available.Pop();
            if(mazeMap.GetElement(visit) == Element.Treasure)
            {
                this.treasureCollected++;
            }
            this.setVisited(visit);
        }

        public void Solve()
        {
            while(available.Count > 0 && treasureCollected < mazeMap.TotalTreasure) {
                AvailableMovement();
                Visit();
            }
        }

    }
}
