using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Path.Factory;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Root;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal sealed class PathParser : IPathParser
    {
        private const string RootPathPartName = "Root";
        
        private readonly IPathPartFactory _pathPartFactory;
        private readonly IRootPathProvider _rootPathProvider;

        public PathParser(IPathPartFactory pathPartFactory, IRootPathProvider rootPathProvider)
        {
            _pathPartFactory = pathPartFactory;
            _rootPathProvider = rootPathProvider;
        }
        
        public IReadOnlyCollection<PathPartViewModel> Parse(string path)
        {
            var result = new List<PathPartViewModel>
            {
                FromMemory(RootPathPartName.AsMemory())
            };

            if (!path.Equals(_rootPathProvider.RootPath, StringComparison.Ordinal))
            {
                FillPathPartsNextFromRootPath(path, result);
            }
            
            return result;
        }

        private void FillPathPartsNextFromRootPath(string path, ICollection<PathPartViewModel> result)
        {
            var memory = path.AsMemory(_rootPathProvider.RootPath.Length + 1);
    
            while (true)
            {
                var index = memory.Span.IndexOfAny('\\', '/');

                if (index is 0 or -1)
                {
                    break;
                }

                result.Add(FromMemory(memory[..index]));
                memory = memory[(index + 1)..];
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