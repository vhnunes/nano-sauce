using com.vhndev.nanosauce.analytics;
using UnityEngine;

namespace HyperFactory
{
    public class TestImplementation : MonoBehaviour
    {
        #region Variables / Components
        
        
        
        #endregion

        #region Events
        
        
        
        #endregion
    
        #region Monobehaviour
        
        
        
        #endregion

        #region Methods

        public void GameStart()
        {
            NanoSauceAnalytics.RegisterGameStart();
        }
        
        public void GameWin()
        {
            NanoSauceAnalytics.RegisterGameWin();
        }

        public void GameLose()
        {
            NanoSauceAnalytics.RegisterGameLose();
        }
        
        #endregion
    }
}

