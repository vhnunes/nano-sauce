using UnityEditor;
using UnityEditor.Callbacks;

namespace com.vhndev.nanosauce.setup.editor.ios
{
    internal static class NanoSauceSetupiOSPostBuild
    {
        [PostProcessBuild]
        public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
        {
            if (buildTarget != BuildTarget.iOS) return;
            
            #if UNITY_IOS
            string plistPath = pathToBuiltProject + "/Info.plist";
            UnityEditor.iOS.Xcode.PlistDocument plist = new UnityEditor.iOS.Xcode.PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
                
            UnityEditor.iOS.Xcode.PlistElementDict rootDict = plist.root;
                
            var buildKey = "NSUserTrackingUsageDescription";
            rootDict.CreateArray (buildKey).AddString (
                "We need you data in order to improve our app in the next updates.");
                
            File.WriteAllText(plistPath, plist.WriteToString());
            #endif
        }
    }
}

