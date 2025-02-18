using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal class FileEntryActionCommand : IActionCommand
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly IFileEntryActionExecuteHandler _executeHandler;
        private readonly IFileEntryAction _fileEntryAction;

        public FileEntryActionCommand(
            FileEntryViewModel fileEntry, 
            IFileEntryAction fileEntryAction,
            IFileEntryActionExecuteHandler executeHandler)
        {
            _fileEntry = fileEntry;
            _fileEntryAction = fileEntryAction;
            _executeHandler = executeHandler;
        }

        public async Task Execute(CancellationToken token)
        {
            if (!_executeHandler.ProcessCanStartAction(_fileEntry))
            {
                return;
            }
            
            try
            {
                await _fileEntryAction.Execute(_fileEntry, token);
            }
            catch (Exception exception)
            {
                await _executeHandler.HandleException(_fileEntry, exception);
            }
        }
    }
}