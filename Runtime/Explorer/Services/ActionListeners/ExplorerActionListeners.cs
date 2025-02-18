namespace PhlegmaticOne.FileExplorer.Services.ActionListeners
{
    internal sealed class ExplorerActionListeners : IExplorerActionListeners
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
                listener.Start();
            }
        }

        public void StopListen()
        {
            foreach (var listener in _listeners)
            {
                listener.Stop();
            }
        }
    }
}