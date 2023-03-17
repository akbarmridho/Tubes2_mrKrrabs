using mrKrrabs.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Avalonia.Controls;

namespace mrKrrabs.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        bool useDfs = true;
        bool useBfs = false;
        bool withTsp = false;
        string mazePath;
        public FormViewModel() {
            MazePath = "somefile";
            var buttonEnabled = this.WhenAnyValue(x => x.MazePath, x=> !string.IsNullOrWhiteSpace(x)); // todo
            // validasi maze

            Start = ReactiveCommand.Create(
                    () => new Form(),
                    buttonEnabled);

            ShowOpenFileDialog = new Interaction<Unit, string?>();
        }
        public ReactiveCommand<Unit, Form> Start { get; }

        public ReactiveCommand<Unit, string> OpenFile { get; }

        public Interaction<Unit, string?> ShowOpenFileDialog { get; }

        public string MazePath {
            get => mazePath;
            set => this.RaiseAndSetIfChanged(ref mazePath, value);
        }

        public bool UseDfs
        {
            get => useDfs;
            set => this.RaiseAndSetIfChanged(ref useDfs, value);
        }

        public bool UseBfs
        {
            get => useBfs;
            set => this.RaiseAndSetIfChanged(ref useBfs, value);
        }

        public bool WithTsp
        {
            get => withTsp;
            set => this.RaiseAndSetIfChanged(ref withTsp, value);
        }

        private async Task OpenFileAsync()
        {
            var filename = await ShowOpenFileDialog.Handle(Unit.Default);
        }
    }
}
