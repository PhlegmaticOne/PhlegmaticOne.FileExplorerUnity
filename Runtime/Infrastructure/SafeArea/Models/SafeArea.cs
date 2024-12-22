using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea
{
    internal sealed class SafeArea
    {
        private static readonly ISafeAreaData SafeAreaData = CreateSafeAreaData();

        public static void Initialize(float width, float height)
        {
            SafeAreaData.ChangeRatio(width / Screen.width, height / Screen.height);
        }

        public static ISafeAreaData GetData()
        {
            return SafeAreaData;
        }

        private static ISafeAreaData CreateSafeAreaData()
        {
#if UNITY_EDITOR || UNITY_IOS
            return new SafeAreaDataSimple();
#elif UNITY_ANDROID
            return new SafeAreaDataAndroid();
#endif
        }

    }
}