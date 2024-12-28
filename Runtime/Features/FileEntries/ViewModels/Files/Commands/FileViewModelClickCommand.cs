using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Commands
{
    internal sealed class FileViewModelClickCommand : IFileViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IFileEntryActionsProvider _actionsProvider;
        private readonly IDependencyContainer _container;

        public FileViewModelClickCommand(
            SelectionViewModel selectionViewModel,
            IFileEntryActionsProvider actionsProvider,
            IDependencyContainer container)
        {
            _selectionViewModel = selectionViewModel;
            _actionsProvider = actionsProvider;
            _container = container;
        }
        
        public void OnClick(FileViewModel fileViewModel)
        {
            if (_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(fileViewModel);
                return;
            }

            if (fileViewModel.Extension.IsViewable(out var viewType))
            {
                _container
                    .Instantiate<FileEntryActionViewFile>(fileViewModel, viewType, Color.clear)
                    .Execute()
                    .ForgetUnawareCancellation();
                return;
            }
            
            _actionsProvider.ShowActions(fileViewModel);
        }
    }
}