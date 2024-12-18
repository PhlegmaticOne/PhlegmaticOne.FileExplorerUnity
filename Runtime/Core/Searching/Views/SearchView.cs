using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Searching.Views
{
    internal sealed class SearchView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _searchInput;
        [SerializeField] private Button _resetButton;
        
        private SearchViewModel _viewModel;

        public void Bind(SearchViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void Subscribe()
        {
            _viewModel.SearchText.ValueChanged += UpdateSearchInput;
            _searchInput.onValueChanged.AddListener(SearchFileEntries);
            _resetButton.onClick.AddListener(ResetSearch);
        }

        private void SearchFileEntries(string searchText)
        {
            _viewModel.Search(searchText);
        }

        private void ResetSearch()
        {
            _viewModel.Reset();
        }

        private void UpdateSearchInput(string searchText)
        {
            _searchInput.SetTextWithoutNotify(searchText);
        }
    }
}