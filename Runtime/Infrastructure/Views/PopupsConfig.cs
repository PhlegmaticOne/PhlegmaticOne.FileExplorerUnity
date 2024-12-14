using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal sealed class PopupsConfig : ScriptableObject
    {
        [SerializeField] private View[] _viewPrefabs;

        public T GetView<T>() where T : View
        {
            return Array.Find(_viewPrefabs, x => x is T) as T;
        }
    }
}