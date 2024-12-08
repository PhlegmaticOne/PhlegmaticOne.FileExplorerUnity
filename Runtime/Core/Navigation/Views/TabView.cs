using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class TabView : MonoBehaviour
    {
        [SerializeField] private FileEntryView _entryViewPrefab;
        [SerializeField] private GridLayoutGroup _fileContainer;

        private readonly List<FileEntryView> _fileEntryViews = new();

        public void AddEntries(IEnumerable<FileEntryViewModel> fileEntries)
        {
            foreach (var fileEntry in fileEntries)
            {
                var view = Instantiate(_entryViewPrefab, _fileContainer.transform);
                view.Bind(fileEntry);
                _fileEntryViews.Add(view);
            }
        }

        public void Clear()
        {
            foreach (var fileEntryView in _fileEntryViews)
            {
                fileEntryView.Release();
                Destroy(fileEntryView.gameObject);
            }
            
            _fileEntryViews.Clear();
        }
    }
}