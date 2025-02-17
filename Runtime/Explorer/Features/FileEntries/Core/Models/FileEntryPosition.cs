﻿using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models
{
    internal sealed class FileEntryPosition
    {
        public FileEntryPosition() { }
        public FileEntryPosition(Vector2 centerAnchoredPosition, Vector2 size, float offsetTop)
        {
            CenterAnchoredPosition = centerAnchoredPosition;
            Size = size;
            OffsetTop = offsetTop;
        }

        public Vector2 CenterAnchoredPosition { get; private set; }
        public Vector2 Size { get; private set; }
        public float OffsetTop { get; private set; }
        
        public void Update(Vector2 centerPosition, Vector2 size, float offsetTop)
        {
            Size = size;
            CenterAnchoredPosition = centerPosition;
            OffsetTop = offsetTop;
        }

        public ActionViewPositionData ToActionViewPositionData(ActionViewAlignment alignment)
        {
            return new ActionViewPositionData(CenterAnchoredPosition, Size, OffsetTop, alignment);
        }
    }
}