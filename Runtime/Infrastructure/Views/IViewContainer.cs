namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal interface IViewContainer<out T> where T : View
    {
        T View { get; }
        void Release();
    }
}