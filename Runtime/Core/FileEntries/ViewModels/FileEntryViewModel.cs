using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
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
            IExplorerIconsProvider iconsProvider,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations)
        {
            Name = new ReactiveProperty<string>();
            IsSelected = new ReactiveProperty<bool>(false);
            Position = new FileEntryPosition();
            Icon = new ExplorerIconData();
            IconsProvider = iconsProvider;
            SelectionViewModel = selectionViewModel;
            FileOperations = fileOperations;
        }

        public abstract FileEntryType EntryType { get; }
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<bool> IsSelected { get; }
        public string Path { get; protected set; }
        public FileEntryPosition Position { get; }
        public ExplorerIconData Icon { get; }

        public FileEntryViewModel Construct(string name, string path)
        {
            Name.SetValueWithoutNotify(name);
            Path = path;
            return this;
        }

        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract Dictionary<string, string> GetProperties();
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