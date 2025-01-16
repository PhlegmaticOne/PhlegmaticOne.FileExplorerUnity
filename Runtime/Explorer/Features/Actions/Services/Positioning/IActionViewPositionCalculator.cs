using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal interface IActionViewPositionCalculator
    {
        Vector2 Calculate(ActionViewPositionData targetPosition, Vector2 viewSize);
    }
}