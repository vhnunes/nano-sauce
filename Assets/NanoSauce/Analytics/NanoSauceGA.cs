using System.Collections.Generic;
using com.vhndev.nanosauce.setup;
using GameAnalyticsSDK;
using UnityEngine;

namespace com.vhndev.nanosauce.analytics
{
    internal class NanoSauceGA : IGameAnalyticsATTListener
    {

        private string CUSTOM_DIMENSION_SAVE_KEY = "CUSTOM_DIMENSION";
        private string currentCustomDimension;
        private delegate void OnGAInitialize();
        private OnGAInitialize onGAInitialize;
        
        public string GetCustomDimension => currentCustomDimension;
        
        internal void Initialize()
        {
            onGAInitialize += GameAnalytics.Initialize;
            onGAInitialize += SetOrLoadCustomDimension;

            if (Application.platform == RuntimePlatform.IPhonePlayer)
                GameAnalytics.RequestTrackingAuthorization(this);
            
            else
                onGAInitialize?.Invoke();
        }

        #region IGameAnalyticsATTListener

        public void GameAnalyticsATTListenerNotDetermined()
        {
            onGAInitialize?.Invoke();
        }

        public void GameAnalyticsATTListenerRestricted()
        {
            onGAInitialize?.Invoke();
        }

        public void GameAnalyticsATTListenerDenied()
        {
            onGAInitialize?.Invoke();
        }

        public void GameAnalyticsATTListenerAuthorized()
        {
            onGAInitialize?.Invoke();
        }

        #endregion

        #region Progression Methods

        internal void RegisterLevelStart(string levelString)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, levelString);
        }

        internal void RegisterLevelEnd(string levelString)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, levelString);
        }

        internal void RegisterLevelLose(string levelString)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, levelString);
        }
        
        internal void RegisterDesignEvent(string eventString, float eventFloatValue = float.NaN)
        {
            if (float.IsNaN(eventFloatValue))
                GameAnalytics.NewDesignEvent(eventString);
            
            else
                GameAnalytics.NewDesignEvent(eventString, eventFloatValue);
        }

        #endregion

        #region Custom Dimension

        private void LoadLastCustomDimension()
        {
            if (PlayerPrefs.HasKey(CUSTOM_DIMENSION_SAVE_KEY))
                currentCustomDimension = PlayerPrefs.GetString(CUSTOM_DIMENSION_SAVE_KEY);
        }

        private void SaveCustomDimension()
        {
            PlayerPrefs.SetString(CUSTOM_DIMENSION_SAVE_KEY, currentCustomDimension);
        }

        private void SetOrLoadCustomDimension()
        {
            LoadLastCustomDimension();
            
            if (string.IsNullOrEmpty(currentCustomDimension))
                SetRandomCustomDimension();
        }
        
        private void SetRandomCustomDimension()
        {
            var data = NanoSauceSetupData.GetData;
            if (data == null) 
                return;
            
            if (data.gaCustomDimensions.Count == 0)
                return;
            
            currentCustomDimension = data.gaCustomDimensions[Random.Range(0, data.gaCustomDimensions.Count)];
            SaveCustomDimension();
            GameAnalytics.SetCustomDimension01(currentCustomDimension);
        }

        #endregion

    }
}