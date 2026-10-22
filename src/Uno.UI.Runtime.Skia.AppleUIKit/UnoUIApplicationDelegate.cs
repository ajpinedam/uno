using System.Transactions;
using Foundation;
using Microsoft.UI.Xaml;
using ObjCRuntime;
using UIKit;
using Uno.Foundation.Logging;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Controls;
using Windows.UI.Core;

namespace Uno.UI.Runtime.Skia.AppleUIKit;

[Register("UnoUIApplicationDelegate")]
public partial class UnoUIApplicationDelegate : UIApplicationDelegate
{
	public UnoUIApplicationDelegate()
	{
		SubscribeBackgroundNotifications();
	}

	public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
	{
		this.LogDebug()?.LogDebug($"Application finished launching");
		Application.Start(AppleUIKitHost.CreateAppAction);

		return true;
	}

	// Implementing this opts the app into the scene life cycle even without a scene manifest.
	public override UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
		=> UnoUISceneDelegate.GetConfiguration(connectingSceneSession);

	public override bool RespondsToSelector(Selector? sel)
		=> !UnoUISceneDelegate.IsHiddenSelector(sel) && base.RespondsToSelector(sel);

	private void SubscribeBackgroundNotifications()
	{
		if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
		{
			NSNotificationCenter.DefaultCenter.AddObserver(UIScene.DidEnterBackgroundNotification, OnEnteredBackground);
			NSNotificationCenter.DefaultCenter.AddObserver(UIScene.WillEnterForegroundNotification, OnLeavingBackground);
			NSNotificationCenter.DefaultCenter.AddObserver(UIScene.DidActivateNotification, OnActivated);
			NSNotificationCenter.DefaultCenter.AddObserver(UIScene.WillDeactivateNotification, OnDeactivated);
		}
		else
		{
			NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.DidEnterBackgroundNotification, OnEnteredBackground);
			NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.WillEnterForegroundNotification, OnLeavingBackground);
			NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.DidBecomeActiveNotification, OnActivated);
			NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.WillResignActiveNotification, OnDeactivated);
		}
	}

	private static bool IsForAppWindow(NSNotification notification)
		=> UnoUISceneDelegate.IsNotificationForWindow(notification, NativeWindowWrapper.Instance?.NativeWindow);

	private void OnEnteredBackground(NSNotification notification)
	{
		if (!IsForAppWindow(notification))
		{
			return;
		}

		NativeWindowWrapper.Instance?.OnNativeVisibilityChanged(false);

		Application.Current?.RaiseEnteredBackground(() => Application.Current.RaiseSuspending());
	}

	private void OnLeavingBackground(NSNotification notification)
	{
		if (!IsForAppWindow(notification))
		{
			return;
		}

		this.LogDebug()?.LogDebug($"Application leaving background");
		Application.Current?.RaiseResuming();
		Application.Current?.RaiseLeavingBackground(() => NativeWindowWrapper.Instance?.OnNativeVisibilityChanged(true));
	}

	private void OnActivated(NSNotification notification)
	{
		if (!IsForAppWindow(notification))
		{
			return;
		}

		this.LogDebug()?.LogDebug($"Application activated");
		NativeWindowWrapper.Instance?.OnNativeActivated(CoreWindowActivationState.CodeActivated);
	}

	private void OnDeactivated(NSNotification notification)
	{
		if (!IsForAppWindow(notification))
		{
			return;
		}

		NativeWindowWrapper.Instance?.OnNativeActivated(CoreWindowActivationState.Deactivated);
	}
}
