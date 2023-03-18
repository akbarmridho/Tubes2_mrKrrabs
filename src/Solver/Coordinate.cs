using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public class Coordinate: Tuple<int, int>
    {
        public Coordinate(int x, int y) : base(x, y) { }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            
            var that = obj as Coordinate;

            if (that == null) return false;


            if (that.Item1 == this.Item1 && that.Item2 == this.Item2) return true;

            return false;
        }

        public int X { get => Item1; }
        public int Y { get => Item2; }

        public override int GetHashCode()
        {
            return (Item1, Item2).GetHashCode();
        }

        public Coordinate Top()
        {
            return new Coordinate(this.X, this.Y - 1);
        }
        public Coordinate Bottom()
        {
            return new Coordinate(this.X, this.Y + 1);
        }
        public Coordinate Left()
        {
            return new Coordinate(this.X-1, this.Y);
        }
        public Coordinate Right()
        {
            return new Coordinate(this.X+1, this.Y);
        }
    }

}
