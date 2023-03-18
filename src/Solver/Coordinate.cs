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

        public override int GetHashCode()
        {
            return (Item1, Item2).GetHashCode();
        }
    }
}
