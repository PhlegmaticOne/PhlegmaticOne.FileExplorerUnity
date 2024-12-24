using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    internal sealed class FileExplorerConfig : ScriptableObject
    {
        [SerializeField] private ExplorerIconsConfig _iconsConfig;
        [SerializeField] private ExplorerExtensionsConfig _extensionsConfig;

        public ExplorerIconsConfig IconsConfig => _iconsConfig;
        public ExplorerExtensionsConfig ExtensionsConfig => _extensionsConfig;
    }
}