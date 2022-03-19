using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace com.vhndev.nanosauce.setup.editor
{
    internal class NanoSauceSetupPreBuild : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }
        public void OnPreprocessBuild(BuildReport report)
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