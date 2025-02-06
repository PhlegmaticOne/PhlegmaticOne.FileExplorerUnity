using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal sealed class SelectAudioViewModel : PopupViewModel
    {
        private readonly ExplorerConfig _config;

        public SelectAudioViewModel(string headerText, string buttonText, ExplorerConfig config)
        {
            _config = config;
            ButtonText = buttonText;
            HeaderText = headerText;
            Entries = new ReactiveCollection<SelectAudioEntryViewModel>(GetEntries());
            SelectedExtension = new ReactiveProperty<string>();
            SetSelectedExtension(Entries[0]);
        }

        public string HeaderText { get; }
        public string ButtonText { get; }
        public ReactiveProperty<string> SelectedExtension { get; }
        public ReactiveCollection<SelectAudioEntryViewModel> Entries { get; }

        public void Subscribe()
        {
            foreach (var entry in Entries)
            {
                entry.Selected += SetSelectedExtension;
            }
        }

        public void Unsubscribe()
        {
            foreach (var entryViewModel in Entries)
            {
                entryViewModel.Selected -= SetSelectedExtension;
            }
        }

        public AudioType GetAudioType()
        {
            return _config.Extensions.GetAudioType(SelectedExtension);
        }

        private void SetSelectedExtension(SelectAudioEntryViewModel entryViewModel)
        {
            SelectedExtension.SetValueNotify(entryViewModel.Extension);
        }

        private IEnumerable<SelectAudioEntryViewModel> GetEntries()
        {
            return _config.Extensions
                .GetAudioExtensions()
                .Select(x => new SelectAudioEntryViewModel(x.Extension));
        }
    }
}