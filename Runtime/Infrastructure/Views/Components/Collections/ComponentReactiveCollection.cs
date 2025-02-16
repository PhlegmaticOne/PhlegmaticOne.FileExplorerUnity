using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class ComponentReactiveCollection<TViewModel, TView> : MonoBehaviour
        where TViewModel : ViewModel
        where TView : View
    {
        [SerializeField] private RectTransform _viewsParent;

        private readonly Dictionary<TViewModel, ViewContainer<TView>> _views = new();

        private ReactiveCollection<TViewModel> _collection;
        private IViewProvider _viewProvider;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
        }
        
        public RectTransform Transform => transform as RectTransform;
        public Vector2 Size => Transform.rect.size;
        public int ItemsCount => _views.Count;

        public void Bind(ReactiveCollection<TViewModel> collection)
        {
            _collection = collection;
            _collection.CollectionChanged += UpdateView;
        }

        public void Release()
        {
            _collection.CollectionChanged -= UpdateView;
            _collection = null;
        }

        public void UpdateView(ReactiveCollectionChangedEventArgs<TViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case ReactiveCollectionChangedAction.Add:
                    AddViews(eventArgs.AffectedItems);
                    break;
                case ReactiveCollectionChangedAction.Remove:
                    RemoveViews(eventArgs.AffectedItems);
                    break;
                case ReactiveCollectionChangedAction.Reset:
                    ClearViews();
                    break;
            }
        }
        
        public void SetPosition(Vector3 position)
        {
            Transform.anchoredPosition = position;
        }
        
        public void Rebuild()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }

        public void AddViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = _viewProvider.GetView<TView>(viewModel);
                view.View.transform.SetParent(_viewsParent, false);
                _views.Add(viewModel, view);
            }
        }

        public void RemoveViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = _views[viewModel];
                view.Release();
                _views.Remove(viewModel);
            }
        }

        public void ClearViews()
        {
            foreach (var view in _views)
            {
                view.Value.Release();
            }
            
            _views.Clear();
        }
    }
}