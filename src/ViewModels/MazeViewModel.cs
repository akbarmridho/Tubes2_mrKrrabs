using Avalonia;
using DynamicData;
using mrKrrabs.Models;
using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        MovementHistory history;
        public MazeViewModel(MovementHistory history) 
        {
            this.history = history;
            foreach(var row in history.Maze.Map)
            {
                foreach(var col in row)
                {
                    this.Maze.Add(new GridViewModel(col));
                }
            }
        }

        int rowColToIdx(int row, int col)
        {
            return row * Size + col;
        }

        public async void Begin()
        {
            Coordinate prev = new(0, 0);
            for (int i = 0; i < history.Movements.Count; i++)
            {
                await Task.Delay(200);
                var c = history.Movements[i];

                if (i != 0)
                {
                    Maze[rowColToIdx(prev.Item2, prev.Item1)].DisableVisiting();
                }
                Maze[rowColToIdx(c.Item2, c.Item1)].Visit();
                prev = c;
            }
            Maze[rowColToIdx(prev.Item2, prev.Item1)].DisableVisiting();

            await Task.Delay(500);
            foreach (var grid in Maze)
            {
                grid.SetNotRoute();
            }

            foreach (var r in history.Routes)
            {
                Maze[rowColToIdx(r.Item2, r.Item1)].SetRoute();
            }
        }

        public ObservableCollection<GridViewModel> Maze { get; } = new();

        public int Size
        {
            get => (int)Math.Sqrt(Maze.Count);
        }
    }
}
