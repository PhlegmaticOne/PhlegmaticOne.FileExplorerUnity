#if UNITY_ANDROID
using System.Linq;
using JetBrains.Annotations;
using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine.Android;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps
{
    [UsedImplicitly]
    internal sealed class ExplorerShowStepRequestAndroidPermissions : IExplorerShowStep
    {
        private readonly ExplorerConfig _config;

        public ExplorerShowStepRequestAndroidPermissions(
            ExplorerConfig config)
        {
            _config = config;
        }
        
        public void ProcessShow()
        {
            var requiredPermissions = _config.PermissionsConfig.GetRequiredPermissions();
            
            var requestPermissions = requiredPermissions
                .Where(x => !Permission.HasUserAuthorizedPermission(x))
                .ToArray();
            
            Permission.RequestUserPermissions(requestPermissions);
        }
    }
}
#endif