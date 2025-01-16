using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views
{
    internal sealed class PropertyCollectionView : ReactiveCollectionView<PropertyViewModel, PropertyView>
    {
        protected override ViewContainer<PropertyView> CreateView(IViewProvider viewProvider, PropertyViewModel viewModel)
        {
            return viewProvider.GetView<PropertyView>(viewModel);
        }
    }
}