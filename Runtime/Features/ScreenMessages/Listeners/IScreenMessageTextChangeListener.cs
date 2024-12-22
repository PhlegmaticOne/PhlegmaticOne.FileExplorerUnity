namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Services
{
    internal interface IScreenMessageTextChangeListener
    {
        void StartListen();
        void StopListen();
    }
}