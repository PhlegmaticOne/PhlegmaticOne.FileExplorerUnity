using System;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common.Handlers
{
    internal interface IActionErrorHandler
    {
        Task HandleError(Exception exception);
    }
}