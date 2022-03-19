using UnityEditor;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    public class NanoSauceSetupWindow : EditorWindow
    {
        [MenuItem("NanoSauce/Settings")]
        private static void ShowWindow()
        {
            var window = GetWindow<NanoSauceSetupWindow>();
            window.titleContent = new GUIContent("NanoSauce Settings");
            window.Show();
        }

        private void OnGUI()
        {
            DrawFBSettings();
            GUILayout.Space(20);
            
            DrawGASettings();
            GUILayout.Space(20);
            
            DrawApplyButton();
        }

        private void DrawGASettings()
        {
            EditorGUILayout.HelpBox("Game Analytics", MessageType.None);
            EditorGUILayout.TextField("Android Game Key", "");
            EditorGUILayout.TextField("Android Secret Key", "");
            GUILayout.Space(10);
            EditorGUILayout.TextField("iOS Game Key", "");
            EditorGUILayout.TextField("iOS Secret Key","");
        }
        
        private void DrawFBSettings()
        {
            EditorGUILayout.HelpBox("Facebook", MessageType.None);
            EditorGUILayout.TextField("App ID", "");
        }

        private void DrawApplyButton()
        {
            if (GUILayout.Button("Apply"))
                throw new System.NotImplementedException();
        }
    }
}