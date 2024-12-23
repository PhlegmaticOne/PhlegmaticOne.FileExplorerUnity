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
        private readonly IFileEntryActionStartHandler _actionStartHandler;
        private readonly IFileEntryActionErrorHandler _actionErrorHandler;

        protected FileEntryAction(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IFileEntryActionStartHandler actionStartHandler,
            IFileEntryActionErrorHandler actionErrorHandler) : base(actionsViewModel)
        {
            _fileEntry = fileEntry;
            _actionStartHandler = actionStartHandler;
            _actionErrorHandler = actionErrorHandler;
        }

        protected sealed override async Task<bool> ExecuteAction()
        {
            if (!_actionStartHandler.ProcessCanStartAction(_fileEntry))
            {
                return false;
            }
            
            try
            {
                return await ExecuteAction(_fileEntry);
            }
            catch (Exception exception)
            {
                await _actionErrorHandler.HandleException(_fileEntry, exception);
                return false;
            }
        }

        protected abstract Task<bool> ExecuteAction(FileEntryViewModel fileEntry);
    }
}