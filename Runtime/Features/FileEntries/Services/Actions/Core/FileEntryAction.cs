using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal abstract class FileEntryAction : ActionViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly IFileEntryActionExecuteHandler _executeHandler;

        protected FileEntryAction(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IFileEntryActionExecuteHandler executeHandler) : base(actionsViewModel)
        {
            _fileEntry = fileEntry;
            _executeHandler = executeHandler;
        }

        protected sealed override async Task<bool> ExecuteAction()
        {
            if (!_executeHandler.ProcessCanStartAction(_fileEntry))
            {
                return false;
            }
            
            try
            {
                return await ExecuteAction(_fileEntry);
            }
            catch (Exception exception)
            {
                await _executeHandler.HandleException(_fileEntry, exception);
                return false;
            }
        }

        protected abstract Task<bool> ExecuteAction(FileEntryViewModel fileEntry);
    }
}