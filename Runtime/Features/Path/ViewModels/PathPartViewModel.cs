using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Path.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.ViewModels
{
    internal sealed class PathPartViewModel
    {
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IPathBuilder _pathBuilder;

        public PathPartViewModel(string part,
            NavigationViewModel navigationViewModel, 
            IPathBuilder pathBuilder)
        {
            _navigationViewModel = navigationViewModel;
            _pathBuilder = pathBuilder;
            IsCurrent = new ReactiveProperty<bool>(false);
            Part = new ReactiveProperty<string>(part);
        }
        
        public ReactiveProperty<bool> IsCurrent { get; }
        public ReactiveProperty<string> Part { get; }

        public void Navigate()
        {
            if (IsCurrent)
            {
                return;
            }
            
            var path = _pathBuilder.BuildPathUntilPart(this);
            _navigationViewModel.Navigate(path);
        }

        public void SetCurrent(bool isCurrent)
        {
            IsCurrent.SetValueNotify(isCurrent);
        }
    }
}