using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.Internet
{
    internal sealed class InternetProvider : IInternetProvider
    {
        public bool IsAvailable => Application.internetReachability != NetworkReachability.NotReachable;
    }
}