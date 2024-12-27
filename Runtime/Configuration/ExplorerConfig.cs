using System;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerConfig : IExplorerConfig
    {
        [SerializeField] private string _startupLocation;
        [SerializeField] private ExplorerIconsConfig _icons;
        [SerializeField] private ExplorerExtensionsConfig _extensions;
        [SerializeField] private ExplorerViewConfig _view;

        public static ExplorerConfig Create(TMP_FontAsset fontAsset)
        {
            return new ExplorerConfig(
                string.Empty,
                ExplorerIconsConfig.Default, 
                ExplorerExtensionsConfig.Default,
                ExplorerViewConfig.Default(fontAsset));
        }

        private ExplorerConfig(
            string startupLocation, 
            ExplorerIconsConfig icons, 
            ExplorerExtensionsConfig extensions,
            ExplorerViewConfig view)
        {
            _icons = icons;
            _extensions = extensions;
            _view = view;
        }

        public ExplorerConfig Value => this;
        public ExplorerIconsConfig Icons => _icons;
        public ExplorerExtensionsConfig Extensions => _extensions;
        public ExplorerViewConfig View => _view;

        public string StartupLocation
        {
            get => _startupLocation;
            set => _startupLocation = value;
        }
    }
}