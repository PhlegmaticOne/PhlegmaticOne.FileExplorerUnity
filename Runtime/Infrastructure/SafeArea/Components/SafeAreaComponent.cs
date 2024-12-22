using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Components
{
    internal abstract class SafeAreaComponent : MonoBehaviour
    {
        private void OnEnable()
        {
            ApplySafeArea(SafeArea.GetData());
        }

        protected abstract void ApplySafeArea(ISafeAreaData safeAreaData);
    }
}