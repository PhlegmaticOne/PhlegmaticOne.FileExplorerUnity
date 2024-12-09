using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Views
{
    internal sealed class FileExplorerHeaderView : MonoBehaviour, IPointerClickHandler
    {
        private FileEntryActionsViewModel _actionsViewModel;

        public void Bind(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _actionsViewModel.Deactivate();
        }
    }
}