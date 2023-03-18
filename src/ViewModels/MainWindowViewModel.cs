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
            var Example = new ExampleResult(Models.Map);
            Content = new ResultViewModel();
            var mazeView = new MazeViewModel(Example.getResult());
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
