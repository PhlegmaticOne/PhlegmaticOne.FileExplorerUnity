using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionDropdownItemView : View
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _background;
        [SerializeField] private Button _button;
        
        private ActionViewModel _action;
        private ActionColor _color;

        [ViewInject]
        public void Construct(ActionViewModel action, ActionColor color)
        {
            _color = color;
            _action = action;
        }

        protected override void OnInitializing()
        {
            _button.onClick.AddListener(ExecuteAction);
            UpdateDescription(_action.Description);
            UpdateColors(_color);
        }

        public override void Release()
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

        private void UpdateColors(ActionColor color)
        {
            _description.color = color.TextColor;
            _background.color = color.BackgroundColor;
        }
    }
}