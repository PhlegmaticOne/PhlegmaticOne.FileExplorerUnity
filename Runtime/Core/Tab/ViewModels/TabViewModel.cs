using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Tab.ViewModels
{
    internal sealed class TabViewModel
    {
        public TabViewModel()
        {
            FileEntries = new ReactiveCollection<FileEntryViewModel>();
            IsEmpty = new ReactiveProperty<bool>(true);
        }
        
        public ReactiveCollection<FileEntryViewModel> FileEntries { get; }
        public ReactiveProperty<bool> IsEmpty { get; }

        public void Add(FileEntryViewModel fileEntry)
        {
            FileEntries.Add(fileEntry);
            UpdateIsEmpty();
        }

        public void Remove(FileEntryViewModel fileEntry)
        {
            FileEntries.Remove(fileEntry);
            UpdateIsEmpty();
        }

        public void UpdateIsEmpty()
        {
            var isEmpty = FileEntries.Count == 0;
            IsEmpty.SetValue(isEmpty);
        }

        public void Clear()
        {
            foreach (var fileEntry in FileEntries)
            {
                fileEntry.Dispose();
            }
            
            FileEntries.Clear();
            IsEmpty.SetValueWithoutNotify(true);
        }
    }
}