using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Popups.Errors;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal sealed class ActionErrorHandler : IActionErrorHandler
    {
        private readonly IErrorPopupProvider _errorPopupProvider;

        public ActionErrorHandler(IErrorPopupProvider errorPopupProvider)
        {
            _errorPopupProvider = errorPopupProvider;
        }
        
        public Task HandleError(Exception exception)
        {
            return _errorPopupProvider.ViewError(exception);
        }
    }
}