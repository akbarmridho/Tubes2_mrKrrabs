using Avalonia.Media.Imaging;
using mrKrrabs.Models;
using ReactiveUI;

namespace mrKrrabs.ViewModels
{
    public class GridTunnelViewModel : GridViewModelBase
    {
        protected Bitmap backgroundVisited;
        protected Bitmap backgroundRoute;
        protected Bitmap background;
        protected Bitmap player;
        protected Bitmap currentBackground;

        protected bool activeRoute;
        protected bool activeSearch;
        protected bool isVisited = false;
        public GridTunnelViewModel(bool alternativePlayer = false)
        {
            this.backgroundVisited = GridImage.TunnelVisited;
            this.backgroundRoute = GridImage.TunnelRoute;
            this.background = GridImage.Tunnel;
            this.currentBackground = this.background;

            if (alternativePlayer)
            {
                this.player = GridImage.Player2;
            }
            else
            {
                this.player = GridImage.Player1;
            }

            this.activeRoute = true;
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

        public override void SetActiveRoute(bool isActive = true)
        {
            if (this.activeRoute != isActive)
            {
                if (this.activeRoute) // set to false
                {
                    this.Background = background;
                }
                else
                {
                    if (isVisited)
                    {
                        this.Background = backgroundVisited;
                    }
                    else
                    {
                        this.Background = background;
                    }

                }

                this.activeRoute = isActive;
            }
        }

        public override void Visit()
        {
            this.isVisited = true;
            this.Background = this.backgroundVisited;
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
            }
            else
            {
                this.Background = this.background;
            }
        }

        public Bitmap Background
        {
            get => currentBackground;
            set => this.RaiseAndSetIfChanged(ref currentBackground, value);
        }
    }
}
