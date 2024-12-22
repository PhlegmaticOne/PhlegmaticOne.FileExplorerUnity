namespace PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services
{
    internal interface IScreenMessageTextChangeListener
    {
        void StartListen();
        void StopListen();
    }
}