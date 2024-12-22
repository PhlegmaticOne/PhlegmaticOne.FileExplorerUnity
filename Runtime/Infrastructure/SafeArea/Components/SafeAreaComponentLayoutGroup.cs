using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Components
{
    internal sealed class SafeAreaComponentLayoutGroup : SafeAreaComponent
    {
        [SerializeField] private LayoutGroup _layoutGroup;
        [SerializeField] private float _additionalOffset = 5;
        
        protected override void ApplySafeArea(ISafeAreaData safeAreaData)
        {
            _layoutGroup.padding.top = (int)(safeAreaData.OffsetTop + _additionalOffset);
        }
    }
}