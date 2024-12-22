#if UNITY_ANDROID
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models
{
    internal sealed class SafeAreaDataAndroid : SafeAreaDataBase
    {
        public SafeAreaDataAndroid()
        {
            OffsetTop = 0;
            OffsetBottom = 0;
            OffsetLeft = 0;
            OffsetRight = 0;

            try
            {
                using var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                var androidWindow = currentActivity?.Call<AndroidJavaObject>("getWindow");
                var currentFocus = androidWindow?.Call<AndroidJavaObject>("getCurrentFocus");
                var windowsInsets = currentFocus?.Call<AndroidJavaObject>("getRootWindowInsets");
                var displayCutout = windowsInsets?.Call<AndroidJavaObject>("getDisplayCutout");
                
                if (displayCutout == null)
                {
                    return;
                }

                OffsetTop = displayCutout.Call<int>("getSafeInsetTop");
                OffsetBottom = displayCutout.Call<int>("getSafeInsetBottom");
                OffsetLeft = displayCutout.Call<int>("getSafeInsetLeft");
                OffsetRight = displayCutout.Call<int>("getSafeInsetRight");
            }
            catch
            {
                // ignored
            }
        }
    }
}
#endif