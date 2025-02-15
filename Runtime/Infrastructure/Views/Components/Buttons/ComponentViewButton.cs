using System;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons
{
    internal sealed class ComponentViewButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private ICommand _command;
        private Func<object> _parameterGetter;

        public void Bind(ICommand command, Func<object> parameterGetter = null)
        {
            _parameterGetter = parameterGetter;
            _command = command;
            _command.CanExecuteChanged += UpdateInteraction;
            _button.onClick.AddListener(ExecuteCommand);
        }

        public void Unbind()
        {
            _command.CanExecuteChanged -= UpdateInteraction;
            _button.onClick.RemoveListener(ExecuteCommand);
            _command = null;
        }

        private void ExecuteCommand()
        {
            var parameter = _parameterGetter?.Invoke();
            _command.Execute(parameter);
        }

        private void UpdateInteraction()
        {
            _button.interactable = _command.CanExecute();
        }
    }
}