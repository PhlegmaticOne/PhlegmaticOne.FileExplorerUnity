using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal static class MonoBehaviourTextComponentExtensions
    {
        public static TextComponent[] TextsInChild(this MonoBehaviour behaviour)
        {
            return behaviour.GetComponentsInChildren<TextComponent>(true);
        }
    }
}