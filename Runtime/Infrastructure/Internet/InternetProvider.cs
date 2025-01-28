using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Internet
{
    internal sealed class InternetProvider : IInternetProvider
    {
        public bool IsAvailable => Application.internetReachability != NetworkReachability.NotReachable;
    }
}