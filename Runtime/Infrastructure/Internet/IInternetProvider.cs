namespace PhlegmaticOne.FileExplorer.Infrastructure.Internet
{
    internal interface IInternetProvider
    {
        bool IsAvailable { get; }
    }
}