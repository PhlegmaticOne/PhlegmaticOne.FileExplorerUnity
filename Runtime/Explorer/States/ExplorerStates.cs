using PhlegmaticOne.FileExplorer.States;
using PhlegmaticOne.FileExplorer.States.Commands;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States
{
    internal sealed class ExplorerStates : IExplorerStates
    {
        private readonly IExplorerShowCommand _showCommand;
        private readonly IExplorerCloseCommand _closeCommand;

        public ExplorerStates(IExplorerShowCommand showCommand, IExplorerCloseCommand closeCommand)
        {
            _showCommand = showCommand;
            _closeCommand = closeCommand;
        }

        public void Open()
        {
            _showCommand.Show();
        }

        public void Close()
        {
            _closeCommand.Close();
        }
    }
}