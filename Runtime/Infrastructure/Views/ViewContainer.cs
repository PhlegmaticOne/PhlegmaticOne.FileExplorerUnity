namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal sealed class ViewContainer<T> : IViewContainer<T> where T : View
    {
        private readonly IViewProvider _viewProvider;

        public ViewContainer(T view, IViewProvider viewProvider)
        {
            View = view;
            _viewProvider = viewProvider;
        }
        
        public T View { get; private set; }

        public void Release()
        {
            _viewProvider.ReleaseView(View);
            View = null;
        }
    }
}