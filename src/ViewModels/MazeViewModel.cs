using mrKrrabs.Solver;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        MovementHistory history;
        public MazeViewModel(MovementHistory history)
        {
            this.history = history;
            foreach (var row in history.Maze.Map)
            {
                foreach (var col in row)
                {
                    if (col == Element.KrustyKrab)
                    {
                        this.Maze.Add(new GridKrustyViewModel());
                    }
                    else if (col == Element.Tunnel)
                    {
                        this.Maze.Add(new GridTunnelViewModel());
                    }
                    else if (col == Element.Treasure)
                    {
                        this.Maze.Add(new GridTreasureViewModel());
                    }
                    else
                    {
                        this.Maze.Add(new GridDirtViewModel());
                    }
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
                    Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();
                }
                Maze[rowColToIdx(c.Item2, c.Item1)].Visit();
                prev = c;
            }
            Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();

            //await Task.Delay(500);
            //foreach (var grid in Maze)
            //{
            //    grid.
            //}

            //foreach (var r in history.Routes)
            //{
            //    Maze[rowColToIdx(r.Item2, r.Item1)].SetRoute();
            //}
        }

        public ObservableCollection<GridViewModelBase> Maze { get; } = new();

        public int Size
        {
            get => (int)Math.Sqrt(Maze.Count);
        }
    }
}
