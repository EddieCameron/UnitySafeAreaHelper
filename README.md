## SafeAreaHelper
#### (@eddiecameron / eddiecameron.fun)

This is a simple helper to let you emulate the iPhoneX+ safe area in the editor, as well as a helper tool to auto adjust a canvas to fit within the safe area rather than the whole screen

### How Get
Add to your project's package dependencies. Open `Your Project/Packages/manifest.json` and add to the list
```
{
  "dependencies": {
        ...,
        "com.eddiecameron.safeareahelper": "https://github.com/EddieCameron/UnitySafeAreaHelper.git"
    }
}
```

### How Use
Mostly, just toggle the emulation in Tools > Safe Area Helper > Toggle Editor Safe Area.
This will Instantiate a basic template overlay so you can see the notches, as well as make any calls to SafeAreaHelper.GetSafeArea return the emulated safe area as though it was running on an iPhone X(+)
Note that the template will look weird if you're not running in an iPhone X screen ratio! (e.g: 1125 x 2436)

The other useful tool is the SafeAreaCanvasFitter component. Place this on a RecTransform to have it adjust it's size to fit the safe area of the screen. Note that this will only work on Children of a Screen or Overlay canvas, since it assumes the parent fills the whole screen.