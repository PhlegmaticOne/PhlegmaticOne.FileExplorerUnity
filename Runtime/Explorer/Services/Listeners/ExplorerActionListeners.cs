namespace PhlegmaticOne.FileExplorer.Services.Listeners
{
    internal sealed class ExplorerActionListeners
    {
        private readonly IExplorerActionListener[] _listeners;

        public ExplorerActionListeners(IExplorerActionListener[] listeners)
        {
            _listeners = listeners;
        }

        public void StartListen()
        {
            foreach (var listener in _listeners)
            {
                listener.StartListen();
            }
        }

        public void StopListen()
        {
            foreach (var listener in _listeners)
            {
                listener.StopListen();
            }
        }
    }
}