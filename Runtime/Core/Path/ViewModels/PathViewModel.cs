using System.IO;
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

        public void UpdatePath(string path)
        {
            Path.SetValueNotify(path); 
            PathParts.Clear();
            PathParts.AddRange(_pathParser.Parse(path));
            PathParts[^1].SetCurrent();
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
            return !CurrentPathIsRoot() ? Path : Directory.GetParent(Path)!.FullName.PathSlash();
        }

        public void Clear()
        {
            PathParts.Clear();
        }
    }
}