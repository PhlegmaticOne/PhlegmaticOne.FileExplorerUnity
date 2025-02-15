using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Entities
{
    internal sealed class TabCollectionView : ReactiveCollectionView<FileEntryViewModel, FileEntryView>
    {
        [SerializeField] private RectTransform _headerTransform;
        [SerializeField] private ScrollRect _scrollRect;

        protected override ViewContainer<FileEntryView> CreateView(IViewProvider viewProvider, FileEntryViewModel viewModel)
        {
            return viewProvider.GetView<FileEntryView>(viewModel, _headerTransform, _scrollRect);
        }
    }
}