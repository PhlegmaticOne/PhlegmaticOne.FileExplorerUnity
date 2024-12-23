using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Views
{
    internal sealed class TabCollectionView : ReactiveCollectionView<FileEntryViewModel, FileEntryView>
    {
        [SerializeField] private RectTransform _headerTransform;

        protected override ViewContainer<FileEntryView> CreateView(IViewProvider viewProvider, FileEntryViewModel viewModel)
        {
            return viewProvider.GetView<FileEntryView>(viewModel, _headerTransform);
        }
    }
}