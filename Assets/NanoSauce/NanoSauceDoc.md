# nano-sauce
### A simple Facebook and Game Analytics integration.

## Supported Platforms
Should work on devices using Android 5.1+ or iOS 14.5-. <br>
Not tested on **iOS 14.5+** devices or using **Xcode 13**. I was limited to build on Xcode 12.5 up to iOS 14.5.

## Requirements
**Unity**<br>
Unity 2020.3 (recommended)<br>
Unity 2019.4+

**iOS Build**
1. Xcode 12.5 (recommended)
2. Cocoapods

**Android Build**
1. Unity with a working Android build support. (see unity versions on requirements)

## Before Install
The nano sauce has inside himself some 3rd party sdk`s and plugins, you cannot have them on your current project. If you have any of them, please remove from you project.
1. Facebook SDK
2. GameAnalytics SDK
3. ExternalDependencyManager

## Install and ID Setup

### Installation
1. Install the nano-sauce .unitypackage into your unity project.
2. After installation the **External Dependency Manager** should ask to enable Auto Resolution to resolve his libraries, accept and wait.

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
- Call **NanoSauceAnalytics.RegisterGameStart()** when the level start.
- Call **NanoSauceAnalytics.RegisterGameLose()** when the level is lost.
- Call **NanoSauceAnalytics.RegisterGameWin()** when the level is won.

### Custom Event
Track a custom event anywhere in your game by calling **NanoSauceAnalytics.RegisterCustomEvent()**. Can be useful for track goals inside the game or anything else.<br>
You should pass an **string** as argument and an **float** as optional event value.

### A/B Test
Nano-sauce A/B tests works using **GameAnalytics** custom dimension. <br>
You can make A/B tests using **cohorts** (see setup on top). Call **NanoSauceAnalytics.GetCurrentCohortID()** and you will be returned with the sorted cohort.
        
          string cohortID = NanoSauceAnalytics.GetCurrentCohortID();

          if (cohortID == "A")
            Player.StartWeak():

          else if (cohortID == "B")
            Player.StartStrong();

In **GameAnalytics** you can visualize the **cohort** of each player by his **custom_01** tracked by default on any event. It`s possible to use the **Dimensions > Custom 1** filter to visualize in a graph and compare data.

## Building

### Android
Before you start an Android Build make sure to Resolve the Android External Dependency Manager, you can do that by going into unity top menu **Assets > External Dependency Manager > Android > Android Resolver > Resolve**

### iOS
After the xcode project has been build up, **don`t open the .xcproject  extension file**, use the **.xcworkspace** extension file to open the **Xcode Project**.<br>
If **.xcworkspace** file does not exist, try running the terminal command ``pod install`` in the project folder.

## Know Issues
On MAC when applying **nano sauce settings** for the first time sometimes generate error`s related to **GameAnalyitcs** when they create his settings files. This can be solved by reopening the unity or deleting **Resources/GameAnalyitcs folder** and opening **Game Analytics** setup menu on **Window > Game Analytics > Select Settings** and click on **I want to fill my game keys manual**.