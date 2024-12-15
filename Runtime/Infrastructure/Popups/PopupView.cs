using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupView : MonoBehaviour
    {
        public abstract void Release();
        public abstract void Discard();
    }
}