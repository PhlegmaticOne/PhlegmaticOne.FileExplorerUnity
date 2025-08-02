namespace PhlegmaticOne.FileExplorer.Services.Internet
{
    internal interface IInternetProvider
    {
        bool IsAvailable { get; }
    }
}