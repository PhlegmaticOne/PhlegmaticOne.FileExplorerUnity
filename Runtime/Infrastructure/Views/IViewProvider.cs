using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal interface IViewProvider
    {
        ViewContainer<T> GetView<T>(Transform parent, params object[] parameters) where T : View;
        void ReleaseView<T>(T view) where T : View;
    }
}