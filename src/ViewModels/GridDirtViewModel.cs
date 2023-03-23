using Avalonia.Media.Imaging;
using mrKrrabs.Models;

namespace mrKrrabs.ViewModels
{
    public class GridDirtViewModel : GridViewModelBase
    {
        readonly Bitmap background;

        public GridDirtViewModel()
        {
            background = GridImage.Dirt;
        }

        public Bitmap Background { get => background; }

        public override void Visit()
        {
            // do nothing
        }

        public override void Unvisit()
        {
            // do nothing
        }

        public override void SetActiveRoute(bool activeRoute)
        {
            // do nothing
        }

        public override void Finalize(bool isRoute)
        {
            // do nothing
        }
    }
}
