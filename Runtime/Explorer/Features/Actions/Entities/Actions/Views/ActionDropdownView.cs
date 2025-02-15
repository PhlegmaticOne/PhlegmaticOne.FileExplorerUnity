using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions
{
    internal sealed class ActionDropdownView : ReactiveCollectionView<ActionViewModel, ActionDropdownItemView>
    {
        protected override ViewContainer<ActionDropdownItemView> CreateView(IViewProvider viewProvider, ActionViewModel viewModel)
        {
            return viewProvider.GetView<ActionDropdownItemView>(viewModel);
        }
    }
}