using PhlegmaticOne.FileExplorer.Features.Actions.Configs;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action
{
    internal sealed class ActionDropdownItemView : View
    {
        [SerializeField] private ComponentButton _button;
        [SerializeField] private ActionDropdownItemStaticView _staticView;
        
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
            _staticView.Setup(viewData);
        }

        public override void Release()
        {
            _button.Release();
            _action = null;
        }
    }
}