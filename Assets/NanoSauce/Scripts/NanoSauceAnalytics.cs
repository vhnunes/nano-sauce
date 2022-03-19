using UnityEngine;

namespace com.vhndev.nanosauce
{
    public static class NanoSauceAnalytics
    {
        private static NanoSauceFB nanoFB;
        private static NanoSauceGA nanoGA;

        private static int currentLevelRegistered = 1;
        private const string LEVEL_REGISTER_KEY = "LEVEL_PROGRESS";

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            nanoGA = new NanoSauceGA();
            nanoFB = new NanoSauceFB();
            
            nanoGA.Initialize();
            nanoFB.Initialize();
            
            LoadLevelProgress();
        }

        #region Game Progress Register

        /// <summary>
        /// Call when start the game level.
        /// </summary>
        public static void RegisterGameStart()
        {
            nanoGA.RegisterLevelStart(GetCurrentLevelString());
        }

        /// <summary>
        /// Call when win the game level.
        /// </summary>
        public static void RegisterGameWin()
        {
            nanoGA.RegisterLevelEnd(GetCurrentLevelString());
            CompleteLevelProgress();
        }

        /// <summary>
        /// Call when lost the game level.
        /// </summary>
        public static void RegisterGameLose()
        {
            nanoGA.RegisterLevelLose(GetCurrentLevelString());
        }

        #endregion

        #region Level Progress Automation

        private static void LoadLevelProgress()
        {
            if (PlayerPrefs.HasKey(LEVEL_REGISTER_KEY))
                currentLevelRegistered = PlayerPrefs.GetInt(LEVEL_REGISTER_KEY);
        }

        private static void SaveLevelProgress()
        {
            PlayerPrefs.SetInt(LEVEL_REGISTER_KEY, currentLevelRegistered);
        }
        
        private static void CompleteLevelProgress()
        {
            currentLevelRegistered++;
            SaveLevelProgress();
        }
        
        private static string GetCurrentLevelString()
        {
            return "level_" + currentLevelRegistered.ToString("000");
        }

        #endregion

    }
}