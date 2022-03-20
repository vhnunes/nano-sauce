using com.vhndev.nanosauce.analytics;
using UnityEngine;
using UnityEngine.UI;

namespace HyperFactory
{
    public class TestImplementation : MonoBehaviour
    {
        #region Variables / Components

        [SerializeField] private Text text;
        
        #endregion

        #region Events
        
        
        
        #endregion
    
        #region Monobehaviour

        private void Start()
        {
            TestAB();
        }

        #endregion

        #region Methods

        public void TestAB()
        {
            text.text = NanoSauceAnalytics.GetCurrentCohortID();
        }
        
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

