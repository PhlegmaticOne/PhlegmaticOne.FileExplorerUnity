namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services
{
    internal interface INavigationProgressSetter
    {
        void AddDeltaProgress(int delta);
        void Complete();
        void SetActive(bool isActive);
    }
}