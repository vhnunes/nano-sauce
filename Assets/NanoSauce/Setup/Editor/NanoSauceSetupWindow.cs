using UnityEditor;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    public class NanoSauceSetupWindow : EditorWindow
    {
        private NanoSauceSetupData data = null;
        
        [MenuItem("NanoSauce/Settings")]
        private static void ShowWindow()
        {
            var window = GetWindow<NanoSauceSetupWindow>();
            window.titleContent = new GUIContent("NanoSauce Settings");
            window.Show();
            window.SyncData();
        }

        private void OnGUI()
        {
            DrawFBSettings();
            GUILayout.Space(20);
            
            DrawGASettings();
            GUILayout.Space(20);
            
            DrawApplyButton();
        }

        private void DrawFBSettings()
        {
            EditorGUILayout.HelpBox("Facebook", MessageType.None);
            data.fbAppId = EditorGUILayout.TextField("App ID", data.fbAppId);
        }
        
        private void DrawGASettings()
        {
            EditorGUILayout.HelpBox("Game Analytics", MessageType.None);
            data.gaAndroidGameKey = EditorGUILayout.TextField("Android Game Key", data.gaAndroidGameKey);
            data.gaAndroidSecretKey = EditorGUILayout.TextField("Android Secret Key", data.gaAndroidSecretKey);
            data.gaIosGameKey = EditorGUILayout.TextField("iOS Game Key", data.gaIosGameKey);
            data.gaIosSecretKey = EditorGUILayout.TextField("iOS Secret Key",data.gaIosSecretKey);
        }

        private void DrawApplyButton()
        {
            if (GUILayout.Button("Apply"))
            {
                EditorUtility.SetDirty(data);
                AssetDatabase.SaveAssetIfDirty(data);
                
                NanoSauceSetup.ApplySetup();
            }
                
        }

        private void SyncData()
        {
            data = NanoSauceSetup.GetData;
        }
    }
}