﻿using System;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class FileEntryActionsProvider : IFileEntryActionsProvider
    {
        private readonly FileEntryActionsViewModel _viewModel;
        private readonly IFileEntryActionsFactory[] _actionsFactory;

        public FileEntryActionsProvider(
            FileEntryActionsViewModel viewModel,
            IFileEntryActionsFactory[] actionsFactory)
        {
            _viewModel = viewModel;
            _actionsFactory = actionsFactory;
        }

        public void ShowActions(FileEntryViewModel fileEntry)
        {
            var factory = Array.Find(_actionsFactory, x => x.EntryType == fileEntry.EntryType);
            var actions = factory.GetActions(fileEntry);
            var actionPosition = fileEntry.Position.ToActionViewPositionData(FileActionViewAlignment.DockToTargetCenter);
            _viewModel.ShowActions(actions, actionPosition);
        }
    }
}