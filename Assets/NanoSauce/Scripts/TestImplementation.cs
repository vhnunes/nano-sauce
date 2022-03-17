using System;
using System.Collections;
using GameAnalyticsSDK;
using UnityEngine;

namespace com.vhndev.nanosauce
{
    public class TestImplementation : MonoBehaviour, IGameAnalyticsATTListener 
    {
        private void Start()
        {
            InitializeGA();
        }

        private void InitializeGA()
        {
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GameAnalytics.RequestTrackingAuthorization(this);
            }
            else
            {
                GameAnalytics.Initialize();
            }
        }

        #region IGameAnalyticsAttListener Methods

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

        public void RegisterLevelStart()
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level_000");
        }

        public void RegisterLevelEnd()
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level_000");
        }
    }
}

