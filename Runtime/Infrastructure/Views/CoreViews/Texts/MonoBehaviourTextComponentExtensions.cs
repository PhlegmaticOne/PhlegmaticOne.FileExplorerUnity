using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal static class MonoBehaviourTextComponentExtensions
    {
        public static TextView[] TextsInChild(this MonoBehaviour behaviour)
        {
            return behaviour.GetComponentsInChildren<TextView>(true);
        }
    }
}