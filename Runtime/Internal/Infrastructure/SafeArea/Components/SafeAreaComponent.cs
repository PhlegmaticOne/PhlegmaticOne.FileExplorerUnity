using PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Components
{
    internal abstract class SafeAreaComponent : MonoBehaviour
    {
        private void OnEnable()
        {
            ApplySafeArea(Models.SafeArea.GetData());
        }

        protected abstract void ApplySafeArea(ISafeAreaData safeAreaData);
    }
}