// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//
// This file is a C# translation of the NavigationViewItemPresenter.cpp file from WinUI controls.
//

using Uno.UI.Helpers.WinUI;
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

namespace Windows.UI.Xaml.Controls.Primitives
{
	public  partial class NavigationViewItemPresenter : global::Windows.UI.Xaml.Controls.ContentControl
	{
		NavigationViewItemHelper<NavigationViewItemPresenter> m_helper = new NavigationViewItemHelper<NavigationViewItemPresenter>();

		public global::Windows.UI.Xaml.Controls.IconElement Icon
		{
			get
			{
				return (global::Windows.UI.Xaml.Controls.IconElement)this.GetValue(IconProperty);
			}
			set
			{
				this.SetValue(IconProperty, value);
			}
		}

		public static global::Windows.UI.Xaml.DependencyProperty IconProperty { get; } = 
			Windows.UI.Xaml.DependencyProperty.Register(
				"Icon",
				typeof(global::Windows.UI.Xaml.Controls.IconElement), 
				typeof(global::Windows.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter), 
				new FrameworkPropertyMetadata(
					default(global::Windows.UI.Xaml.Controls.IconElement)
				)
			);

		public NavigationViewItemPresenter() : base()
		{
			DefaultStyleKey = typeof(NavigationViewItemPresenter);
		}
		
		protected override void OnApplyTemplate()
		{
			// Retrieve pointers to stable controls 
			m_helper.Init(this);
			var navigationViewItem = GetNavigationViewItem();
			if (navigationViewItem != null)
			{
				navigationViewItem.UpdateVisualStateNoTransition();
			}
		}

		internal UIElement GetSelectionIndicator()
		{
			return m_helper.GetSelectionIndicator();  
		}

		protected override bool GoToElementStateCore(string state, bool useTransitions)
		{
			// GoToElementStateCore: Update visualstate for itself.
			// VisualStateManager::GoToState: update visualstate for it's first child.

			// If NavigationViewItemPresenter is used, two sets of VisualStateGroups are supported. One set is help to switch the style and it's NavigationViewItemPresenter itself and defined in NavigationViewItem
			// Another set is defined in style for NavigationViewItemPresenter.
			// OnLeftNavigation, OnTopNavigationPrimary, OnTopNavigationOverflow only apply to itself.
			if (state == NavigationViewItemHelper.c_OnLeftNavigation || state == NavigationViewItemHelper.c_OnLeftNavigationReveal || state == NavigationViewItemHelper.c_OnTopNavigationPrimary
				|| state == NavigationViewItemHelper.c_OnTopNavigationPrimaryReveal || state == NavigationViewItemHelper.c_OnTopNavigationOverflow)
			{
				return base.GoToElementStateCore(state, useTransitions);
			}
			return VisualStateManager.GoToState(this, state, useTransitions);
		}

		NavigationViewItem GetNavigationViewItem()
		{
			NavigationViewItem navigationViewItem = null;

			var item = SharedHelpers.GetAncestorOfType<NavigationViewItem>(VisualTreeHelper.GetParent(this));
			if (item != null)
			{
				navigationViewItem = item;
			}
			return navigationViewItem;
		}
	}
}
