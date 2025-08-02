using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal static class MonoBehaviourTextFontSetterExtensions
    {
        public static TextFontSetter[] TextsInChild(this MonoBehaviour behaviour)
        {
            return behaviour.GetComponentsInChildren<TextFontSetter>(true);
        }
    }
}