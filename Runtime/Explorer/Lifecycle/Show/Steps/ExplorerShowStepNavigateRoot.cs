using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps
{
    internal sealed class ExplorerShowStepNavigateRoot : IExplorerShowStep
    {
        private readonly NavigationViewModel _navigationViewModel;

        public ExplorerShowStepNavigateRoot(
            NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }
        
        public void ProcessShow()
        {
            _navigationViewModel.NavigateRoot();
        }
    }
}