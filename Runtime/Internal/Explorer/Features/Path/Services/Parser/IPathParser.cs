using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services.Parser
{
    internal interface IPathParser
    {
        IReadOnlyCollection<PathPartViewModel> Parse(string path);
    }
}