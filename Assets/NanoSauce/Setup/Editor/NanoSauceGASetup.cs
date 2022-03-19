using System;
using GameAnalyticsSDK;
using UnityEditor.Build;
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
            
            if (string.IsNullOrEmpty(data.gaAndroidGameKey) || string.IsNullOrEmpty(data.gaAndroidSecretKey))
                throw new Exception("NanoSauce: No GA Android Game Key or Secret Key...");
            
            if (data.gaAndroidGameKey.Contains(" ") || data.gaAndroidSecretKey.Contains(" "))
                throw new Exception("NanoSauce: Whitespace detected at GA Android Game Key or Secret Key...");
            
            
            if (!GameAnalytics.SettingsGA.IsGameKeyValid(0, data.gaAndroidGameKey))
                throw new Exception("NanoSauce: Invalid GA Android Game Key...");
            
            if (!GameAnalytics.SettingsGA.IsSecretKeyValid(0, data.gaAndroidSecretKey))
                throw new Exception("NanoSauce: Invalid GA Android Secret Key...");
            
            #endif
            
            #if UNITY_IOS
            
            if (string.IsNullOrEmpty(data.gaIosGameKey) || string.IsNullOrEmpty(data.gaIosGameKey))
                throw new Exception("NanoSauce: No GA iOS Game Key or Secret Key...");
            
            if (data.gaIosGameKey.Contains(" ") || data.gaIosSecretKey.Contains(" "))
                throw new Exception("NanoSauce: Whitespace detected at GA iOS Game Key or Secret Key...");
            
            if (!GameAnalytics.SettingsGA.IsGameKeyValid(1, data.gaIosGameKey))
                throw new Exception("NanoSauce: Invalid GA iOS Game Key...");
            
            if (!GameAnalytics.SettingsGA.IsSecretKeyValid(1, data.gaIosGameKey))
                throw new Exception("NanoSauce: Invalid GA iOS Secret Key...");
            
            #endif
        }

        public static void CheckBuildExceptions()
        {
            var gaAndroidGameKey = GameAnalytics.SettingsGA.GetGameKey(0);
            var gaAndroidSecretKey = GameAnalytics.SettingsGA.GetSecretKey(0);

            var gaIosGameKey = GameAnalytics.SettingsGA.GetGameKey(1);
            var gaIosSecretKey = GameAnalytics.SettingsGA.GetSecretKey(1);
            
            #if UNITY_ANDROID

            if (string.IsNullOrEmpty(gaAndroidGameKey) || string.IsNullOrEmpty(gaAndroidSecretKey))
                throw new BuildFailedException("NanoSauce: No GA Android Game Key or Secret Key...");
            
            if (gaAndroidGameKey.Contains(" ") || gaAndroidSecretKey.Contains(" "))
                throw new BuildFailedException("NanoSauce: Whitespace detected at GA Android Game Key or Secret Key...");

            #endif
            
            #if UNITY_IOS
            
            if (string.IsNullOrEmpty(gaIosGameKey) || string.IsNullOrEmpty(gaIosSecretKey))
                throw new BuildFailedException("NanoSauce: No GA iOS Game Key or Secret Key...");
            
            if (gaIosGameKey.Contains(" ") || gaIosSecretKey.Contains(" "))
                throw new BuildFailedException("NanoSauce: Whitespace detected at GA iOS Game Key or Secret Key...");

            #endif
        }
    }
}