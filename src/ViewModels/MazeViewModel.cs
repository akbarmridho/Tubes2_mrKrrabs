using Avalonia;
using DynamicData;
using mrKrrabs.Models;
using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        public MazeViewModel(MazeMap map) 
        {
            foreach(var row in map.Map)
            {
                foreach(var col in row)
                {
                    this.Maze.Add(new GridViewModel(col));
                }
            }
        }

        public ObservableCollection<GridViewModel> Maze { get; } = new();

        public int Size
        {
            get => (int)Math.Sqrt(Maze.Count);
        }
    }
}
