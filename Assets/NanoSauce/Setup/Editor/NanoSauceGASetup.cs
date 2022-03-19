using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    internal static class NanoSauceGASetup
    {
        public static void ApplyFromData(NanoSauceSetupData data)
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