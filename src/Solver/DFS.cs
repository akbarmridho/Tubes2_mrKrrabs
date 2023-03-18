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

        public void AvaialableMovement()
        {
            /** Mengecek prioritas terendah terlebih dulu **/
            
        }

    }
}
