using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities
{
    internal sealed class ComponentSelectionDescription : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        
        private ReactiveProperty<FileEntriesCounter> _property;

        public void Bind(ReactiveProperty<FileEntriesCounter> property)
        {
            _property = property;
            _property.ValueChanged += UpdateDescription;
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateDescription;
            _property = null;
        }

        private void UpdateDescription(FileEntriesCounter counter)
        {
            var description = new SelectionHeaderViewDescription(counter.TotalCount);
            _descriptionText.text = description.GetDescription();
        }
    }
    
    internal readonly struct SelectionHeaderViewDescription
    {
        private readonly int _totalCount;

        public SelectionHeaderViewDescription(int totalCount)
        {
            _totalCount = totalCount;
        }

        public string GetDescription()
        {
            if (_totalCount == 0)
            {
                return "Select entries";
            }
            
            var entriesWord = _totalCount == 1 ? "entry" : "entries";
            return $"Selected: {_totalCount} {entriesWord}";
        }
    }
}