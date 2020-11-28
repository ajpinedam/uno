using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class NavigationView
	{
		private enum TopNavigationViewLayoutState
		{
			Uninitialized = 0,
			Initialized
		}

		private enum NavigationRecommendedTransitionDirection
		{
			FromOverflow, // mapping to SlideNavigationTransitionInfo FromLeft
			FromLeft, // SlideNavigationTransitionInfo
			FromRight, // SlideNavigationTransitionInfo
			Default // Currently it's mapping to EntranceNavigationTransitionInfo and is subject to change.
		}

		private bool m_wasForceClosed = false;
		private bool m_isClosedCompact = false;
		private bool m_blockNextClosingEvent = false;
		private bool m_initialListSizeStateSet = false;

		private TopNavigationViewDataProvider m_topDataProvider = new TopNavigationViewDataProvider(this);

		private SelectionModel m_selectionModel = null;
		private IList<object> m_selectionModelSource = null;

		private ItemsSourceView m_menuItemsSource = null;
		private ItemsSourceView m_footerItemsSource = null;

		private bool m_appliedTemplate = false;

		// Identifies whenever a call is the result of OnApplyTemplate
		private bool m_fromOnApplyTemplate = false;

		// Used to defer updating the SplitView displaymode property
		private bool m_updateVisualStateForDisplayModeFromOnLoaded = false;

		// flag is used to stop recursive call. eg:
		// Customer select an item from SelectedItem property->ChangeSelection update ListView->LIstView raise OnSelectChange(we want stop here)->change property do do animation again.
		// Customer clicked listview->listview raised OnSelectChange->SelectedItem property changed->ChangeSelection->Undo the selection by SelectedItem(prevItem) (we want it stop here)->ChangeSelection again ->...
		private bool m_shouldIgnoreNextSelectionChange = false;
		// A flag to track that the selectionchange is caused by selection a item in topnav overflow menu
		private bool m_selectionChangeFromOverflowMenu = false;
		// Flag indicating whether selection change should raise item invoked. This is needed to be able to raise ItemInvoked before SelectionChanged while SelectedItem should point to the clicked item
		private bool m_shouldRaiseItemInvokedAfterSelection = false;

		private TopNavigationViewLayoutState m_topNavigationMode = TopNavigationViewLayoutState.Uninitialized;

		// A threshold to stop recovery from overflow to normal happens immediately on resize.
		private float m_topNavigationRecoveryGracePeriodWidth = 5.0f;

		// There are three ways to change IsPaneOpen:
		// 1, customer call IsPaneOpen=true/false directly or nav.IsPaneOpen is binding with a variable and the value is changed.
		// 2, customer click ToggleButton or splitView.IsPaneOpen->nav.IsPaneOpen changed because of window resize
		// 3, customer changed PaneDisplayMode.
		// 2 and 3 are internal implementation and will call by ClosePane/OpenPane. the flag is to indicate 1 if it's false
		private bool m_isOpenPaneForInteraction = false;

		private bool m_moveTopNavOverflowItemOnFlyoutClose = false;

		private bool m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise = false;

		private bool m_OrientationChangedPendingAnimation = false;

		private bool m_TabKeyPrecedesFocusChange = false;
	}
}
