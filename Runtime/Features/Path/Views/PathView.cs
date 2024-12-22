using System.Collections.Generic;
using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Views
{
    internal sealed class PathView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private RectTransform _pathPartsParent;
        [SerializeField] private PathPartView _pathPartViewPrefab;

        private readonly List<PathPartView> _pathPartViews = new();
        
        private PathViewModel _viewModel;

        [ViewInject]
        public void Construct(PathViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.PathParts.CollectionChanged += UpdatePathParts;
        }

        public void Unbind()
        {
            _viewModel.PathParts.CollectionChanged -= UpdatePathParts;
        }

        private void UpdatePathParts(ReactiveCollectionChangedEventArgs<PathPartViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddPartViews(eventArgs.AffectedItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemovePartViews(eventArgs.AffectedItems);
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
        
        private void RemovePartViews(IEnumerable<PathPartViewModel> pathParts)
        {
            foreach (var pathPart in pathParts)
            {
                var view = _pathPartViews.Find(x => x.IsBindTo(pathPart));
                view.Release();
                Destroy(view.gameObject);
                _pathPartViews.Remove(view);
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