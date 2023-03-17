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
using mrKrrabs.Solver;
using mrKrrabs.Utils;

namespace mrKrrabs.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        bool useDfs = true;
        bool useBfs = false;
        bool withTsp = false;
        string? mazePath;
        MazeMap? map;
        string pathDescription;
        string pathDescriptionColor;
        public FormViewModel() {
            pathDescription = "Tidak ada berkas yang dipilih";
            pathDescriptionColor = "Black";
            OpenFile = ReactiveCommand.CreateFromTask(OpenFileAsync);

            var buttonEnabled = this.WhenAnyValue(x => x.Map).Select(x => x != null);

            Start = ReactiveCommand.Create(
                    () => new Form(),
                    buttonEnabled);

            ShowOpenFileDialog = new Interaction<Unit, string?>();
        }
        public ReactiveCommand<Unit, Form> Start { get; }

        public ReactiveCommand<Unit, Unit> OpenFile { get; }

        public Interaction<Unit, string?> ShowOpenFileDialog { get; }

        public string? MazePath {
            get => mazePath;
            set => this.RaiseAndSetIfChanged(ref mazePath, value);
        }

        public MazeMap? Map { 
            get => map; 
            set => this.RaiseAndSetIfChanged(ref map, value);
        }

        public string PathDescription
        {
            get => pathDescription;
            set => this.RaiseAndSetIfChanged(ref pathDescription, value);
        }

        public string PathDescriptionColor
        {
            get => pathDescriptionColor;
            set => this.RaiseAndSetIfChanged(ref pathDescriptionColor, value);
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
            var filepath = await ShowOpenFileDialog.Handle(Unit.Default);

            if (filepath == null)
            {
                PathDescription = "Tidak ada berkas yang dipilih";
                PathDescriptionColor = "Black";
            } else
            {
                var map = ValidateFile.Validate(filepath);

                if (map == null)
                {
                    PathDescription = "File tidak ditemukan atau format file map salah";
                    PathDescriptionColor = "Red";
                } else
                {
                    Map = map;
                    PathDescription = "Berkas terpilih";
                    PathDescriptionColor = "Black";
                }
            }
        }
    }
}
