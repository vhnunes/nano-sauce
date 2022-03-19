using UnityEngine;

namespace com.vhndev.nanosauce.setup
{
    [CreateAssetMenu(fileName = "NanoSauce Setup Data", menuName = "", order = 0)]
    public class NanoSauceSetupData : ScriptableObject
    {
        // TODO: Hide in inspector...
        
        public string fbAppId;
        public string gaAndroidGameKey;
        public string gaAndroidSecretKey;
        public string gaIosGameKey;
        public string gaIosSecretKey;
    }
}