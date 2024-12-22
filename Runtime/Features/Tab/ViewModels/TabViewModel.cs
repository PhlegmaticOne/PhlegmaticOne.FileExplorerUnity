using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Tab.ViewModels
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

        public void Add(FileEntryViewModel file)
        {
            FileEntries.Add(file);
            UpdateIsEmpty();
        }

        public void Remove(FileEntryViewModel file)
        {
            FileEntries.Remove(file);
            UpdateIsEmpty();
        }
        
        public void RemoveRange(IEnumerable<FileEntryViewModel> files)
        {
            foreach (var file in files)
            {
                FileEntries.Remove(file);
            }
            
            UpdateIsEmpty();
        }

        public void UpdateIsEmpty()
        {
            var isEmpty = FileEntries.Count == 0;
            IsEmpty.SetValueNotify(isEmpty);
        }

        public void Clear(bool isNotify = false)
        {
            foreach (var fileEntry in FileEntries)
            {
                fileEntry.Dispose();
            }
            
            FileEntries.Clear();
            IsEmpty.SetValue(true, isNotify);
        }
    }
}