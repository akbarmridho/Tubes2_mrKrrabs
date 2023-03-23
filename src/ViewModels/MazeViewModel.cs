using mrKrrabs.Models;
using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        public MazeViewModel(MazeMap map, AvailableAlgorithm algorithm = AvailableAlgorithm.DFS)
        {
            bool alternative = algorithm == AvailableAlgorithm.BFS;

            foreach (var row in map.Map)
            {
                foreach (var col in row)
                {
                    if (col == Element.KrustyKrab)
                    {
                        this.Maze.Add(new GridKrustyViewModel(alternative));
                    }
                    else if (col == Element.Tunnel)
                    {
                        this.Maze.Add(new GridTunnelViewModel(alternative));
                    }
                    else if (col == Element.Treasure)
                    {
                        this.Maze.Add(new GridTreasureViewModel(alternative));
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

        public async void Begin(List<RouteBFS> movements, List<Coordinate> finalRoutes, int delay)
        {
            Coordinate prev = new(0, 0);
            for (int i = 0; i < movements.Count; i++)
            {
                await Task.Delay(delay);

                foreach (var grid in Maze)
                {
                    grid.SetActiveRoute(false);
                }

                foreach (var grid in movements[i].PrevCoordinates)
                {
                    Maze[rowColToIdx(grid.Item2.Y, grid.Item2.X)].SetActiveRoute(true);
                }

                var c = movements[i].CurrentCoordinate;

                if (i != 0)
                {
                    Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();
                }
                Maze[rowColToIdx(c.Item2, c.Item1)].Visit();
                prev = c;
            }
            Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();

            await Task.Delay(500);
            foreach (var grid in Maze)
            {
                grid.Finalize(false);
            }

            foreach (var r in finalRoutes)
            {
                Maze[rowColToIdx(r.Item2, r.Item1)].Finalize(true);
            }
        }

        public async void Begin(List<Coordinate> movements, int delay)
        {
            Coordinate prev = new(0, 0);
            for (int i = 0; i < movements.Count; i++)
            {
                await Task.Delay(delay);
                var c = movements[i];

                if (i != 0)
                {
                    Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();
                }
                Maze[rowColToIdx(c.Item2, c.Item1)].Visit();
                prev = c;
            }
            Maze[rowColToIdx(prev.Item2, prev.Item1)].Unvisit();

            await Task.Delay(500);
            foreach (var grid in Maze)
            {
                grid.Finalize(false);
            }

            foreach (var r in movements)
            {
                Maze[rowColToIdx(r.Item2, r.Item1)].Finalize(true);
            }
        }

        public ObservableCollection<GridViewModelBase> Maze { get; } = new();

        public int Size
        {
            get => (int)Math.Sqrt(Maze.Count);
        }
    }
}
