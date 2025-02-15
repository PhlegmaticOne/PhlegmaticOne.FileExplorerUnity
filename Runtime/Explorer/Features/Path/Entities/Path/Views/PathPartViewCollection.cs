using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Path.Entities.Path
{
    internal sealed class PathPartViewCollection : ReactiveCollectionView<PathPartViewModel, PathPartView>
    {
        protected override ViewContainer<PathPartView> CreateView(IViewProvider viewProvider, PathPartViewModel viewModel)
        {
            return viewProvider.GetView<PathPartView>(viewModel);
        }
    }
}