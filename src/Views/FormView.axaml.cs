using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using mrKrrabs.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace mrKrrabs.Views;

public partial class FormView : ReactiveUserControl<FormViewModel>
{
    public FormView()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel.ShowOpenFileDialog.RegisterHandler(ShowOpenFileDialogue)));
    }

    private async Task ShowOpenFileDialogue(InteractionContext<Unit, string?> interaction)
    {
        // var dialog = new OpenFileDialog();
        // var fileNames = await dialog.ShowAsync(Window.GetWindow);

        // interaction.SetOutput(fileNames.FirstOrDefault());
    }
}