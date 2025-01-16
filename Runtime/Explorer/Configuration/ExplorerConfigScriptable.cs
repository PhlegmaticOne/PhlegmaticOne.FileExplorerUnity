using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [CreateAssetMenu(menuName = "Explorer/Create config", fileName = "ExplorerConfig")]
    public sealed class ExplorerConfigScriptable : ScriptableObject, IExplorerConfig
    {
        [SerializeField] private ExplorerConfig _value = ExplorerConfig.Create(null);
        
        public ExplorerConfig Value => _value;
    }
}