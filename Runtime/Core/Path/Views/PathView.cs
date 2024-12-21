using System.Collections.Generic;
using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Path.Views
{
    internal sealed class PathView : MonoBehaviour
    {
        [SerializeField] private RectTransform _pathPartsParent;
        [SerializeField] private PathPartView _pathPartViewPrefab;

        private readonly List<PathPartView> _pathPartViews = new();
        
        private PathViewModel _viewModel;

        public void Bind(PathViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void Subscribe()
        {
            _viewModel.PathParts.CollectionChanged += UpdatePathParts;
        }

        private void UpdatePathParts(ReactiveCollectionChangedEventArgs<PathPartViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddPartViews(eventArgs.AffectedItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ClearPartViews();
                    break;
            }
        }

        private void AddPartViews(IEnumerable<PathPartViewModel> pathParts)
        {
            foreach (var pathPart in pathParts)
            {
                var view = Instantiate(_pathPartViewPrefab, _pathPartsParent);
                view.Bind(pathPart);
                _pathPartViews.Add(view);
            }
        }

        private void ClearPartViews()
        {
            foreach (var view in _pathPartViews)
            {
                view.Release();
                Destroy(view.gameObject);
            }
            
            _pathPartViews.Clear();
        }
    }
}