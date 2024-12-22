using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Views
{
    internal sealed class TabCollectionView : MonoBehaviour
    {
        [SerializeField] private FileEntryView _entryViewPrefab;
        [SerializeField] private GridLayoutGroup _fileContainer;
        [SerializeField] private RectTransform _headerTransform;

        private readonly List<FileEntryView> _fileEntryViews = new();

        public void AddEntries(IEnumerable<FileEntryViewModel> fileEntries)
        {
            foreach (var fileEntry in fileEntries)
            {
                var view = Instantiate(_entryViewPrefab, _fileContainer.transform);
                view.Bind(fileEntry);
                view.UpdateHeaderTransform(_headerTransform);
                _fileEntryViews.Add(view);
            }
        }

        public void RemoveEntries(IEnumerable<FileEntryViewModel> fileEntries)
        {
            foreach (var fileEntry in fileEntries)
            {
                var view = _fileEntryViews.Find(x => x.IsBindTo(fileEntry));
                DestroyView(view);
                _fileEntryViews.Remove(view);
            }
        }

        public void Clear()
        {
            foreach (var fileEntryView in _fileEntryViews)
            {
                DestroyView(fileEntryView);
            }
            
            _fileEntryViews.Clear();
        }

        private static void DestroyView(FileEntryView fileEntryView)
        {
            fileEntryView.Release();
            Destroy(fileEntryView.gameObject);
        }
    }
}