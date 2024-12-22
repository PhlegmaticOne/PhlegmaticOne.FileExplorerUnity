using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal interface IActionViewPositionCalculator
    {
        Vector2 Calculate(ActionViewPositionData targetPosition, Vector2 viewSize);
    }
}