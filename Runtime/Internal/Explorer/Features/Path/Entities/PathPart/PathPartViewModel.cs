using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Builder;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart
{
    internal sealed class PathPartViewModel : ViewModel
    {
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IPathBuilder _pathBuilder;

        public PathPartViewModel(string part,
            NavigationViewModel navigationViewModel, 
            IPathBuilder pathBuilder)
        {
            _navigationViewModel = navigationViewModel;
            _pathBuilder = pathBuilder;
            NavigateCommand = new CommandDelegateEmpty(Navigate);
            IsCurrent = new ReactiveProperty<bool>(false);
            Part = new ReactiveProperty<string>(part);
        }
        
        public ReactiveProperty<bool> IsCurrent { get; }
        public ReactiveProperty<string> Part { get; }
        public ICommand NavigateCommand { get; }

        public void SetCurrent(bool isCurrent)
        {
            IsCurrent.SetValueNotify(isCurrent);
        }

        private void Navigate()
        {
            if (IsCurrent)
            {
                return;
            }
            
            var path = _pathBuilder.BuildPathUntilPart(this);
            _navigationViewModel.Navigate(path);
        }
    }
}