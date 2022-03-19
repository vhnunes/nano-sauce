using System.Collections.Generic;
using UnityEditor;

namespace com.vhndev.nanosauce.setup.editor
{
    internal static class NanoSauceFBSetup
    {
        public static void ApplyFromData(NanoSauceSetupData data)
        {
            Facebook.Unity.Settings.FacebookSettings.AppIds = new List<string>()
            {
                data.fbAppId
            };
            
            EditorUtility.SetDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            AssetDatabase.SaveAssetIfDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            Facebook.Unity.Editor.ManifestMod.GenerateManifest();
        }
    }
}