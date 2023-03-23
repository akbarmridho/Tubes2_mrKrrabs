using Avalonia.Media.Imaging;
using mrKrrabs.Models;
using ReactiveUI;

namespace mrKrrabs.ViewModels
{
    public class GridKrustyViewModel : GridViewModelBase
    {
        private Bitmap playerIcon;
        private Bitmap background;
        private bool activeSearch;

        public GridKrustyViewModel(bool alternativePlayer = false)
        {
            this.background = GridImage.KrustyKrab;

            if (alternativePlayer)
            {
                this.playerIcon = GridImage.Player2;
            }
            else
            {
                this.playerIcon = GridImage.Player1;
            }

            this.activeSearch = false;
        }
        public override void SetActiveRoute(bool activeRoute)
        {
            // do nothing
        }

        public bool IsActive
        {
            get => activeSearch;
            set => this.RaiseAndSetIfChanged(ref activeSearch, value);
        }

        public override void Unvisit()
        {
            this.IsActive = false;
        }

        public override void Visit()
        {
            this.IsActive = true;
        }
    }
}
