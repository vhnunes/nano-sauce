using GameAnalyticsSDK;
using UnityEngine;

namespace com.vhndev.nanosauce.analytics
{
    internal class NanoSauceGA : IGameAnalyticsATTListener 
    {
        internal void Initialize()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                GameAnalytics.RequestTrackingAuthorization(this);
            
            else
                GameAnalytics.Initialize();
        }

        #region IGameAnalyticsATTListener

        public void GameAnalyticsATTListenerNotDetermined()
        {
            throw new System.NotImplementedException();
        }

        public void GameAnalyticsATTListenerRestricted()
        {
            throw new System.NotImplementedException();
        }

        public void GameAnalyticsATTListenerDenied()
        {
            throw new System.NotImplementedException();
        }

        public void GameAnalyticsATTListenerAuthorized()
        {
            throw new System.NotImplementedException();
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

        #endregion
        
    }
}