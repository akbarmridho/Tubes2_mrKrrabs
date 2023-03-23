using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        protected List<List<Element>> map = new();
        protected int totalTreasure = 0;

        public List<List<Element>> Map { get => map; }
        public int TotalTreasure { get => treasureCoordinates.Count; }
        public int size { get => map.Count; }
        public Coordinate StartPosition;
        public List<Coordinate> treasureCoordinates = new();

        public MazeMap(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath).Select(x => x.Trim().Replace(" ", string.Empty).ToUpper()).ToArray();
            int height = lines.Length;
            int width = lines[0].Length;
            int leftPad, rightPad, topPad, bottomPad;

            if (width > height)
            {
                topPad = (width - height) / 2;
                bottomPad = width - height - topPad;
                leftPad = 0;
                rightPad = 0;
            }
            else if (height > width)
            {
                topPad = 0;
                bottomPad = 0;
                leftPad = (height - width) / 2;
                rightPad = height - width - leftPad;
            }
            else
            {
                topPad = 0;
                bottomPad = 0;
                leftPad = 0;
                rightPad = 0;
            }

            int targetSize = width > height ? width : height;

            if (topPad > 0)
            {
                for (int i = 0; i < topPad; i++)
                {
                    List<Element> pad = new();
                    for (int j = 0; j < targetSize; j++)
                    {
                        pad.Add(Element.Dirt);
                    }
                    map.Add(pad);
                }
            }


            foreach (string line in lines)
            {
                List<Element> chars = new List<Element>();

                if (leftPad > 0)
                {
                    for (int i = 0; i < leftPad; i++)
                    {
                        chars.Add(Element.Dirt);
                    }
                }

                int c = 0;
                foreach (var chr in line.ToCharArray())
                {
                    if (chr == 'K')
                    {
                        StartPosition = new Coordinate(c, map.Count);
                        chars.Add(Element.KrustyKrab);
                    }
                    else if (chr == 'T')
                    {
                        chars.Add(Element.Treasure);
                        treasureCoordinates.Add(new Coordinate(c, map.Count));
                    }
                    else if (chr == 'R')
                    {
                        chars.Add(Element.Tunnel);
                    }
                    else if (chr == 'X')
                    {
                        chars.Add(Element.Dirt);
                    }
                    else
                    {
                        throw new System.Exception("Invalid chars found");
                    }
                    c++;
                }

                if (rightPad > 0)
                {
                    for (int i = 0; i < rightPad; i++)
                    {
                        chars.Add(Element.Dirt);
                    }
                }

                map.Add(chars);
            }

            if (bottomPad > 0)
            {
                for (int i = 0; i < bottomPad; i++)
                {
                    List<Element> pad = new();
                    for (int j = 0; j < targetSize; j++)
                    {
                        pad.Add(Element.Dirt);
                    }
                    map.Add(pad);
                }
            }

        }

        public Element GetElement(Coordinate c)
        {
            return this.map[c.Item2][c.Item1];
        }

    }
}
