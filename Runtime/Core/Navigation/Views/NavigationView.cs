using System.Collections.Specialized;
using System.Linq;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class NavigationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tabPathText;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _emptyDirectoryText;
        [SerializeField] private TabView _tabView;
        
        private NavigationViewModel _viewModel;

        public void Bind(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
            _backButton.onClick.AddListener(NavigateBack);
            _viewModel.FileEntries.CollectionChanged += HandleFileEntryCollectionChanged;
            _viewModel.NavigationStarted += ViewModelOnNavigationStarted;
            _viewModel.NavigationCompleted += ViewModelOnNavigationCompleted;
        }

        private void ViewModelOnNavigationStarted()
        {
            _tabPathText.text = _viewModel.Path;
            _backButton.interactable = false;
            _closeButton.interactable = false;
            _emptyDirectoryText.SetActive(false);
        }

        private void ViewModelOnNavigationCompleted()
        {
            _closeButton.interactable = true;
            _backButton.interactable = _viewModel.CanMoveBack();
            _emptyDirectoryText.SetActive(_viewModel.FileEntries.Count == 0);
        }

        private void NavigateBack()
        {
            _viewModel.NavigateBack();
        }

        private void HandleFileEntryCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _tabView.AddEntries(eventArgs.NewItems.OfType<FileEntryViewModel>());
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
    }
}