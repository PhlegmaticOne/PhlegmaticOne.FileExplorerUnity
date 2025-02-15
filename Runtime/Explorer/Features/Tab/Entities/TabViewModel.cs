using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Entities
{
    internal sealed class TabViewModel : ViewModel
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

        public void AddRange(IEnumerable<FileEntryViewModel> fileEntries)
        {
            FileEntries.AddRange(fileEntries);
            UpdateIsEmpty();
        }

        public void Remove(FileEntryViewModel fileEntry)
        {
            FileEntries.Remove(fileEntry);
            UpdateIsEmpty();
        }
        
        public void RemoveRange(IEnumerable<FileEntryViewModel> fileEntry)
        {
            foreach (var file in fileEntry)
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