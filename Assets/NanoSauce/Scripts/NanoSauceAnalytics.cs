using UnityEngine;

namespace com.vhndev.nanosauce
{
    public static class NanoSauceAnalytics
    {
        private static NanoSauceFacebook nanoFB;
        private static NanoSauceGameAnalytics nanoGA;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            nanoGA = new NanoSauceGameAnalytics();
            nanoFB = new NanoSauceFacebook();
            
            nanoGA.Initialize();
            nanoFB.Initialize();
        }

        /// <summary>
        /// Call when start the game level.
        /// </summary>
        public static void RegisterGameStart()
        {
            nanoGA.RegisterLevelStart("level_000");
        }

        /// <summary>
        /// Call when win the game level.
        /// </summary>
        public static void RegisterGameWin()
        {
            nanoGA.RegisterLevelEnd("level_000");
        }

        /// <summary>
        /// Call when lost the game level.
        /// </summary>
        public static void RegisterGameLose()
        {
            nanoGA.RegisterLevelLose("level_000");
        }
    }
}