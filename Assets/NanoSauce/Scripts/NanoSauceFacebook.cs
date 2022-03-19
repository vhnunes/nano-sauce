using Facebook.Unity;
using UnityEngine;

namespace com.vhndev.nanosauce
{
    internal class NanoSauceFacebook
    {
        internal void Initialize()
        {
            if (!FB.IsInitialized) 
                FB.Init(InitCallback);
            
            else
                FB.ActivateApp();
        }

        private void InitCallback()
        {
            if (FB.IsInitialized)
                FB.ActivateApp();
            
            else
                Debug.LogError("Failed to Initialize the Facebook SDK");
        }
    }
}