using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionDropdownView : ReactiveCollectionView<ActionViewModel, ActionDropdownItemView>
    {
        protected override ViewContainer<ActionDropdownItemView> CreateView(IViewProvider viewProvider, ActionViewModel viewModel)
        {
            return viewProvider.GetView<ActionDropdownItemView>(viewModel);
        }
    }
}