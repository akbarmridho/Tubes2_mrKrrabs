using mrKrrabs.Solver;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace mrKrrabs.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        //content = new FormViewModel();
        //mazePanel = new MazeEmptyViewModel();
        BeginForm();
    }

    public void BeginForm()
    {
        var vm = new FormViewModel();

        Observable.Merge(vm.Start).Take(1).Subscribe(Models =>
        {
            var watch = new System.Diagnostics.Stopwatch();

            if (Models.Algorithm == mrKrrabs.Models.AvailableAlgorithm.DFS)
            {
                watch.Start();
                var dfs = new DFS(Models.Map, Models.UseTsp);
                dfs.Solve();
                var Result = dfs.GetResult();
                watch.Stop();

                Content = new ResultViewModel(Result, watch.ElapsedMilliseconds, Models.Algorithm == mrKrrabs.Models.AvailableAlgorithm.DFS, Models.UseTsp);
                var mazeView = new MazeViewModel(Models.Map);
                MazePanel = mazeView;
                mazeView.Begin(Result.GetMoves());
            }
        });

        Content = vm;
        MazePanel = new MazeEmptyViewModel();
    }

    ViewModelBase content;

    public ViewModelBase Content
    {
        get => content;
        private set => this.RaiseAndSetIfChanged(ref content, value);
    }

    ViewModelBase mazePanel;

    public ViewModelBase MazePanel
    {
        get => mazePanel;
        private set => this.RaiseAndSetIfChanged(ref mazePanel, value);
    }
}
