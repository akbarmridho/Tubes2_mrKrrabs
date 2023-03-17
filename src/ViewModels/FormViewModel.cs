using mrKrrabs.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        string mazePath;
        public FormViewModel() {
            var buttonEnabled = this.WhenAnyValue(x => x.MazePath, x=> !string.IsNullOrWhiteSpace(x)); // todo
            // validasi maze

            Start = ReactiveCommand.Create(
                    () => new Form(),
                    buttonEnabled);
        }
        public ReactiveCommand<Unit, Form> Start { get; }

        public string MazePath {
            get => mazePath;
            set => this.RaiseAndSetIfChanged(ref mazePath, value);
        }
    }
}
