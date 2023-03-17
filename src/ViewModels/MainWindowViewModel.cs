using ReactiveUI;
using System.Linq;
using System;
using System.Reactive.Linq;

namespace mrKrrabs.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel() {
        BeginForm();
    }

    public void BeginForm()
    {
        var vm = new FormViewModel();

        Observable.Merge(vm.Start).Take(1).Subscribe(Models =>
        {
            Content = new ResultViewModel();
        });

        Content = vm;
        // reset maze content
    }

    ViewModelBase content;

    public ViewModelBase Content
    {
        get => content;
        private set => this.RaiseAndSetIfChanged(ref content, value);
    }
}
