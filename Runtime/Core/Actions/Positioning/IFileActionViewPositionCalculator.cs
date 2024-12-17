using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal interface IFileActionViewPositionCalculator
    {
        Vector2 Calculate(FileActionViewPositionData targetPosition, Vector2 viewSize);
    }
}