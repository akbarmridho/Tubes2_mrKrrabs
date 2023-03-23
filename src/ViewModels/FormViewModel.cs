using mrKrrabs.Models;
using mrKrrabs.Solver;
using ReactiveUI;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

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
        int speed = 0;
        public FormViewModel()
        {
            pathDescription = "Tidak ada berkas yang dipilih";
            pathDescriptionColor = "Black";
            OpenFile = ReactiveCommand.CreateFromTask(OpenFileAsync);

            var buttonEnabled = this.WhenAnyValue(x => x.Map).Select(x => x != null);

            Start = ReactiveCommand.Create(
                    () => new Form(UseBfs ? AvailableAlgorithm.BFS : AvailableAlgorithm.DFS, WithTsp, Map!, 3000/speed),
                    buttonEnabled);

            ShowOpenFileDialog = new Interaction<Unit, string?>();
        }
        public ReactiveCommand<Unit, Form> Start { get; }

        public ReactiveCommand<Unit, Unit> OpenFile { get; }

        public Interaction<Unit, string?> ShowOpenFileDialog { get; }

        public string? MazePath
        {
            get => mazePath;
            set => this.RaiseAndSetIfChanged(ref mazePath, value);
        }

        public MazeMap? Map
        {
            get => map;
            set => this.RaiseAndSetIfChanged(ref map, value);
        }
        public int Speed
        {
            get => speed;
            set => this.RaiseAndSetIfChanged(ref speed, value);
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
            }
            else
            {
                try
                {
                    Map = new MazeMap(filepath);
                    PathDescription = "Berkas " + Path.GetFileName(filepath) + " dipilih";
                    PathDescriptionColor = "Black";
                }
                catch
                {
                    PathDescription = "File tidak ditemukan atau format file map salah";
                    PathDescriptionColor = "Red";
                }
            }
        }
    }
}
