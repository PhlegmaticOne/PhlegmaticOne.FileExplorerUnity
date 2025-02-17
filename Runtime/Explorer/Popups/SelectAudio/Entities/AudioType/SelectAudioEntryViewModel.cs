using System;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioEntryViewModel : ViewModel
    {
        public SelectAudioEntryViewModel(string extension)
        {
            Extension = new ReactiveProperty<string>(extension);
            SelectCommand = new CommandDelegateEmpty(Select);
        }

        public event Action<SelectAudioEntryViewModel> Selected;
        
        public ICommand SelectCommand { get; }
        public ReactiveProperty<string> Extension { get; }

        public void Select()
        {
            Selected?.Invoke(this);
        }
    }
}