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
        private List<List<Element>> map = new List<List<Element>>();
        public int size { get; set; }
        public MazeMap(int size)
        {
            this.size = size;
        }

        public void InsertRow(List<char> row)
        {
            List<Element> list = new();
            foreach (char c in row)
            {
                switch(c)
                {
                    case 'K':
                        list.Add(Element.KrustyKrab);
                        break;
                    case 'R':
                        list.Add(Element.Tunnel); break;
                    case 'T':
                        list.Add(Element.Treasure); break;
                    case 'X':
                        list.Add(Element.Dirt);
                        break;
                    default:
                        break;
                }
            }

            this.map.Add(list);
        }

        public List<List<Element>> Map
        {
            get => map;
        }

        public Element GetElement(int row, int col) {
            return this.map[row][col];
        }

        public Element GetElement(Coordinate c)
        {
            return this.map[c.Item2][c.Item1];
        }

    }
}
