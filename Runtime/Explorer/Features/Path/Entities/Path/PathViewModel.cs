using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Parser;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Root;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Entities.Path
{
    internal sealed class PathViewModel : ViewModel, IViewModelDisposable
    {
        private readonly IPathParser _pathParser;
        private readonly IRootPathProvider _rootPathProvider;

        public PathViewModel(IPathParser pathParser, IRootPathProvider rootPathProvider)
        {
            _pathParser = pathParser;
            _rootPathProvider = rootPathProvider;
            PathParts = new ReactiveCollection<PathPartViewModel>();
            Path = new ReactiveProperty<string>();
        }
        
        public ReactiveProperty<string> Path { get; }
        public ReactiveCollection<PathPartViewModel> PathParts { get; }

        public void UpdatePathParts(string path)
        {
            var resultPath = path.ToForwardSlash();
            Path.SetValueNotify(resultPath);
            UpdatePathPartsPrivate(resultPath);
        }

        public string GetRootPath()
        {
            return _rootPathProvider.RootPath;
        }

        public bool CurrentPathIsRoot()
        {
            return Path.Value.Equals(GetRootPath());
        }

        public string GetParentPath()
        {
            return Directory.GetParent(Path)!.FullName.ToForwardSlash();
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
            
            PathParts[^1].SetCurrent(true);
        }

        private void AddPathPartsEntered(IEnumerable<PathPartViewModel> parseResult)
        {
            if (PathParts.Count > 0)
            {
                PathParts[^1].SetCurrent(false);
            }
                
            PathParts.AddRange(parseResult.Skip(PathParts.Count));
        }

        private void RemovePathPartsExited(IReadOnlyCollection<PathPartViewModel> parseResult)
        {
            var removeCount = PathParts.Count - parseResult.Count;
            PathParts.RemoveRangeFromLast(removeCount);
        }

        public void Dispose()
        {
            Clear();
        }
    }
}