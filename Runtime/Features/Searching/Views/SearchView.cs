using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Views
{
    internal sealed class SearchView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private TMP_InputField _searchInput;
        [SerializeField] private Button _resetButton;
        [SerializeField] private TextMeshProUGUI _searchCountText;
        
        private SearchViewModel _viewModel;

        [ViewInject]
        public void Construct(SearchViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.SearchText.ValueChanged += UpdateSearchInput;
            _viewModel.FoundEntriesCount.ValueChanged += UpdateFoundEntriesCount;
            _viewModel.IsActive.ValueChanged += UpdateIsActive;
            _searchInput.onValueChanged.AddListener(SearchFileEntries);
            _resetButton.onClick.AddListener(ResetSearch);
        }

        public void Unbind()
        {
            _viewModel.SearchText.ValueChanged -= UpdateSearchInput;
            _viewModel.FoundEntriesCount.ValueChanged -= UpdateFoundEntriesCount;
            _viewModel.IsActive.ValueChanged -= UpdateIsActive;
            _searchInput.onValueChanged.RemoveListener(SearchFileEntries);
            _resetButton.onClick.RemoveListener(ResetSearch);
        }

        private void UpdateIsActive(bool isActive)
        {
            _searchCountText.gameObject.SetActive(isActive);
        }

        private void UpdateFoundEntriesCount(int count)
        {
            if (count != -1)
            {
                _searchCountText.text = $"Found entries: {count}";
            }
        }

        private void SearchFileEntries(string searchText)
        {
            _viewModel.Search(searchText);
        }

        private void ResetSearch()
        {
            _viewModel.Clear();
        }

        private void UpdateSearchInput(string searchText)
        {
            _searchInput.SetTextWithoutNotify(searchText);
        }
    }
}