using UnityEditor;
using UnityEditor.Build;

namespace com.vhndev.nanosauce.setup.editor
{
    internal class NanoSauceSetupPreBuild : IPreprocessBuild
    {
        public int callbackOrder { get; }
        public void OnPreprocessBuild(BuildTarget target, string path)
        {
            CheckBuildExceptions();
        }

        private void CheckBuildExceptions()
        {
            NanoSauceFBSetup.CheckBuildExceptions();
            NanoSauceGASetup.CheckBuildExceptions();
        }
    }
}