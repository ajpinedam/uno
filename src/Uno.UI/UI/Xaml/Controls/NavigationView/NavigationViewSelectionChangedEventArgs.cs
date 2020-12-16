// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//
// This file is a C# translation of the NavigationViewSelectionChangedEventArgs.cpp file from WinUI controls.
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
	public  partial class NavigationViewSelectionChangedEventArgs 
	{
		public  bool IsSettingsSelected
		{
			get; internal set;
		}

		public  object SelectedItem
		{
			get; internal set;
		}

		public NavigationTransitionInfo RecommendedNavigationTransitionInfo
		{
			get; internal set;
		}

		public NavigationViewItemBase SelectedItemContainer
		{
			get; internal set;
		}
	}
}
