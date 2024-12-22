using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal interface IPathParser
    {
        IReadOnlyCollection<PathPartViewModel> Parse(string path);
    }
}