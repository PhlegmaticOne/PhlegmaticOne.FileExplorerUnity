using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Path.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Path.ViewModels
{
    internal sealed class PathViewModel
    {
        private readonly FileExplorerConfig _config;
        private readonly IPathParser _pathParser;

        public PathViewModel(FileExplorerConfig config, IPathParser pathParser)
        {
            _config = config;
            _pathParser = pathParser;
            PathParts = new ReactiveCollection<PathPartViewModel>();
            Path = new ReactiveProperty<string>();
        }
        
        public ReactiveProperty<string> Path { get; }
        public ReactiveCollection<PathPartViewModel> PathParts { get; }

        public void UpdatePathParts(string path)
        {
            Path.SetValueNotify(path);
            UpdatePathPartsPrivate(path);
        }

        public string GetRootPath()
        {
            return _config.RootPath;
        }

        public bool CurrentPathIsRoot()
        {
            return Path.Value.Equals(GetRootPath());
        }

        public string GetParentPath()
        {
            return Directory.GetParent(Path)!.FullName.PathSlash();
        }

        public void Clear()
        {
            PathParts.Clear();
        }

        private void UpdatePathPartsPrivate(string path)
        {
            var parseResult = _pathParser.Parse(path);

            if (parseResult.Count == PathParts.Count)
            {
                return;
            }

            if (parseResult.Count > PathParts.Count)
            {
                AddPathPartsEntered(parseResult);
            }
            else
            {
                RemovePathPartsExited(parseResult);
            }
        }

        private void AddPathPartsEntered(IEnumerable<PathPartViewModel> parseResult)
        {
            if (PathParts.Count > 0)
            {
                PathParts[^1].SetCurrent(false);
            }
                
            PathParts.AddRange(parseResult.Skip(PathParts.Count));
            PathParts[^1].SetCurrent(true);
        }

        private void RemovePathPartsExited(IReadOnlyCollection<PathPartViewModel> parseResult)
        {
            var removeCount = PathParts.Count - parseResult.Count;
            PathParts.RemoveRangeFromLast(removeCount);
            PathParts[^1].SetCurrent(true);
        }
    }
}