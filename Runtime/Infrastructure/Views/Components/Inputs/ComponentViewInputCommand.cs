using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentViewInputCommand : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _input;
        
        private ICommand _command;

        public void Bind(ICommand command)
        {
            _command = command;
            _input.onValueChanged.AddListener(ExecuteCommand);
        }

        public void Unbind()
        {
            _input.onValueChanged.RemoveListener(ExecuteCommand);
            _command = null;
        }

        private void ExecuteCommand(string text)
        {
            _command.Execute(text);
        }
    }
}