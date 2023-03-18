using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Solver
{
    public enum Element
    {
        KrustyKrab,
        Treasure,
        Tunnel,
        Dirt
    }
    public class MazeMap
    {
        private List<List<char>> map = new List<List<char>>();
        public int size { get; set; }
        public MazeMap(int size)
        {
            this.size = size;
        }

        public void InsertRow(List<char> row)
        {
            map.Add(row);
        }

        public List<List<char>> Map
        {
            get => map;
        }

        public char GetRow(int row) { }

    }
}
