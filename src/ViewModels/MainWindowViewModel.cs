using ReactiveUI;
using System.Linq;
using System;
using System.Reactive.Linq;
using mrKrrabs.Solver;

namespace mrKrrabs.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel() {
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

            watch.Start();
            var Example = new ExampleResult(Models.Map);
            watch.Stop();

            var Result = Example.getResult();
            Content = new ResultViewModel(Result, watch.ElapsedMilliseconds, Models.Algorithm == mrKrrabs.Models.AvailableAlgorithm.DFS, Models.UseTsp);
            var mazeView = new MazeViewModel(Result);
            MazePanel = mazeView;
            mazeView.Begin();
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
