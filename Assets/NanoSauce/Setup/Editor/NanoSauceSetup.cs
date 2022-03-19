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
            NanoSauceFBSetup.ApplyFromData(data);
            NanoSauceGASetup.ApplyFromData(data);
            
            EditorUtility.DisplayDialog("Sucess", "Settings changed", "OK");
        }
    }
}