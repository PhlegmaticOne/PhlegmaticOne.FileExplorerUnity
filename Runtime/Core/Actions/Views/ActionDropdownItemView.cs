using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Actions.Views
{
    internal sealed class ActionDropdownItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _background;
        [SerializeField] private Button _button;
        
        private IExplorerAction _action;

        public void Construct(IExplorerAction action, FileEntryActionColor color)
        {
            _action = action;
            _button.onClick.AddListener(ExecuteAction);
            UpdateDescription(action.Description);
            UpdateColors(color);
        }

        public void Release()
        {
            _button.onClick.RemoveListener(ExecuteAction);
            _action = null;
        }

        private void ExecuteAction()
        {
            _action.Execute().ForgetUnawareCancellation();
        }

        private void UpdateDescription(string description)
        {
            _description.text = description;
        }

        private void UpdateColors(FileEntryActionColor color)
        {
            _description.color = color.TextColor;
            _background.color = color.BackgroundColor;
        }
    }
}