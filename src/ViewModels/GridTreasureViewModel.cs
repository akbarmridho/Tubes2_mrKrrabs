using Avalonia.Media.Imaging;
using mrKrrabs.Models;
using ReactiveUI;

namespace mrKrrabs.ViewModels
{
    public class GridTreasureViewModel : GridViewModelBase
    {
        protected Bitmap backgroundVisited;
        protected Bitmap backgroundRoute;
        protected Bitmap background;
        protected Bitmap player;
        protected Bitmap treasureUnopened;
        protected Bitmap treasureOpened;

        protected Bitmap currentBackground;
        protected Bitmap treasureIcon;

        protected bool activeRoute = true;
        protected bool activeSearch;
        protected bool visited;
        protected bool opened;

        public GridTreasureViewModel(bool alternativePlayer = false)
        {
            this.backgroundVisited = GridImage.TunnelVisited;
            this.backgroundRoute = GridImage.TunnelRoute;
            this.background = GridImage.Tunnel;
            this.treasureUnopened = GridImage.TreasureUnopened;
            this.treasureOpened = GridImage.TreasureOpened;

            this.currentBackground = this.background;
            this.treasureIcon = this.treasureUnopened;

            if (alternativePlayer)
            {
                this.player = GridImage.Player2;
            }
            else
            {
                this.player = GridImage.Player1;
            }
        }

        public bool IsActive
        {
            get => activeSearch;
            set => this.RaiseAndSetIfChanged(ref activeSearch, value);
        }

        public Bitmap PlayerIcon
        {
            get => player;
        }

        public Bitmap TreasureIcon
        {
            get => treasureIcon;
            set => this.RaiseAndSetIfChanged(ref treasureIcon, value);
        }

        public override void SetActiveRoute(bool isActive = true)
        {
            if (this.activeRoute != isActive)
            {
                if (this.activeRoute) // set to false
                {
                    this.TreasureIcon = this.treasureUnopened;
                    this.Background = background;
                }
                else // set to true
                {
                    if (this.visited)
                    {
                        this.TreasureIcon = this.treasureOpened;
                        this.Background = backgroundVisited;
                    }
                    else
                    {
                        this.TreasureIcon = this.treasureUnopened;
                        this.Background = background;
                    }
                }

                this.activeRoute = isActive;
            }
        }


        public override void Visit()
        {
            this.Background = this.backgroundVisited;
            this.visited = true;
            this.TreasureIcon = this.treasureOpened;
            this.IsActive = true;
        }

        public override void Unvisit()
        {
            this.IsActive = false;
        }

        public override void Finalize(bool isRoute)
        {
            if (isRoute)
            {
                this.Background = this.backgroundRoute;
                this.TreasureIcon = this.treasureOpened;
            }
            else
            {
                this.Background = this.background;
                this.TreasureIcon = this.treasureUnopened;
            }
        }

        public Bitmap Background
        {
            get => currentBackground;
            set => this.RaiseAndSetIfChanged(ref currentBackground, value);
        }
    }
}
