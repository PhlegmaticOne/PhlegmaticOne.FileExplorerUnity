using PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States
{
    internal sealed class ExplorerStateProvider : IExplorerStateProvider
    {
        private readonly IExplorerShowCommand _showCommand;
        private readonly IExplorerCloseCommand _closeCommand;

        public ExplorerStateProvider(IExplorerShowCommand showCommand, IExplorerCloseCommand closeCommand)
        {
            _showCommand = showCommand;
            _closeCommand = closeCommand;
        }

        public void Show()
        {
            _showCommand.Show();
        }

        public void Close()
        {
            _closeCommand.Close();
        }
    }
}