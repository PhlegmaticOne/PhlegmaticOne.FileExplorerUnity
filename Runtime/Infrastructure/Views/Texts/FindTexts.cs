using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal static class FindTexts
    {
        public static TextComponent[] Find()
        {
            return Object.FindObjectsByType<TextComponent>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        }

        public static TextComponent[] TextsInChild(this MonoBehaviour behaviour)
        {
            return behaviour.GetComponentsInChildren<TextComponent>(true);
        }
    }
}