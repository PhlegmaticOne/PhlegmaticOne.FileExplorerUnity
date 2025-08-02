using System;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal interface IActionErrorHandler
    {
        Task HandleError(Exception exception);
    }
}