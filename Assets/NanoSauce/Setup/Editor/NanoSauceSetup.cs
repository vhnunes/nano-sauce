using UnityEditor;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    public static class NanoSauceSetup
    {
        public static void ApplySetup()
        {
            var data = NanoSauceSetupData.GetData;
            NanoSauceFBSetup.ApplyFromData(data);
            NanoSauceGASetup.ApplyFromData(data);
            
            EditorUtility.DisplayDialog("Sucess", "Settings changed", "OK");
        }
    }
}