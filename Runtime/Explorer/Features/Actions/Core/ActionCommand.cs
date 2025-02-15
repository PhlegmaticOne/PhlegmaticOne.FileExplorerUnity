using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal sealed class ActionCommand : IActionCommand
    {
        private readonly IActionErrorHandler _errorHandler;
        private readonly IAction _action;

        public ActionCommand(IActionErrorHandler errorHandler, IAction action)
        {
            _errorHandler = errorHandler;
            _action = action;
        }
        
        public async Task Execute(CancellationToken token)
        {
            try
            {
                await _action.Execute(token);
            }
            catch (Exception e)
            {
                await _errorHandler.HandleError(e);
            }
        }
    }
}