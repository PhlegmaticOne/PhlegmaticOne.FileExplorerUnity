namespace PhlegmaticOne.FileExplorer.Services.Listeners
{
    internal interface IExplorerActionListener
    {
        void StartListen();
        void StopListen();
    }
}