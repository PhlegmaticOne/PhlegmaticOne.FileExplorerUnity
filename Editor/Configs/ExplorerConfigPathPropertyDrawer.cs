using PhlegmaticOne.FileExplorer.Configuration;
using UnityEditor;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Editor.Configs
{
    [CustomEditor(typeof(ExplorerConfigScriptable))]
    internal sealed class ExplorerConfigPathPropertyDrawer : UnityEditor.Editor
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
                _target.Value.StartupLocation = EditorUtility.OpenFolderPanel("Select startup folder", location, "");
            }

            if (GUILayout.Button("Reset location"))
            {
                _target.Value.StartupLocation = string.Empty;
            }
        }

        private string GetStartupLocation()
        {
            var startupLocation = _target.Value.StartupLocation;
            return string.IsNullOrEmpty(startupLocation) ? Application.persistentDataPath : startupLocation;
        }
    }
}