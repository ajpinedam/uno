// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//
// This file is a C# translation of the NavigationViewHeader.cpp file from WinUI controls.
//

#if HAS_UNO_WINUI
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Controls.Primitives;
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
using Windows.UI.Xaml.Controls.Primitives;
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
	public  partial class NavigationViewItemHeader : NavigationViewItemBase
	{
		private long m_splitViewIsPaneOpenChangedRevoker;
		private long m_splitViewDisplayModeChangedRevoker;
		private bool m_isClosedCompact;

		public NavigationViewItemHeader() 
		{
			DefaultStyleKey = typeof(NavigationViewItemHeader);

			Loaded += NavigationViewItemHeader_Loaded;
		}

		private void NavigationViewItemHeader_Loaded(object sender, RoutedEventArgs e)
		{
			var splitView = GetSplitView();
			if (splitView != null)
			{
				m_splitViewIsPaneOpenChangedRevoker = splitView.RegisterPropertyChangedCallback(
					SplitView.IsPaneOpenProperty,
					OnSplitViewPropertyChanged
				);
				m_splitViewDisplayModeChangedRevoker = splitView.RegisterPropertyChangedCallback(
					SplitView.DisplayModeProperty,
					OnSplitViewPropertyChanged
				);

				UpdateIsClosedCompact();
			}

			UpdateLocalVisualState(false /*useTransitions*/);
		}

		protected override void OnApplyTemplate()
		{

			var visual = ElementCompositionPreview.GetElementVisual(this);
			NavigationView.CreateAndAttachHeaderAnimation(visual);
		}

		void OnSplitViewPropertyChanged(DependencyObject sender, DependencyProperty args)
		{
			if (args == SplitView.IsPaneOpenProperty ||
				args == SplitView.DisplayModeProperty)
			{
				UpdateIsClosedCompact();
			}
		}

		void UpdateIsClosedCompact()
		{
			var splitView = GetSplitView();
			if (splitView != null)
			{
				// Check if the pane is closed and if the splitview is in either compact mode.
				m_isClosedCompact = !splitView.IsPaneOpen && (splitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || splitView.DisplayMode == SplitViewDisplayMode.CompactInline);
				UpdateLocalVisualState(true /*useTransitions*/);
			}
		}

		void UpdateLocalVisualState(bool useTransitions)
		{
			VisualStateManager.GoToState(this, m_isClosedCompact ? "HeaderTextCollapsed" : "HeaderTextVisible", useTransitions);
		}
	}
}
