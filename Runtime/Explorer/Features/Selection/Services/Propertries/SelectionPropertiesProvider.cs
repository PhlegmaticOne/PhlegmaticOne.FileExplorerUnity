using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Services.Proprties;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services
{
    internal sealed class SelectionPropertiesProvider : ISelectionPropertiesProvider
    {
        private readonly SelectionViewModel _selectionViewModel;

        public SelectionPropertiesProvider(SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }
        
        public SelectionProperties GetSelectionProperties()
        {
            return new SelectionProperties(CalculateMergedSize(), _selectionViewModel.SelectedEntriesCount);
        }

        private FileSize CalculateMergedSize()
        {
            var size = FileSize.Zero;

            foreach (var fileEntry in _selectionViewModel.GetSelection())
            {
                var properties = fileEntry.GetProperties();
                size.Merge(properties.Size);
            }

            return size;
        }
    }
}