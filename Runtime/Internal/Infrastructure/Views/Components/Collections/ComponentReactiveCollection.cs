using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class ComponentReactiveCollection<TViewModel, TView> : MonoBehaviour
        where TViewModel : ViewModel
        where TView : View
    {
        [SerializeField] private RectTransform _viewsParent;
        [SerializeReference] private IReactiveCollectionBehaviour[] _behaviours = Array.Empty<IReactiveCollectionBehaviour>();

        private readonly Dictionary<TViewModel, IViewContainer<TView>> _views = new();

        private ReactiveCollection<TViewModel> _collection;
        private IViewProvider _viewProvider;

        [Inject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
        }
        
        public RectTransform Transform => transform as RectTransform;
        public Vector2 Size => Transform.rect.size;

        public void Bind(ReactiveCollection<TViewModel> collection)
        {
            _collection = collection;
            _collection.CollectionChanged += UpdateView;

            foreach (var behaviour in _behaviours)
            {
                behaviour.OnBind();
            }

            if (collection.Count > 0)
            {
                AddViews(collection);
            }
        }

        public void Rebuild()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }

        public void Release()
        {
            ClearViews();
            _collection.CollectionChanged -= UpdateView;
            _collection = null;
            
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnRelease();
            }
        }

        private void UpdateView(ReactiveCollectionChangedEventArgs<TViewModel> eventArgs)
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

        private void AddViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = _viewProvider.GetView<TView>(_viewsParent, viewModel);
                _views.Add(viewModel, view);

                foreach (var behaviour in _behaviours)
                {
                    behaviour.OnAdded(view.View);
                }
            }
        }

        private void RemoveViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = _views[viewModel];
                view.Release();
                _views.Remove(viewModel);
                
                foreach (var behaviour in _behaviours)
                {
                    behaviour.OnRemoved(view.View);
                }
            }
        }

        private void ClearViews()
        {
            foreach (var view in _views)
            {
                view.Value.Release();
            }
            
            _views.Clear();
            
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnClear();
            }
        }
    }
}