namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services
{
    internal interface INavigationProgressSetter
    {
        void AddDeltaProgress();
        void Complete();
        void SetActive(bool isActive);
    }
}