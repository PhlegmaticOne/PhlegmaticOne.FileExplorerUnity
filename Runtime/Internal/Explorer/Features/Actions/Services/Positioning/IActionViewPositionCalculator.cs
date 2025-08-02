using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal interface IActionViewPositionCalculator
    {
        Vector2 Calculate(ActionDropdownViewPosition targetPosition, Vector2 viewSize);
    }
}