using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
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

        private string _startupLocationRuntime;
        
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
            _startupLocationRuntime = startupLocation.PathSlash();
        }

        public ExplorerConfig Value => this;
        public ExplorerIconsConfig Icons => _icons;
        public ExplorerExtensionsConfig Extensions => _extensions;
        public ExplorerViewConfig View => _view;

        public string StartupLocation
        {
            get
            {
                if (string.IsNullOrEmpty(_startupLocationRuntime))
                {
                    _startupLocationRuntime = string.IsNullOrEmpty(_startupLocation)
                        ? Application.persistentDataPath.PathSlash()
                        : _startupLocation.PathSlash();
                }

                return _startupLocationRuntime;
            }
            set => _startupLocationRuntime = value.PathSlash();
        }
    }
}