using System;
using System.IO;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    internal sealed class FileExplorerConfig : ScriptableObject
    {
        [SerializeField] private string _rootFolder = string.Empty;
        [SerializeField] private ExplorerIconsConfig _iconsConfig;
        [SerializeField] private ExplorerExtensionsConfig _extensionsConfig;

        [NonSerialized] private string _rootPath;
        
        public string RootPath => _rootPath ??= GetRootPath();
        
        public ExplorerIconsConfig IconsConfig => _iconsConfig;
        public ExplorerExtensionsConfig ExtensionsConfig => _extensionsConfig;

        private string GetRootPath()
        {
            var rootPath = Application.persistentDataPath;
            
            if (!string.IsNullOrEmpty(_rootFolder))
            {
                rootPath = Path.Combine(rootPath, _rootFolder);
            }

            return rootPath.PathSlash();
        }
    }
}