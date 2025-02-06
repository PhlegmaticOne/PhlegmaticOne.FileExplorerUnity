using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal abstract class FileEntryAction : ActionViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly IFileEntryActionExecuteHandler _executeHandler;

        protected FileEntryAction(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler) : base(actionsViewModel, cancellationProvider)
        {
            _fileEntry = fileEntry;
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
                await ExecuteAction(_fileEntry, token);
            }
            catch (Exception exception)
            {
                await _executeHandler.HandleException(_fileEntry, exception);
            }
        }

        protected abstract Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token);
    }
}