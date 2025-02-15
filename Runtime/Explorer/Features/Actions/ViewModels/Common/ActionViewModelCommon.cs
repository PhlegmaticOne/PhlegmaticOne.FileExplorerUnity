using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common.Handlers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common
{
    internal sealed class ActionViewModelCommon : ActionViewModel
    {
        private readonly IActionCommand _actionCommand;
        private readonly IActionErrorHandler _errorHandler;

        public ActionViewModelCommon(
            string key,
            IActionCommand actionCommand,
            IActionErrorHandler errorHandler,
            ActionsViewModel actionsViewModel, 
            IExplorerCancellationProvider cancellationProvider) : base(key, actionsViewModel, cancellationProvider)
        {
            _actionCommand = actionCommand;
            _errorHandler = errorHandler;
        }

        protected override async Task ExecuteAction(CancellationToken token)
        {
            try
            { 
                await _actionCommand.ExecuteAction(token);
            }
            catch (Exception e)
            {
                await _errorHandler.HandleError(e);
            }
        }
    }
}