using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    [Serializable]
    internal sealed class ActionViewContainersData
    {
        [SerializeField] private RectTransform _scrollRect;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private float _addOffsetX;
        [SerializeField] private Vector2 _borderOffset;
        public RectTransform ScrollRect => _scrollRect;
        public RectTransform Parent => _parent;
        public float AddOffsetX => _addOffsetX;
        public Vector2 BorderOffset => _borderOffset;
    }
}