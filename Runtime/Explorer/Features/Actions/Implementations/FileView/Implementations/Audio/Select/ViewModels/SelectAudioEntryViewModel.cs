using System;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class SelectAudioEntryViewModel : ViewModel
    {
        public SelectAudioEntryViewModel(string extension)
        {
            Extension = extension;
        }

        public event Action<SelectAudioEntryViewModel> Selected;
        public string Extension { get; }

        public void Select()
        {
            Selected?.Invoke(this);
        }
    }
}