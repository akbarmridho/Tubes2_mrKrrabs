namespace mrKrrabs.ViewModels
{
    public abstract class GridViewModelBase : ViewModelBase
    {
        public abstract void Visit();
        public abstract void Unvisit();
        public abstract void SetActiveRoute(bool activeRoute);
        public abstract void Finalize(bool isRoute);

    }
}
