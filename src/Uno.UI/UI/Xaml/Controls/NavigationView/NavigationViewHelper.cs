// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//
// This file is a C# translation of the NavigationViewHelper.cpp file from WinUI controls.
//
using System;
using System.Collections.Generic;
using System.Text;
#if HAS_UNO_WINUI
using Microsoft.UI.Xaml.Controls;
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
#endif

namespace Windows.UI.Xaml.Controls
{
	internal enum NavigationViewVisualStateDisplayMode
	{
		Compact,
		Expanded,
		Minimal,
		MinimalWithBackButton
	}

	internal enum NavigationViewListPosition
	{
		LeftNav,
		TopPrimary,
		TopOverflow
	}

	internal enum NavigationViewPropagateTarget
	{
		LeftListView,
		TopListView,
		OverflowListView,
		All
	}

	public class NavigationViewItemHelper
	{
		public readonly static string c_OnLeftNavigationReveal = "OnLeftNavigationReveal";
		public readonly static string c_OnLeftNavigation = "OnLeftNavigation";
		public readonly static string c_OnTopNavigationPrimary = "OnTopNavigationPrimary";
		public readonly static string c_OnTopNavigationPrimaryReveal = "OnTopNavigationPrimaryReveal";
		public readonly static string c_OnTopNavigationOverflow = "OnTopNavigationOverflow";
	}

	public class NavigationViewItemHelper<T> where T : Control
	{
		static string c_selectionIndicatorName = "SelectionIndicator";
		public NavigationViewItemHelper()
		{
		}

		public UIElement GetSelectionIndicator() { return m_selectionIndicator; }

		public void Init(T item)
		{
			m_selectionIndicator = item.GetTemplateChild(c_selectionIndicatorName) as UIElement;
		}

		UIElement m_selectionIndicator;
	}
}
