﻿using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal abstract class FileEntryViewModel : IDisposable
    {
        protected readonly IExplorerIconsProvider IconsProvider;
        protected readonly SelectionViewModel SelectionViewModel;
        protected readonly IFileOperations FileOperations;

        protected FileEntryViewModel(
            string name, string path,
            IExplorerIconsProvider iconsProvider,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations)
        {
            Path = path;
            Name = new ReactiveProperty<string>(name);
            IsSelected = new ReactiveProperty<bool>(false);
            IsActive = new ReactiveProperty<bool>(true);
            Position = new FileEntryPosition();
            Icon = new ExplorerIconData();
            IconsProvider = iconsProvider;
            SelectionViewModel = selectionViewModel;
            FileOperations = fileOperations;
        }

        public abstract FileEntryType EntryType { get; }
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<bool> IsSelected { get; }
        public ReactiveProperty<bool> IsActive { get; }
        public string Path { get; protected set; }
        public FileEntryPosition Position { get; }
        public ExplorerIconData Icon { get; }
        
        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract FileEntryProperties GetProperties();
        public abstract void Rename(string newName);
        public abstract void Delete();
        public abstract void OnClick();
        public abstract void Dispose();

        public void OnHoldClick()
        {
            if (!SelectionViewModel.IsSelectionActive)
            {
                SelectionViewModel.UpdateSelection(this);
            }
        }
    }
}