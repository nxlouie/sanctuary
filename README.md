# sanctuary
EECS 441 Project Team JEANJA - Unity

How to collaborate with git and Unity:
https://stackoverflow.com/questions/21573405/how-to-prepare-a-unity-project-for-git

Project setup followed from this:
https://developers.google.com/vr/develop/unity/get-started-ios



#Build instructions
'''
Required: (1) iPhone 5 or higher
          (2) iOS 8.0 or higher
'''
              
## Step 1: Install Unity 
    (1) Recommended version: [LTS release 2017.4](https://unity3d.com/unity/qa/lts-releases) or newer here: 
    (2) Minimum version: 5.6
    - Make sure **iOS Build Support** is selected during installation.
    
## Step 2: Configure your environment for iOS development
    - Refer to Unity's guide for [Getting started with iOS development](https://docs.unity3d.com/Manual/iphone-GettingStarted.html)

## Step 3: Download the Google VR SDK for Unity
    (1) Download the latest **GoogleVRForUnity_\*.unitypackage** [here](https://github.com/googlevr/gvr-unity-sdk/releases): 

## Step 4: Create a new Unity project and import the Google VR Unity package
    (1) Open Unity and create a new **3D project**
    (2) Select **Assets > Import Package > Custom Package**
    (3) Select the **GoogleVRForUnity_\*.unitypackage** file that was downloaded
    (4) In the **Importing Package** dialog, click **Import**
        - Accept any [API upgrades](https://docs.unity3d.com/Manual/APIUpdater.html) if prompted

## Step 5: Configure build settings and player settings
    (1) Select **File > Build Settings**
    (2) Select iOS and click **Switch Platform**
    (3) In the **Build Settings** window, click **Player Settings**
    (4) Configure the following player settings:
        (a) **Player Settings > Other Settings > Virtual Reality Supported**  -->  Enabled
        (b) **Player Settings > Other Settings > SDKs** --> Click + and select Cardboard
        (c) **Player Settings > Other Settings > Target minimum iOS version** --> 8.0 or higher
        (d) **Player Settings > Other Settings > Bundle Identifier** --> Follow reverse the DNS format suggested by Apple
        
## Step 6: Preview the demo scene in Unity
    (1) In the Unity **Project** window, go to **Assets > Google VR > Demos > Scenes**. Open the **HelloVR** scene.
    (2) Press the **Play** button. In the **Game** view you should see a rendered demo scene.
        (a) Note that although the scene here is monoscopic, the rendering on your phone will be stereo.
    (3) Interact with the scene using simulation controls
    |        Simulated action        |        What to do        |
              Turn your head             Hold Alt + move mouse
              Tilt your view           Hold Control + move mouse
               Button press         Click anywhere in the Game view
    
## Step 7: Build and run the demo scene on your device
    (1) Connect your phoe to your computer using a USB cable
    (2) Select **File > Build and Run**
        - Unity builds your project and opens the generated Xcode workspace.
        - Note: If you use **Build Settings… > Build** to build your project, be sure to open the generated **\*.xcworkspace** workspace 
                file in Xcode, not the included **\*.xcodeproj** project file. Opening the project file will result in build errors.

