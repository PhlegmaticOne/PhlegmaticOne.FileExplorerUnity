﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectionProperties : ActionViewModel
    {
        private readonly IPopupProvider _popupProvider;
        private readonly ISelectionPropertiesProvider _selectionPropertiesProvider;

        public ActionSelectionProperties(
            IPopupProvider popupProvider,
            ISelectionPropertiesProvider selectionPropertiesProvider,
            IExplorerCancellationProvider cancellationProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel, cancellationProvider)
        {
            _popupProvider = popupProvider;
            _selectionPropertiesProvider = selectionPropertiesProvider;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task ExecuteAction(CancellationToken token)
        {
            var selectionProperties = _selectionPropertiesProvider.GetSelectionProperties();
            
            var properties = new Dictionary<string, string>
            {
                { "Selection", GetSelectionView(selectionProperties.EntriesCounter) },
                { "Size", selectionProperties.SelectionSize.BuildUnitView() }
            };
            
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            await _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }

        private string GetSelectionView(FileEntriesCounter count)
        {
            return $"Files: {count.FilesCount}, Directories: {count.DirectoriesCount}";
        }
    }
}