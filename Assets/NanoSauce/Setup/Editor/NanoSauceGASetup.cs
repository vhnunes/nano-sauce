using System;
using GameAnalyticsSDK;
using UnityEngine;

namespace com.vhndev.nanosauce.setup.editor
{
    internal static class NanoSauceGASetup
    {
        public static void ApplyFromData(NanoSauceSetupData data)
        {
            GameAnalytics.SettingsGA.Platforms.Clear();
            
            GameAnalytics.SettingsGA.AddPlatform(RuntimePlatform.Android);
            GameAnalytics.SettingsGA.UpdateGameKey(0, data.gaAndroidGameKey);
            GameAnalytics.SettingsGA.UpdateSecretKey(0, data.gaAndroidSecretKey);

            GameAnalytics.SettingsGA.AddPlatform(RuntimePlatform.IPhonePlayer);
            GameAnalytics.SettingsGA.UpdateGameKey(1, data.gaIosGameKey);
            GameAnalytics.SettingsGA.UpdateSecretKey(1, data.gaIosSecretKey);
            
            CheckExeptions(data);
        }
        
        private static void CheckExeptions(NanoSauceSetupData data)
        {
            #if UNITY_ANDROID
            
            if (data.gaAndroidGameKey == "" || data.gaAndroidSecretKey == "")
                throw new Exception("NanoSauce: No GA Android Game Key or Secret Key...");
            
            if (data.gaAndroidGameKey.Contains(" ") || data.gaAndroidSecretKey.Contains(" "))
                throw new Exception("NanoSauce: Whitespace detected at GA Android Game Key or Secret Key...");
            
            
            if (!GameAnalytics.SettingsGA.IsGameKeyValid(0, data.gaAndroidGameKey))
                throw new Exception("NanoSauce: Invalid GA Android Game Key...");
            
            if (!GameAnalytics.SettingsGA.IsSecretKeyValid(0, data.gaAndroidSecretKey))
                throw new Exception("NanoSauce: Invalid GA Android Secret Key...");
            
            #endif
            
            #if UNITY_IOS
            
            if (data.gaIosGameKey == "" || data.gaIosSecretKey == "")
                throw new Exception("NanoSauce: No GA iOS Game Key or Secret Key...");
            
            if (data.gaIosGameKey.Contains(" ") || data.gaIosSecretKey.Contains(" "))
                throw new Exception("NanoSauce: Whitespace detected at GA iOS Game Key or Secret Key...");
            
            if (!GameAnalytics.SettingsGA.IsGameKeyValid(1, data.gaIosGameKey))
                throw new Exception("NanoSauce: Invalid GA iOS Game Key...");
            
            if (!GameAnalytics.SettingsGA.IsSecretKeyValid(1, data.gaIosGameKey))
                throw new Exception("NanoSauce: Invalid GA iOS Secret Key...");
            
            #endif
        }
    }
}