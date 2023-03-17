using Avalonia.Controls.Shapes;
using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.Utils
{
    public class ValidateFile
    {
        public static MazeMap? Validate(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
            } catch
            {
                return null;
            }

            int size = lines[0].Length;

            var Map = new MazeMap(size);
            
            foreach (var line in lines)
            {
                if (line.Length != size)
                {
                    return null;
                }

                List<char> row = new List<char>();

                foreach(var chr in line.ToCharArray())
                {
                    if (chr != 'X' && chr != 'T' && chr != 'R' && chr != 'X')
                    {
                        return null;
                    }

                    row.Add(chr);
                }

                if (row.Count != size)
                {
                    return null;
                }

                Map.InsertRow(row);
            }

            if (Map.Map.Count != size)
            {
                return null;
            }

            return Map;
        }
    }
}
