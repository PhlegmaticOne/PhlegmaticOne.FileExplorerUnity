using System;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerConfig : IExplorerConfig
    {
        [SerializeField] private ExplorerIconsConfig _icons;
        [SerializeField] private ExplorerExtensionsConfig _extensions;
        [SerializeField] private ExplorerViewConfig _view;

        public static ExplorerConfig Create(TMP_FontAsset fontAsset)
        {
            return new ExplorerConfig(
                ExplorerIconsConfig.Default, 
                ExplorerExtensionsConfig.Default,
                ExplorerViewConfig.Default(fontAsset));
        }

        private ExplorerConfig(
            ExplorerIconsConfig icons, 
            ExplorerExtensionsConfig extensions,
            ExplorerViewConfig view)
        {
            _icons = icons;
            _extensions = extensions;
            _view = view;
        }

        ExplorerConfig IExplorerConfig.Value => this;
        public ExplorerIconsConfig Icons => _icons;
        public ExplorerExtensionsConfig Extensions => _extensions;
        public ExplorerViewConfig View => _view;
    }
}