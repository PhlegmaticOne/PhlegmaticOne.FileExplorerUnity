using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Path.Services
{
    internal interface IPathParser
    {
        IReadOnlyCollection<PathPartViewModel> Parse(string path);
    }
}