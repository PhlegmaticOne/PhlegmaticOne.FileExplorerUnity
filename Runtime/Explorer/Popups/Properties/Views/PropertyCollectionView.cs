using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertyCollectionView : ReactiveCollectionView<PropertyViewModel, PropertyView>
    {
        protected override ViewContainer<PropertyView> CreateView(IViewProvider viewProvider, PropertyViewModel viewModel)
        {
            return viewProvider.GetView<PropertyView>(viewModel);
        }
    }
}