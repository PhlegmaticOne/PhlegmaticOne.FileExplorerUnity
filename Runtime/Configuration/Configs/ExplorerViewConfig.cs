using System;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerViewConfig
    {
        [SerializeField, Range(1, 1000)] private int _addFileEntriesBatchCount;
        [SerializeField] private string _sortingLayerName;
        [SerializeField] private int _sortingOrder;
        [SerializeField] private TMP_FontAsset _fontAsset;

        public static ExplorerViewConfig Default(TMP_FontAsset fontAsset) => new()
        {
            _sortingLayerName = "Default",
            _sortingOrder = 999,
            _fontAsset = fontAsset,
            _addFileEntriesBatchCount = 10
        };

        public int AddFileEntriesBatchCount
        {
            get => _addFileEntriesBatchCount;
            set => _addFileEntriesBatchCount = value;
        }

        public string SortingLayerName
        {
            get => _sortingLayerName;
            set => _sortingLayerName = value;
        }

        public int SortingOrder
        {
            get => _sortingOrder;
            set => _sortingOrder = value;
        }

        public TMP_FontAsset FontAsset
        {
            get => _fontAsset;
            set => _fontAsset = value;
        }
    }
}