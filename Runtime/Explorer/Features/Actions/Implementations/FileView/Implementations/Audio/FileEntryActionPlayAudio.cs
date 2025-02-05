﻿using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileEntryActionPlayAudio : FileEntryAction
    {
        private readonly IFileViewAudioProvider _viewAudioProvider;
        private readonly ISelectAudioViewProvider _selectAudioViewProvider;

        public FileEntryActionPlayAudio(
            IFileViewAudioProvider viewAudioProvider,
            ISelectAudioViewProvider selectAudioViewProvider,
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel, 
            IExplorerCancellationProvider cancellationProvider, 
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _viewAudioProvider = viewAudioProvider;
            _selectAudioViewProvider = selectAudioViewProvider;
        }

        public override string Description => "Play audio";
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.yellow);
        
        protected override async Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            AudioType audioType;
            bool shouldPlayAudio;
            var file = (FileViewModel)fileEntry;

            if (!file.Extension.HasValue())
            {
                var result = await _selectAudioViewProvider.SelectAudioType();
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