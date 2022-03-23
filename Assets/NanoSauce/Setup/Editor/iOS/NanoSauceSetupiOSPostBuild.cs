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
            // Fix iOS14+ requirements for tracking with fb sdk.
            
            if (buildTarget != BuildTarget.iOS) return;
            
            #if UNITY_IOS
            string plistPath = pathToBuiltProject + "/Info.plist";
            UnityEditor.iOS.Xcode.PlistDocument plist = new UnityEditor.iOS.Xcode.PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
                
            UnityEditor.iOS.Xcode.PlistElementDict rootDict = plist.root;
                
            var NSUserTrackingUsageDescriptionKey = "NSUserTrackingUsageDescription";
            rootDict.CreateDict(NSUserTrackingUsageDescriptionKey);
            rootDict.SetString(NSUserTrackingUsageDescriptionKey, "We need you data in order to improve our app in the next updates.");
            
            var LSApplicationQueriesSchemesKey = "LSApplicationQueriesSchemes";
            rootDict.CreateArray(LSApplicationQueriesSchemesKey).AddString (
                "fb-messenger-share-api");

            File.WriteAllText(plistPath, plist.WriteToString());
            #endif
        }
        
        [PostProcessBuild(100)]
        public static void FixXcodeBitcode(BuildTarget buildTarget, string path)
        {
            // Fix xcode (12.5) compile error using fb sdk 11+ 
            
            if (buildTarget != BuildTarget.iOS) return;
            
            #if UNITY_IOS
            string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
           
            UnityEditor.iOS.Xcode.PBXProject proj = new UnityEditor.iOS.Xcode.PBXProject();
            proj.ReadFromFile(projPath);

            proj.SetBuildProperty(proj.ProjectGuid(), "ENABLE_BITCODE", "false");
            proj.SetBuildProperty(proj.ProjectGuid(),"ARCHS", "arm64");
           
            File.WriteAllText(projPath, proj.WriteToString());
            
            #endif
        }
    }
}

