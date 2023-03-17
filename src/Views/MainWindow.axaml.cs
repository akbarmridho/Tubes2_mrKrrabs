using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using mrKrrabs.ViewModels;
using ReactiveUI;

namespace mrKrrabs.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Logger.TryGet(LogEventLevel.Fatal, LogArea.Control)?.Log(this, "Avalonia Infrastructure");
        System.Diagnostics.Debug.WriteLine("System Diagnostics Debug");
        InitializeComponent();
    }
}