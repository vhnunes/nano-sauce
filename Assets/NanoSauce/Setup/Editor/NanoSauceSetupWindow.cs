using UnityEditor;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    public class NanoSauceSetupWindow : EditorWindow
    {
        private NanoSauceSetupData data = null;
        private int cohortSize = 0;
        
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
            
            DrawABSettings();
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

        private void DrawABSettings()
        {
            EditorGUILayout.HelpBox("A/B Test", MessageType.None);
            if (cohortSize == 0) EditorGUILayout.HelpBox("Create cohorts to enable A/B tests.", MessageType.None);
            EditorGUILayout.HelpBox("You cannot have more than 20 cohorts.", MessageType.Warning);
            
            cohortSize = EditorGUILayout.IntField("Cohorts", cohortSize);
            if (cohortSize > 20)
                cohortSize = 20;
            
            if (data.gaCustomDimensions.Count > cohortSize)
                data.gaCustomDimensions.RemoveRange(cohortSize, data.gaCustomDimensions.Count-cohortSize);
            
            for (int i = 0; i < cohortSize; i++)
            {
                if (data.gaCustomDimensions.Count <= i)
                    data.gaCustomDimensions.Add("New ID");
                
                data.gaCustomDimensions[i] = EditorGUILayout.TextField("Cohort ID",data.gaCustomDimensions[i]);
            }
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
            data = NanoSauceSetupData.GetData;
            cohortSize = data.gaCustomDimensions.Count;
        }
    }
}