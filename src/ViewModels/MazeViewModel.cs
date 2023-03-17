using Avalonia;
using DynamicData;
using mrKrrabs.Models;
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
        public MazeViewModel() 
        {
            this.Maze.Add(new GridViewModel('A'));
            this.Maze.Add(new GridViewModel('B'));
            this.Maze.Add(new GridViewModel('C'));
            this.Maze.Add(new GridViewModel('D'));
            this.Maze.Add(new GridViewModel('A'));
            this.Maze.Add(new GridViewModel('B'));
            this.Maze.Add(new GridViewModel('C'));
            this.Maze.Add(new GridViewModel('D'));
            this.Maze.Add(new GridViewModel('A'));
            this.Maze.Add(new GridViewModel('B'));
            this.Maze.Add(new GridViewModel('C'));
            this.Maze.Add(new GridViewModel('D'));
            this.Maze.Add(new GridViewModel('A'));
            this.Maze.Add(new GridViewModel('B'));
            this.Maze.Add(new GridViewModel('C'));
            this.Maze.Add(new GridViewModel('D'));
        }

        public ObservableCollection<GridViewModel> Maze { get; } = new();

        public int Size
        {
            get => (int)Math.Sqrt(Maze.Count);
        }
    }
}
