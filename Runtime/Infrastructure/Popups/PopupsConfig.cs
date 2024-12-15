using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal sealed class PopupsConfig : ScriptableObject
    {
        [SerializeField] private PopupView[] _viewPrefabs;

        public T GetView<T>() where T : PopupView
        {
            return Array.Find(_viewPrefabs, x => x is T) as T;
        }
    }
}