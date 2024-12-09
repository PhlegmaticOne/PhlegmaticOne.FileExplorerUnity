using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class NavigationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tabPathText;
        [SerializeField] private Button _backButton;
        [SerializeField] private LoadingTextView _loadingTextView;
        [SerializeField] private GameObject _emptyDirectoryText;
        [SerializeField] private TabView _tabView;
        
        private NavigationViewModel _viewModel;

        public void Bind(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void UpdateLoadingState(bool isLoading)
        {
            _loadingTextView.SetActive(isLoading);
            _emptyDirectoryText.SetActive(_viewModel.IsEmpty());
        }

        private void UpdatePath(string path)
        {
            _tabPathText.text = path;
            _backButton.interactable = _viewModel.CanMoveBack();
        }

        private void NavigateBack()
        {
            _viewModel.NavigateBack();
        }

        private void HandleFileEntriesCollectionChanged(
            ReactiveCollectionChangedEventArgs<FileEntryViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _tabView.AddEntries(eventArgs.NewItems);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _tabView.Clear();
                    break;
            }
        }

        private void Subscribe()
        {
            _backButton.onClick.AddListener(NavigateBack);
            _viewModel.FileEntries.CollectionChanged += HandleFileEntriesCollectionChanged;
            _viewModel.Path.ValueChanged += UpdatePath;
            _viewModel.IsLoading.ValueChanged += UpdateLoadingState;
        }
    }
}