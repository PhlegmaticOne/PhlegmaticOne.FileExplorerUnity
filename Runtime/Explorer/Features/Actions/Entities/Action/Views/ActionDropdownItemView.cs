using PhlegmaticOne.FileExplorer.Features.Actions.Configs;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action
{
    internal sealed class ActionDropdownItemView : View
    {
        [SerializeField] private ComponentViewButton _button;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _background;
        
        private ActionViewModel _action;
        private ActionsViewConfig _viewConfig;

        [ViewInject]
        public void Construct(ActionViewModel action, ActionsViewConfig viewConfig)
        {
            _viewConfig = viewConfig;
            _action = action;
        }

        protected override void OnInitializing()
        {
            var viewData = _viewConfig.GetViewData(_action.Key);
            _button.Bind(_action.ExecuteCommand);
            UpdateDescription(viewData.Description);
            UpdateColors(viewData);
        }

        public override void Release()
        {
            _button.Unbind();
            _action = null;
        }

        private void UpdateDescription(string description)
        {
            _description.text = description;
        }

        private void UpdateColors(ActionViewData viewData)
        {
            _description.color = viewData.TextColor;
            _background.color = viewData.BackgroundColor;
        }
    }
}