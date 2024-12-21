using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Path.Services
{
    internal sealed class PathParser : IPathParser
    {
        private const string RootPathPartName = "Root";
        
        private readonly IPathPartFactory _pathPartFactory;
        private readonly FileExplorerConfig _config;

        public PathParser(IPathPartFactory pathPartFactory, FileExplorerConfig config)
        {
            _pathPartFactory = pathPartFactory;
            _config = config;
        }
        
        public IEnumerable<PathPartViewModel> Parse(string path)
        {
            yield return _pathPartFactory.CreatePathPart(RootPathPartName);

            if (path.Equals(_config.RootPath, StringComparison.Ordinal))
            {
                yield break;
            }
            
            var memory = path.AsMemory(_config.RootPath.Length + 1);
    
            while (true)
            {
                var index = memory.Span.IndexOfAny('\\', '/');

                if (index is 0 or -1)
                {
                    if (memory.Length > 0)
                    {
                        yield return _pathPartFactory.CreatePathPart(memory.ToString());
                    }
                    
                    break;
                }

                var pathPart = memory[..index].ToString();
                yield return _pathPartFactory.CreatePathPart(pathPart);
                memory = memory[(index + 1)..];
            }
        }
    }
}