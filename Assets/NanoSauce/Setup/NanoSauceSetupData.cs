using System.Collections.Generic;
using UnityEngine;

namespace com.vhndev.nanosauce.setup
{
    [CreateAssetMenu(fileName = "NanoSauce Setup Data", menuName = "", order = 0)]
    public class NanoSauceSetupData : ScriptableObject
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
            #if UNITY_EDITOR
            
            var newData = ScriptableObject.CreateInstance<NanoSauceSetupData>();

            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Resources"))
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Resources");
            
            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Resources/NanoSauce"))
                UnityEditor.AssetDatabase.CreateFolder("Assets/Resources", "NanoSauce");
            
            UnityEditor.AssetDatabase.CreateAsset(newData, "Assets/Resources/NanoSauce/NanoSauceData.asset");
            UnityEditor.AssetDatabase.SaveAssets();
            #endif
        }
        
        public string fbAppId;
        public string gaAndroidGameKey;
        public string gaAndroidSecretKey;
        public string gaIosGameKey;
        public string gaIosSecretKey;

        public List<string> gaCustomDimensions = new List<string>();
    }
}