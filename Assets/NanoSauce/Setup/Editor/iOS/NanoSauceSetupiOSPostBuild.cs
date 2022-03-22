using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace com.vhndev.nanosauce.setup.editor.ios
{
    internal static class NanoSauceSetupiOSPostBuild
    {
        [PostProcessBuild]
        public static void FixCodePlist(BuildTarget buildTarget, string pathToBuiltProject)
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
        
        [PostProcessBuild]
        public static void FixXcodeBitcode(BuildTarget buildTarget, string path)
        {
            if (buildTarget != BuildTarget.iOS) return;
            
            #if UNITY_IOS
            
            string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
           
            UnityEditor.iOS.Xcode.PBXProject proj = new UnityEditor.iOS.Xcode.PBXProject();
            proj.ReadFromString(File.ReadAllText(projPath));
           
            string target = proj.TargetGuidByName("Unity-iPhone");
           
            proj.SetBuildProperty(target, "ENABLE_BITCODE", "false");
           
            File.WriteAllText(projPath, proj.WriteToString());
            
            #endif
        }
    }
}

