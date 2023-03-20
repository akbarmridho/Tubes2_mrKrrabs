using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using mrKrrabs.ViewModels;
using ReactiveUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace mrKrrabs.Views;

public partial class FormView : ReactiveUserControl<FormViewModel>
{
    public FormView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowOpenFileDialog.RegisterHandler(ShowOpenFileDialogue)));
    }

    private async Task ShowOpenFileDialogue(InteractionContext<Unit, string?> interaction)
    {
        if (Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            && desktop.MainWindow is not null)
        {
            var extensions = new List<string>() { "txt" };
            var filters = new List<FileDialogFilter>()
                {
                    new FileDialogFilter{Name="Text", Extensions= extensions}
                };

            var dialog = new OpenFileDialog
            {
                Title = "Map files",
                Filters = filters,
                AllowMultiple = false,
                //Directory = Directory.GetCurrentDirectory(),
            };

            var results = await dialog.ShowAsync(desktop.MainWindow);

            if (results != null)
            {
                interaction.SetOutput(results.FirstOrDefault());
            } else
            {
                interaction.SetOutput(null);
            }
            
        } else
        {
            interaction.SetOutput(null);
        }
    }
}