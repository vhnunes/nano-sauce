# nano-sauce
A simple Facebook and Game Analytics integration for Unity on Android and iOS.

## Supported Platforms
Should work on devices using Android 5.1+ or iOS 14.5- <br>
Not tested on **iOS 14.5+** devices or using **Xcode 13**. I was limited to build on Xcode 12.5 up to iOS 14.5 (simulator).

## Requirements
**Unity**<br>
Unity 2020.3 (recommended)<br>
Unity 2019.4+<br>
~~Unity 2018.4 (not tested)~~

**iOS Build**
1. Xcode 12.5+ (recommended)
2. Cocoapods

**Android Build**
1. For Unity 2020.3+ there is no requirements other than Android Build support properly configured.
2. For version **below** 2020.3 you will need to export the project and build using **Android Studio**.

## Before Install
The nano sauce has inside himself some 3rd party sdk`s and plugins, you cannot have them on your current project. If you have any of them, please remove from you project.
1. Facebook SDK
2. GameAnalytics
3. ExternalDependencyManager

## Install and ID Setup

### Installation
1. Install the nano-sauce .unitypackage into your unity project.
2. After installation the **External Dependency Manager** should ask to enable Auto Resolution to resolve his libraries (or will start to auto resolve), accept and wait.

### FB and GA Setup
Go to **NanoSauce > Settings** in the Unity top menu.
1. Fill App ID in Facebook section with your facebook application id.
2. Fill in Game Analytics Section the **Game Key** and **Secret Key** for the desired (or both) platform.
3. Hit Apply.

### A/B Test Setup
Go to **NanoSauce > Settings** in the Unity top menu.
1. Change the **Cohorts** value for the amount of A/B test cohorts that you want.
2. You should see a list of **Cohort ID**, fill each one with a different ID to identify the desired cohort.
3. Hit Apply.

## Integration
You don`t need to initialize anything, just call the desired methods in your game.

### Level Progression
You can track the progression of the player using some provided methods.

          using com.vhndev.nanosauce.analytics;

- Call **NanoSauceAnalytics.RegisterGameStart()** when the level start.
- Call **NanoSauceAnalytics.RegisterGameLose()** when the level is lost.
- Call **NanoSauceAnalytics.RegisterGameWin()** when the level is won.

### Custom Event
Track a custom event anywhere in your game by calling **NanoSauceAnalytics.RegisterCustomEvent()**. Can be useful for tracking goals inside the game or anything else.<br>
You should pass an **string** as argument and an **float** as optional event value.

### A/B Test
Nano-sauce A/B tests works using **GameAnalytics** custom dimension. <br>
You can make A/B tests using **cohorts** (see setup on top). Call **NanoSauceAnalytics.GetCurrentCohortID()** and you will be returned with the sorted cohort.
        
          using com.vhndev.nanosauce.analytics;
          ...

          string cohortID = NanoSauceAnalytics.GetCurrentCohortID();

          if (cohortID == "A")
            Player.StartWeak():

          else if (cohortID == "B")
            Player.StartStrong();

In **GameAnalytics** you can visualize the **cohort** of each player by his **custom_01** tracked by default on any event. It`s possible to use the **Dimensions > Custom 1** filter to visualize in a graph and compare data.

### Sample
You can found an complete sample implementation at folder **NanoSauce/Sample** that includes a scene and code.

## Building

### Android
Before you start an Android Build make sure to Resolve the Android External Dependency Manager, you can do that by going into unity top menu **Assets > External Dependency Manager > Android > Android Resolver > Resolve**

In **Unity 2020.3+** you just need to build using Unity. For **versions below** you need to **Export Project** open it on **Android Studio** update the **gradle plugin when asked** and build here.<br>
~~Thanks **Facebook SDK 11**~~

### iOS
After the xcode project has been build up, **don`t open the .xcproject  extension file**, use the **.xcworkspace** extension file to open the **Xcode Project**.<br>
If **.xcworkspace** file does not exist, try running the terminal command ``pod install`` in the project folder.
