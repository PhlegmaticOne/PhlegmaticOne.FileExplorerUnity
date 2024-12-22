using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal sealed class PathBuilder : IPathBuilder
    {
        private readonly PathViewModel _pathViewModel;

        public PathBuilder(PathViewModel pathViewModel)
        {
            _pathViewModel = pathViewModel;
        }
        
        public string BuildPathUntilPart(PathPartViewModel viewModel)
        {
            var index = _pathViewModel.PathParts.IndexOf(viewModel);

            if (index is 0 or -1)
            {
                return _pathViewModel.GetRootPath();
            }

            return CombinePathUntilIndex(index);
        }

        private string CombinePathUntilIndex(int index)
        {
            var pathParts = new string[index + 1];
            pathParts[0] = _pathViewModel.GetRootPath();

            for (var i = 1; i < index; i++)
            {
                pathParts[i] = _pathViewModel.PathParts[i].Part;
            }

            return System.IO.Path.Combine(pathParts).PathSlash();
        }
    }
}