---
uid: Uno.Features.CustomizingUIApplicationDelegate
---

# Customizing the `UIApplicationDelegate` on iOS

Uno Platform provides the ability to provide custom behavior for `UIApplicationDelegate` on iOS in case of both native- and Skia-based rendering.

## Skia rendering

In Skia-based apps, the `App` type no longer derives from `UIApplicationDelegate`. Instead, Uno Platform provides `Uno.UI.Runtime.Skia.AppleUIKit.UnoUIApplicationDelegate`. If you decide to implement your own application lifecycle handling, create a new type that derives from it:

```csharp
public class MyApplicationDelegate : Uno.UI.Runtime.Skia.AppleUIKit.UnoUIApplicationDelegate
{
    // Your own code or overrides
}
```

You then need to inform Uno Platform to use this custom class instead of the built-in delegate by adjusting the host creation in `Main.iOS.cs`:

```csharp
using Uno.UI.Hosting;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new SamplesApp.App())
    .UseAppleUIKit(builder => builder.UseUIApplicationDelegate<MyApplicationDelegate>())
    .Build();

host.Run();
```

> [!IMPORTANT]
> Make sure to call the `base` methods when you override key application lifecycle methods, so that the internals of Uno Platform are still properly executed.

## Native rendering

Your `App` class already derives from `UIApplicationDelegate`. This means you can directly override the UIKit methods this class provides:

```csharp
public App : Application
{
    // Existing code in App.xaml.cs

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // Your custom handling

        return base.FinishedLaunching(application, launchOptions);
    }
}
```

> [!IMPORTANT]
> Make sure to call the `base` methods when you override key application lifecycle methods, so that the internals of Uno Platform are still properly executed.

## Scene life cycle

Apps built with the iOS 27 SDK must use the UIKit scene life cycle, or they quit at launch. Uno Platform adopts it on the app's behalf, for both Skia and native rendering: its application delegate assigns an Uno Platform scene delegate to the app's scene, so `Info.plist` needs no scene manifest.

The scene life cycle is used by default by apps built with the version 27 SDKs or later, for iOS, tvOS and Mac Catalyst. Apps built with an older SDK keep the app life cycle. To choose explicitly, set `UnoUseSceneLifecycle` in `Info.plist`:

```xml
<key>UnoUseSceneLifecycle</key>
<true/>
```

Setting it to `false` keeps the app life cycle, which only SDKs older than 27 support.

Under the scene life cycle, UIKit no longer calls the application delegate's URL, user activity, home-screen shortcut, and foreground and background methods. Uno Platform forwards each of them to the application delegate when it implements them, so overrides such as `OpenUrl`, `ContinueUserActivity`, `PerformActionForShortcutItem`, `OnActivated` and `DidEnterBackground` keep working. A few differences remain:

- The launch options passed to `FinishedLaunching` no longer contain the URL, shortcut or user activity the app was launched with. They reach `OpenUrl`, `PerformActionForShortcutItem` or `ContinueUserActivity` after the launch instead.
- The obsolete `OpenUrl` overload taking a source application and an annotation is not called. Override the one taking an options dictionary.
- With native rendering, `OnLaunched` (or `OnActivated`, for an app launched from a URL) runs when the app's scene connects, just after `FinishedLaunching`. An app launched in the background, for instance by a silent push notification, has no scene, so `OnLaunched` waits until the app is brought to the foreground.

An app that declares its own `UIApplicationSceneManifest` keeps it. Uno Platform assigns its scene delegate only to an application scene configuration that declares no delegate class. A scene delegate declared by the app is responsible for showing the app's window in its scene.
