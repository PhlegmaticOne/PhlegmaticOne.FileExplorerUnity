using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioViewModel : PopupViewModel
    {
        private readonly ExplorerConfig _config;

        public SelectAudioViewModel(
            ExplorerConfig config,
            IPopupProvider popupProvider) : base(popupProvider)
        {
            _config = config;
            Entries = new ReactiveCollection<SelectAudioEntryViewModel>(GetEntries());
            SelectedExtension = new ReactiveProperty<string>();
            SetSelectedExtension(Entries[0]);
        }

        public ReactiveProperty<string> SelectedExtension { get; }
        public ReactiveCollection<SelectAudioEntryViewModel> Entries { get; }

        public void SubscribeExtensionsOnSelected()
        {
            foreach (var entry in Entries)
            {
                entry.Selected += SetSelectedExtension;
            }
        }

        public void UnsubscribeExtensionsOnSelected()
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