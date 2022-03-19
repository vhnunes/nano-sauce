using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    public static class NanoSauceSetup
    {
        public static NanoSauceSetupData GetData
        {
            get
            {
                var dataAsset = (NanoSauceSetupData) Resources.Load("NanoSauce/NanoSauceData");
                if (dataAsset == null)
                    CreateNewDataAsset();
                
                dataAsset = (NanoSauceSetupData) Resources.Load("NanoSauce/NanoSauceData");
                
                return dataAsset;
            }
        }
        
        private static void CreateNewDataAsset()
        {
            var newData = ScriptableObject.CreateInstance<NanoSauceSetupData>();

            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                AssetDatabase.CreateFolder("Assets", "Resources");
            
            if (!AssetDatabase.IsValidFolder("Assets/Resources/NanoSauce"))
                AssetDatabase.CreateFolder("Assets/Resources", "NanoSauce");
            
            AssetDatabase.CreateAsset(newData, "Assets/Resources/NanoSauce/NanoSauceData.asset");
            AssetDatabase.SaveAssets();
        }

        public static void ApplySetup()
        {
            var data = GetData;
            ApplyFB(data);
            ApplyGA(data);
            
            EditorUtility.DisplayDialog("Sucess", "Settings changed", "OK");
        }

        private static void ApplyFB(NanoSauceSetupData data)
        {
            Facebook.Unity.Settings.FacebookSettings.AppIds = new List<string>()
            {
                data.fbAppId
            };
            
            EditorUtility.SetDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            AssetDatabase.SaveAssetIfDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            Facebook.Unity.Editor.ManifestMod.GenerateManifest();
        }

        private static void ApplyGA(NanoSauceSetupData data)
        {
            GameAnalyticsSDK.GameAnalytics.SettingsGA.Platforms.Clear();
            
            GameAnalyticsSDK.GameAnalytics.SettingsGA.AddPlatform(RuntimePlatform.Android);
            GameAnalyticsSDK.GameAnalytics.SettingsGA.UpdateGameKey(0, data.gaAndroidGameKey);
            GameAnalyticsSDK.GameAnalytics.SettingsGA.UpdateSecretKey(0, data.gaAndroidSecretKey);

            GameAnalyticsSDK.GameAnalytics.SettingsGA.AddPlatform(RuntimePlatform.IPhonePlayer);
            GameAnalyticsSDK.GameAnalytics.SettingsGA.UpdateGameKey(1, data.gaIosGameKey);
            GameAnalyticsSDK.GameAnalytics.SettingsGA.UpdateSecretKey(1, data.gaIosSecretKey);
        }
    }
}