// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//
// This file is a C# translation of the NavigationViewItem.cpp file from WinUI controls.
//

using System;
using Windows.UI.Xaml.Shapes;
#if HAS_UNO_WINUI
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using NavigationView = Windows.UI.Xaml.Controls.NavigationView;
using NavigationViewAutomationPeer = Windows.UI.Xaml.Automation.Peers.NavigationViewAutomationPeer;
using NavigationViewItemAutomationPeer = Windows.UI.Xaml.Automation.Peers.NavigationViewItemAutomationPeer;
using NavigationViewBackButtonVisible = Windows.UI.Xaml.Controls.NavigationViewBackButtonVisible;
using NavigationViewBackRequestedEventArgs = Windows.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs;
using NavigationViewDisplayMode = Windows.UI.Xaml.Controls.NavigationViewDisplayMode;
using NavigationViewDisplayModeChangedEventArgs = Windows.UI.Xaml.Controls.NavigationViewDisplayModeChangedEventArgs;
using NavigationViewItemHelper = Windows.UI.Xaml.Controls.NavigationViewItemHelper;
using NavigationViewItem = Windows.UI.Xaml.Controls.NavigationViewItem;
using NavigationViewItemBase = Windows.UI.Xaml.Controls.NavigationViewItemBase;
using NavigationViewItemHeader = Windows.UI.Xaml.Controls.NavigationViewItemHeader;
using NavigationViewItemInvokedEventArgs = Windows.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs;
using NavigationViewItemPresenter = Windows.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter;
using NavigationViewItemSeparator = Windows.UI.Xaml.Controls.NavigationViewItemSeparator;
using NavigationViewList = Windows.UI.Xaml.Controls.NavigationViewList;
using NavigationViewPaneClosingEventArgs = Windows.UI.Xaml.Controls.NavigationViewPaneClosingEventArgs;
using NavigationViewPaneDisplayMode = Windows.UI.Xaml.Controls.NavigationViewPaneDisplayMode;
using NavigationViewSelectionChangedEventArgs = Windows.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs;
using NavigationViewTemplateSettings = Windows.UI.Xaml.Controls.NavigationViewTemplateSettings;
using TopNavigationViewDataProvider = Windows.UI.Xaml.Controls.TopNavigationViewDataProvider;
#else
using Windows.UI.Composition;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
#endif

namespace Windows.UI.Xaml.Controls
{
	public partial class NavigationViewItem : NavigationViewItemBase
	{
		public IconElement Icon
		{
			get => (IconElement)GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

		public double CompactPaneLength
			=> (double)GetValue(CompactPaneLengthProperty);

		public bool SelectsOnInvoked
		{
			get => (bool)GetValue(SelectsOnInvokedProperty);
			set => SetValue(SelectsOnInvokedProperty, value);
		}

		[global::Uno.NotImplemented]
		public static global::Windows.UI.Xaml.DependencyProperty SelectsOnInvokedProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(SelectsOnInvoked), typeof(bool),
			typeof(global::Windows.UI.Xaml.Controls.NavigationViewItem),
			new FrameworkPropertyMetadata(true));

		public static global::Windows.UI.Xaml.DependencyProperty CompactPaneLengthProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(CompactPaneLength), typeof(double),
			typeof(NavigationViewItem),
			new FrameworkPropertyMetadata(defaultValue: 48.0)
		);

		public static global::Windows.UI.Xaml.DependencyProperty IconProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			name: nameof(Icon),
			propertyType: typeof(IconElement),
			ownerType: typeof(NavigationViewItem),
			typeMetadata: new FrameworkPropertyMetadata(defaultValue: null)
		);
	}
}
