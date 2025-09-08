using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration.Configs.AndroidPermissions
{
    [Serializable]
    public sealed class ExplorerAndroidPermissionsConfig
    {
        [SerializeField] private AndroidMediaPermission _permissions;

        public IReadOnlyList<string> GetRequiredPermissions()
        {
            var result = new List<string>();

            foreach (var permission in GetAllPermissions())
            {
                if (permission != AndroidMediaPermission.None && _permissions.HasFlag(permission))
                {
                    result.Add(GetPermissionString(permission));
                }
            }

            return result;
        }

        private static AndroidMediaPermission[] GetAllPermissions()
        {
            return (AndroidMediaPermission[])Enum.GetValues(typeof(AndroidMediaPermission));
        }
        
        private static string GetPermissionString(AndroidMediaPermission permission)
        {
            return permission switch
            {
                AndroidMediaPermission.Images => "android.permission.READ_MEDIA_IMAGES",
                AndroidMediaPermission.Audio => "android.permission.READ_MEDIA_AUDIO",
                AndroidMediaPermission.Video => "android.permission.READ_MEDIA_VIDEO",
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }
    }
}