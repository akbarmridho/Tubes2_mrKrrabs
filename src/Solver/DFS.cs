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
        private MovementHistory movement;
        private Stack<Coordinate> available = new();
        private Coordinate currentPosition; 
        public DFS(MazeMap m) {
            this.mazeMap = m;
            this.movement = new(m);
            this.currentPosition = new Coordinate(0, 0);
        }

        public void addCoordinate(Coordinate coord)
        {
            this.available.Push(coord);
        }

        public MovementHistory getResult() {
            return this.movement;
        }

        public bool Moveable(Coordinate c)
        {
            if(mazeMap.GetElement(c) == Element.Tunnel || mazeMap.GetElement(c) == Element.Treasure)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AvaialableMovement()
        {
            /** Mengecek prioritas terendah terlebih dulu, yaitu bagian atas **/
            if (Moveable(this.currentPosition.Top())){
                this.available.Push(this.currentPosition.Top());
            }
            if(Moveable(this.currentPosition.Left())) {
                this.available.Push(this.currentPosition.Left());
            }
            if (Moveable(this.currentPosition.Bottom()))
            {
                this.available.Push(this.currentPosition.Bottom());
            }

            if (Moveable(this.currentPosition.Right()))
            {
                this.available.Push(this.currentPosition.Right());
            }
        }



    }
}
