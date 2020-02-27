using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;

#if __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#endif

namespace Windows.UI.Xaml.Controls
{
	internal partial interface IScrollContentPresenter : IUIScrollView
	{
#if __IOS__
		UIEdgeInsets ContentInset { get; set; }
#elif __MACOS__
		NSEdgeInsets ContentInset { get; set; }
#endif

	}
}
