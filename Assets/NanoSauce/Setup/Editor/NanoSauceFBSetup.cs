using System;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEditor;
using UnityEditor.Build;

namespace com.vhndev.nanosauce.setup.editor
{
    internal static class NanoSauceFBSetup
    {
        public static void ApplyFromData(NanoSauceSetupData data)
        {
            CheckExeptions(data);
            
            Facebook.Unity.Settings.FacebookSettings.AppIds = new List<string>()
            {
                data.fbAppId
            };
            
            EditorUtility.SetDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            AssetDatabase.SaveAssetIfDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            Facebook.Unity.Editor.ManifestMod.GenerateManifest();
        }

        private static void CheckExeptions(NanoSauceSetupData data)
        {
            if (string.IsNullOrEmpty(data.fbAppId))
                throw new Exception("NanoSauce: No FB AppID specified...");
            
            if (data.fbAppId.Contains(" "))
                throw new Exception("NanoSauce: Withespace detected at FB AppID...");
        }

        public static void CheckBuildExceptions()
        {
            var data = NanoSauceSetup.GetData;
            
            if (string.IsNullOrEmpty(data.fbAppId))
                throw new BuildFailedException("NanoSauce: No FB AppID specified...");
            
            if (data.fbAppId.Contains(" "))
                throw new BuildFailedException("NanoSauce: Withespace detected at FB AppID...");
        }
    }
}