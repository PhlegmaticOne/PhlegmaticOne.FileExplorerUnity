using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class SelectAudioCollectionView : ReactiveCollectionView<SelectAudioEntryViewModel, SelectAudioEntryView>
    {
        protected override ViewContainer<SelectAudioEntryView> CreateView(IViewProvider viewProvider, SelectAudioEntryViewModel viewModel)
        {
            return viewProvider.GetView<SelectAudioEntryView>(viewModel);
        }
    }
}