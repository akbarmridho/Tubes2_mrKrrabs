using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using mrKrrabs.ViewModels;

namespace mrKrrabs.Views;

public partial class GridView : ReactiveUserControl<GridViewModel>
{
    public GridView()
    {
        InitializeComponent();
    }
}