﻿using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Popups.AudioSelect;
using PhlegmaticOne.FileExplorer.Popups.FileView;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionPlayAudio : IFileEntryAction
    {
        private readonly IFileViewAudioProvider _viewAudioProvider;
        private readonly ISelectAudioPopupProvider _selectAudioPopupProvider;

        public FileEntryActionPlayAudio(
            IFileViewAudioProvider viewAudioProvider,
            ISelectAudioPopupProvider selectAudioPopupProvider) 
        {
            _viewAudioProvider = viewAudioProvider;
            _selectAudioPopupProvider = selectAudioPopupProvider;
        }

        public async Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            AudioType audioType;
            bool shouldPlayAudio;
            var file = (FileViewModel)fileEntry;

            if (!file.Extension.HasValue())
            {
                var result = await _selectAudioPopupProvider.SelectAudioType();
                shouldPlayAudio = result.IsSelected;
                audioType = result.SelectedAudioType;
            }
            else
            {
                shouldPlayAudio = true;
                audioType = file.Extension.GetAudioType();
            }

            if (shouldPlayAudio)
            {
                await _viewAudioProvider.ViewAudioFile(file, audioType, token);
            }
        }
    }
}