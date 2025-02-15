using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal class FileEntryActionViewModel : ActionViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly IFileEntryActionExecuteHandler _executeHandler;
        private readonly IFileEntryAction _fileEntryAction;

        public FileEntryActionViewModel(
            string key,
            FileEntryViewModel fileEntry, 
            IFileEntryAction fileEntryAction,
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler) : base(key, actionsViewModel, cancellationProvider)
        {
            _fileEntry = fileEntry;
            _fileEntryAction = fileEntryAction;
            _executeHandler = executeHandler;
        }

        protected sealed override async Task ExecuteAction(CancellationToken token)
        {
            if (!_executeHandler.ProcessCanStartAction(_fileEntry))
            {
                return;
            }
            
            try
            {
                await _fileEntryAction.ExecuteAction(_fileEntry, token);
            }
            catch (Exception exception)
            {
                await _executeHandler.HandleException(_fileEntry, exception);
            }
        }
    }
}