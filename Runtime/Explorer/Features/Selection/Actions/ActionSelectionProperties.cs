﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Selection.Services.Properties;
using PhlegmaticOne.FileExplorer.Popups.Properties;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectionProperties : IAction
    {
        private readonly ISelectionPropertiesProvider _selectionPropertiesProvider;
        private readonly IPropertiesPopupProvider _propertiesPopupProvider;

        public ActionSelectionProperties(
            ISelectionPropertiesProvider selectionPropertiesProvider,
            IPropertiesPopupProvider propertiesPopupProvider)
        {
            _selectionPropertiesProvider = selectionPropertiesProvider;
            _propertiesPopupProvider = propertiesPopupProvider;
        }

        public Task Execute(CancellationToken token)
        {
            var selectionProperties = _selectionPropertiesProvider.GetSelectionProperties();
            
            var properties = new Dictionary<string, string>
            {
                { "Selection", GetSelectionView(selectionProperties.EntriesCounter) },
                { "Size", selectionProperties.SelectionSize.BuildUnitView() }
            };

            return _propertiesPopupProvider.ViewProperties(properties, "Selection properties");
        }

        private static string GetSelectionView(FileEntriesCounter count)
        {
            return $"Files: {count.FilesCount}, Directories: {count.DirectoriesCount}";
        }
    }
}