using PhlegmaticOne.FileExplorer.Configuration;
using UnityEditor;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace PhlegmaticOne.FileExplorer.Editor.Configs
{
    [CustomEditor(typeof(ExplorerConfigScriptable))]
    internal sealed class ExplorerConfigEditor : UnityEditor.Editor
    {
        private ExplorerConfigScriptable _target;
        
        private void OnEnable()
        {
            _target = (ExplorerConfigScriptable)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawSelectFolderButtons();
        }

        private void DrawSelectFolderButtons()
        {
            var location = GetStartupLocation();
            
            if (GUILayout.Button("Select startup location"))
            {
                ApplyPathAndSave(EditorUtility.OpenFolderPanel("Select startup folder", location, ""));
            }

            if (GUILayout.Button("Reset location"))
            {
                ApplyPathAndSave(string.Empty);
            }
        }

        private void ApplyPathAndSave(string path)
        {
            _target.Value.StartupLocation = path;
            EditorUtility.SetDirty(_target);
            AssetDatabase.SaveAssetIfDirty(_target);
        }

        private string GetStartupLocation()
        {
            var startupLocation = _target.Value.StartupLocation;
            return string.IsNullOrEmpty(startupLocation) ? Application.persistentDataPath : startupLocation;
        }
    }
}