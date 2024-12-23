using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionDropdownView : ReactiveCollectionView<ActionViewModel, ActionDropdownItemView>
    {
        [SerializeField] private ActionColorSelector _colorSelector;

        protected override ViewContainer<ActionDropdownItemView> CreateView(IViewProvider viewProvider, ActionViewModel viewModel)
        {
            var color = _colorSelector.GetColor(ItemsCount, viewModel);
            return viewProvider.GetView<ActionDropdownItemView>(viewModel, color);
        }
    }
}