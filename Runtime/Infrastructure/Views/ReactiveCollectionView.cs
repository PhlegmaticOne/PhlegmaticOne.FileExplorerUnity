using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class ReactiveCollectionView<TViewModel, TView> : MonoBehaviour
        where TViewModel : ViewModel
        where TView : View
    {
        [SerializeField] private RectTransform _viewsParent;

        private readonly List<ViewContainer<TView>> _views = new();
        
        private IViewProvider _viewProvider;
        
        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
        }
        
        public RectTransform Transform => transform as RectTransform;
        public Vector2 Size => Transform.rect.size;
        public int ItemsCount => _views.Count;

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

        protected abstract ViewContainer<TView> CreateView(IViewProvider viewProvider, TViewModel viewModel);
        
        private void AddViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = CreateView(_viewProvider, viewModel);
                view.View.transform.SetParent(_viewsParent, false);
                _views.Add(view);
            }
        }

        private void RemoveViews(IEnumerable<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var view = _views.Find(x => x.View.IsBindTo(viewModel));
                view.Release();
                _views.Remove(view);
            }
        }

        private void ClearViews()
        {
            foreach (var view in _views)
            {
                view.Release();
            }
            
            _views.Clear();
        }
    }
}