namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Behaviours
{
    internal interface IReactiveCollectionBehaviour
    {
        void OnBind();
        void OnAdded(View view);
        void OnRemoved(View view);
        void OnClear();
        void OnRelease();
    }
}