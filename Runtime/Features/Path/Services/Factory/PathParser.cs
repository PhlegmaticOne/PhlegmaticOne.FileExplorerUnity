using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal sealed class PathParser : IPathParser
    {
        private const string RootPathPartName = "Root";
        
        private readonly IPathPartFactory _pathPartFactory;
        private readonly ExplorerOpenConfig _config;

        public PathParser(IPathPartFactory pathPartFactory, ExplorerOpenConfig config)
        {
            _pathPartFactory = pathPartFactory;
            _config = config;
        }
        
        public IReadOnlyCollection<PathPartViewModel> Parse(string path)
        {
            var result = new List<PathPartViewModel>
            {
                FromMemory(RootPathPartName.AsMemory())
            };

            if (!path.Equals(_config.StartupLocation, StringComparison.Ordinal))
            {
                FillPathPartsNextFromRootPath(path, result);
            }
            
            return result;
        }

        private void FillPathPartsNextFromRootPath(string path, List<PathPartViewModel> result)
        {
            var memory = path.AsMemory(_config.StartupLocation.Length + 1);
    
            while (true)
            {
                var index = memory.Span.IndexOfAny('\\', '/');

                if (index is 0 or -1)
                {
                    break;
                }

                result.Add(FromMemory(memory[..index]));
            }
            
            if (memory.Length > 0)
            {
                result.Add(FromMemory(memory));
            }
        }

        private PathPartViewModel FromMemory(ReadOnlyMemory<char> partMemory)
        {
            return _pathPartFactory.CreatePathPart(partMemory.ToString());
        }
    }
}