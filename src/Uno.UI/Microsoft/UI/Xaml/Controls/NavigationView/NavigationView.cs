using Microsoft.UI.Xaml.Automation.Peers;
using Windows.Foundation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls
{
	public class NavigationView : ContentControl
	{
		// General items
		private const string c_togglePaneButtonName = "TogglePaneButton";
		private const string c_paneTitleHolderFrameworkElement = "PaneTitleHolder";
		private const string c_paneTitleFrameworkElement = "PaneTitleTextBlock";
		private const string c_rootSplitViewName = "RootSplitView";
		private const string c_menuItemsHost = "MenuItemsHost";
		private const string c_footerMenuItemsHost = "FooterMenuItemsHost";
		private const string c_selectionIndicatorName = "SelectionIndicator";
		private const string c_paneContentGridName = "PaneContentGrid";
		private const string c_rootGridName = "RootGrid";
		private const string c_contentGridName = "ContentGrid";
		private const string c_searchButtonName = "PaneAutoSuggestButton";
		private const string c_paneToggleButtonIconGridColumnName = "PaneToggleButtonIconWidthColumn";
		private const string c_togglePaneTopPadding = "TogglePaneTopPadding";
		private const string c_contentPaneTopPadding = "ContentPaneTopPadding";
		private const string c_contentLeftPadding = "ContentLeftPadding";
		private const string c_navViewBackButton = "NavigationViewBackButton";
		private const string c_navViewBackButtonToolTip = "NavigationViewBackButtonToolTip";
		private const string c_navViewCloseButton = "NavigationViewCloseButton";
		private const string c_navViewCloseButtonToolTip = "NavigationViewCloseButtonToolTip";
		private const string c_paneShadowReceiverCanvas = "PaneShadowReceiver";
		private const string c_flyoutRootGrid = "FlyoutRootGrid";

		// DisplayMode Top specific items
		private const string c_topNavMenuItemsHost = "TopNavMenuItemsHost";
		private const string c_topNavFooterMenuItemsHost = "TopFooterMenuItemsHost";
		private const string c_topNavOverflowButton = "TopNavOverflowButton";
		private const string c_topNavMenuItemsOverflowHost = "TopNavMenuItemsOverflowHost";
		private const string c_topNavGrid = "TopNavGrid";
		private const string c_topNavContentOverlayAreaGrid = "TopNavContentOverlayAreaGrid";
		private const string c_leftNavPaneAutoSuggestBoxPresenter = "PaneAutoSuggestBoxPresenter";
		private const string c_topNavPaneAutoSuggestBoxPresenter = "TopPaneAutoSuggestBoxPresenter";
		private const string c_paneTitlePresenter = "PaneTitlePresenter";

		// DisplayMode Left specific items
		private const string c_leftNavFooterContentBorder = "FooterContentBorder";
		private const string c_leftNavPaneHeaderContentBorder = "PaneHeaderContentBorder";
		private const string c_leftNavPaneCustomContentBorder = "PaneCustomContentBorder";

		private const string c_itemsContainer = "ItemsContainerGrid";
		private const string c_itemsContainerRow = "ItemsContainerRow";
		private const string c_visualItemsSeparator = "VisualItemsSeparator";
		private const string c_menuItemsScrollViewer = "MenuItemsScrollViewer";
		private const string c_footerItemsScrollViewer = "FooterItemsScrollViewer";

		private const string c_paneHeaderOnTopPane = "PaneHeaderOnTopPane";
		private const string c_paneTitleOnTopPane = "PaneTitleOnTopPane";
		private const string c_paneCustomContentOnTopPane = "PaneCustomContentOnTopPane";
		private const string c_paneFooterOnTopPane = "PaneFooterOnTopPane";
		private const string c_paneHeaderCloseButtonColumn = "PaneHeaderCloseButtonColumn";
		private const string c_paneHeaderToggleButtonColumn = "PaneHeaderToggleButtonColumn";
		private const string c_paneHeaderContentBorderRow = "PaneHeaderContentBorderRow";

		private const int c_backButtonHeight = 40;
		private const int c_backButtonWidth = 40;
		private const int c_paneToggleButtonHeight = 40;
		private const int c_paneToggleButtonWidth = 40;
		private const int c_toggleButtonHeightWhenShouldPreserveNavigationViewRS3Behavior = 56;
		private const int c_backButtonRowDefinition = 1;
		private const float c_paneElevationTranslationZ = 32;

		private const int c_mainMenuBlockIndex = 0;
		private const int c_footerMenuBlockIndex = 1;

		private int itemNotFound = -1;

		// TODO: MZ: PositiveInfinity or MaxValue?
		private static Size c_infSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

		~NavigationView()
		{
			UnhookEventsAndClearFields(true);
		}

		// UIElement / UIElementOverridesHelper
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new NavigationViewAutomationPeer(this);
		}

		void UnhookEventsAndClearFields(bool isFromDestructor)
		{
			//TODO: MZ: Implement

			//m_titleBarMetricsChangedRevoker.revoke();
			//m_titleBarIsVisibleChangedRevoker.revoke();
			//m_paneToggleButtonClickRevoker.revoke();

			//m_settingsItem = null;

			//m_paneSearchButtonClickRevoker.revoke();
			//m_paneSearchButton = null;

			//m_paneHeaderOnTopPane = null;
			//m_paneTitleOnTopPane = null;

			//m_itemsContainerSizeChangedRevoker.revoke();
			//m_paneTitleHolderFrameworkElementSizeChangedRevoker.revoke();
			//m_paneTitleHolderFrameworkElement = null;

			//m_paneTitleFrameworkElement = null;
			//m_paneTitlePresenter = null;

			//m_paneHeaderCloseButtonColumn = null;
			//m_paneHeaderToggleButtonColumn = null;
			//m_paneHeaderContentBorderRow = null;

			//m_leftNavItemsRepeaterElementPreparedRevoker.revoke();
			//m_leftNavItemsRepeaterElementClearingRevoker.revoke();
			//m_leftNavRepeaterLoadedRevoker.revoke();
			//m_leftNavRepeaterGettingFocusRevoker.revoke();
			//m_leftNavRepeater = null;

			//m_topNavItemsRepeaterElementPreparedRevoker.revoke();
			//m_topNavItemsRepeaterElementClearingRevoker.revoke();
			//m_topNavRepeaterLoadedRevoker.revoke();
			//m_topNavRepeaterGettingFocusRevoker.revoke();
			//m_topNavRepeater = null;

			//m_leftNavFooterMenuItemsRepeaterElementPreparedRevoker.revoke();
			//m_leftNavFooterMenuItemsRepeaterElementClearingRevoker.revoke();
			//m_leftNavFooterMenuRepeaterLoadedRevoker.revoke();
			//m_leftNavFooterMenuRepeaterGettingFocusRevoker.revoke();
			//m_leftNavFooterMenuRepeater = null;

			//m_topNavFooterMenuItemsRepeaterElementPreparedRevoker.revoke();
			//m_topNavFooterMenuItemsRepeaterElementClearingRevoker.revoke();
			//m_topNavFooterMenuRepeaterLoadedRevoker.revoke();
			//m_topNavFooterMenuRepeaterGettingFocusRevoker.revoke();
			//m_topNavFooterMenuRepeater = null;

			//m_footerItemsCollectionChangedRevoker.revoke();
			//m_menuItemsCollectionChangedRevoker.revoke();

			//m_topNavOverflowItemsRepeaterElementPreparedRevoker.revoke();
			//m_topNavOverflowItemsRepeaterElementClearingRevoker.revoke();
			//m_topNavRepeaterOverflowView = null;

			//m_topNavOverflowItemsCollectionChangedRevoker.revoke();

			//if (isFromDestructor)
			//{
			//	m_selectionChangedRevoker.revoke();
			//	m_autoSuggestBoxSuggestionChosenRevoker.revoke();
			//}
		}

		public NavigationView()
		{
			//__RP_Marker_ClassById(RuntimeProfiler.ProfId_NavigationView);
			SetValue(TemplateSettingsProperty, new NavigationViewTemplateSettings());
			DefaultStyleKey = typeof(NavigationView);

			SizeChanged({ this, &OnSizeChanged });

			m_selectionModelSource = new Vector<object>(2);
			m_selectionModelSource.Append(null);
			m_selectionModelSource.Append(null);

			var items = new Vector<object>();
			SetValue(MenuItemsProperty, items);

			var footerItems = new Vector<object>();
			SetValue(FooterMenuItemsProperty, footerItems);

			var weakThis = get_weak();
			m_topDataProvider.OnRawDataChanged(
	

				[weakThis](NotifyCollectionChangedEventArgs args)
	

		{
				if (var target = weakThis)
            {
					target.OnTopNavDataSourceChanged(args);
				}
			});

			Unloaded({ this, &OnUnloaded });
			Loaded({ this, &OnLoaded });

			m_selectionModel.SingleSelect(true);
			m_selectionModel.Source(m_selectionModelSource);
			m_selectionChangedRevoker = m_selectionModel.SelectionChanged(auto_revoke, { this, &OnSelectionModelSelectionChanged });
			m_childrenRequestedRevoker = m_selectionModel.ChildrenRequested(auto_revoke, { this, &OnSelectionModelChildrenRequested });

			m_navigationViewItemsFactory = make_self<NavigationViewItemsFactory>();

			NavigationViewItemRevokersProperty =
				InitializeDependencyProperty(
					"NavigationViewItemRevokers",
					name_of<object>(),
					name_of<NavigationViewItem>(),
					true /* isAttached */,
					null /* defaultValue */);
		}

		void OnSelectionModelChildrenRequested(SelectionModel& selectionModel, SelectionModelChildrenRequestedEventArgs e)
		{
			// this is main menu or footer
			if (e.SourceIndex().GetSize() == 1)
			{
				e.Children(e.Source());
			}
			else if (var nvi = e.Source() as NavigationViewItem())
    {
				e.Children(GetChildren(nvi));
			}

	else if (var children = GetChildrenForItemInIndexPath(e.SourceIndex(), true /*forceRealize*/))
    {
				e.Children(children);
			}
		}

		void OnFooterItemsSourceCollectionChanged(object&, object&)
		{
			UpdateFooterRepeaterItemsSource(false /*sourceCollectionReset*/, true /*sourceCollectionChanged*/);

			// Pane footer items changed. This means we might need to reevaluate the pane layout.
			UpdatePaneLayout();
		}

		void OnOverflowItemsSourceCollectionChanged(object&, object&)
		{
			if (m_topNavRepeaterOverflowView.ItemsSourceView().Count() == 0)
			{
				SetOverflowButtonVisibility(Visibility.Collapsed);
			}
		}

		void OnSelectionModelSelectionChanged(SelectionModel& selectionModel, SelectionModelSelectionChangedEventArgs e)
		{
			var selectedItem = selectionModel.SelectedItem();

			// Ignore this callback if:
			// 1. the SelectedItem property of NavigationView is already set to the item
			//    being passed in this callback. This is because the item has already been selected
			//    via API and we are just updating the m_selectionModel state to accurately reflect the new selection.
			// 2. Template has not been applied yet. SelectionModel's selectedIndex state will get properly updated
			//    after the repeater finishes loading.
			// TODO: Update SelectedItem comparison to work for the exact same item datasource scenario
			if (m_shouldIgnoreNextSelectionChange || selectedItem == SelectedItem() || !m_appliedTemplate)
			{
				return;
			}

			bool setSelectedItem = true;
			var selectedIndex = selectionModel.SelectedIndex();

			if (IsTopNavigationView())
			{
				// If selectedIndex does not exist, means item is being deselected through API
				var isInOverflow = (selectedIndex && selectedIndex.GetSize() > 1)
					? selectedIndex.GetAt(0) == c_mainMenuBlockIndex && !m_topDataProvider.IsItemInPrimaryList(selectedIndex.GetAt(1))
					: false;
				if (isInOverflow)
				{
					// We only want to close the overflow flyout and move the item on selection if it is a leaf node
					var itemShouldBeMoved = [selectedIndex, this]()
	

			{
						if (var selectedContainer = GetContainerForIndexPath(selectedIndex))
                {
							if (var selectedNVI = selectedContainer as NavigationViewItem())
                    {
								if (DoesNavigationViewItemHaveChildren(selectedNVI))
								{
									return false;
								}
							}
						}
						return true;
					} ();

					if (itemShouldBeMoved)
					{
						SelectandMoveOverflowItem(selectedItem, selectedIndex, true /*closeFlyout*/);
						setSelectedItem = false;
					}
					else
					{
						m_moveTopNavOverflowItemOnFlyoutClose = true;
					}
				}
			}

			if (setSelectedItem)
			{
				SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(selectedItem);
			}
		}

		void SelectandMoveOverflowItem(object & selectedItem, IndexPath & selectedIndex, bool closeFlyout)
		{
			// SelectOverflowItem is moving data in/out of overflow.
			var scopeGuard = gsl.finally([this]()
	

		{
				m_selectionChangeFromOverflowMenu = false;
			});
			m_selectionChangeFromOverflowMenu = true;

			if (closeFlyout)
			{
				CloseTopNavigationViewFlyout();
			}

			if (!IsSelectionSuppressed(selectedItem))
			{
				SelectOverflowItem(selectedItem, selectedIndex);
			}
			}

			// We only need to close the flyout if the selected item is a leaf node
			void CloseFlyoutIfRequired(NavigationViewItem&selectedItem)
{
				var selectedIndex = m_selectionModel.SelectedIndex();
				bool isInModeWithFlyout = [this]()

	{
					if (var splitView = m_rootSplitView)
        {
						// Check if the pane is closed and if the splitview is in either compact mode.
						var splitViewDisplayMode = splitView.DisplayMode();
						return (!splitView.IsPaneOpen() && (splitViewDisplayMode == SplitViewDisplayMode.CompactOverlay || splitViewDisplayMode == SplitViewDisplayMode.CompactInline)) ||
								PaneDisplayMode() == NavigationViewPaneDisplayMode.Top;
					}
					return false;
				} ();

				if (isInModeWithFlyout && selectedIndex && !DoesNavigationViewItemHaveChildren(selectedItem))
				{
					// Item selected is a leaf node, find top level parent and close flyout
					if (var rootItem = GetContainerForIndex(selectedIndex.GetAt(1), selectedIndex.GetAt(0) == c_footerMenuBlockIndex /* inFooter */))
        {
						if (var nvi = rootItem as NavigationViewItem())
            {
							var nviImpl = get_self<NavigationViewItem>(nvi);
							if (nviImpl.ShouldRepeaterShowInFlyout())
							{
								nvi.IsExpanded(false);
							}
						}
					}
				}
			}

			void OnApplyTemplate()
			{
				// Stop update anything because of PropertyChange during OnApplyTemplate. Update them all together at the end of this function
				m_appliedTemplate = false;
				var scopeGuard = gsl.finally([this]()
	

		{
					m_fromOnApplyTemplate = false;
				});
			m_fromOnApplyTemplate = true;

			UnhookEventsAndClearFields();

			//IControlProtected controlProtected = this;

			// Set up the pane toggle button click handler
			if (var paneToggleButton = GetTemplateChildT<Button>(c_togglePaneButtonName, controlProtected))
    {
				m_paneToggleButton = paneToggleButton;
				m_paneToggleButtonClickRevoker = paneToggleButton.Click(auto_revoke, { this, &OnPaneToggleButtonClick });

				SetPaneToggleButtonAutomationName();

				if (SharedHelpers.IsRS3OrHigher())
				{
					KeyboardAccelerator keyboardAccelerator;
					keyboardAccelerator.Key(VirtualKey.Back);
					keyboardAccelerator.Modifiers(VirtualKeyModifiers.Windows);
					paneToggleButton.KeyboardAccelerators().Append(keyboardAccelerator);
				}
			}

			m_leftNavPaneHeaderContentBorder = (ContentControl)GetTemplateChild(c_leftNavPaneHeaderContentBorder);
			m_leftNavPaneCustomContentBorder = (ContentControl)GetTemplateChild(c_leftNavPaneCustomContentBorder);
			m_leftNavFooterContentBorder = (ContentControl)GetTemplateChild(c_leftNavFooterContentBorder);
			m_paneHeaderOnTopPane = (ContentControl)GetTemplateChild(c_paneHeaderOnTopPane);
			m_paneTitleOnTopPane = (ContentControl)GetTemplateChild(c_paneTitleOnTopPane);
			m_paneCustomContentOnTopPane = (ContentControl)GetTemplateChild(c_paneCustomContentOnTopPane);
			m_paneFooterOnTopPane = (ContentControl)GetTemplateChild(c_paneFooterOnTopPane);

			// Get a pointer to the root SplitView
			if (var splitView = GetTemplateChildT<SplitView>(c_rootSplitViewName, controlProtected))
    {
				m_rootSplitView = splitView;
				m_splitViewIsPaneOpenChangedRevoker = RegisterPropertyChanged(splitView,
					SplitView.IsPaneOpenProperty(),

			{ this, &OnSplitViewClosedCompactChanged });

				m_splitViewDisplayModeChangedRevoker = RegisterPropertyChanged(splitView,
					SplitView.DisplayModeProperty(),

			{ this, &OnSplitViewClosedCompactChanged });

				if (SharedHelpers.IsRS3OrHigher()) // These events are new to RS3/v5 API
				{
					m_splitViewPaneClosedRevoker = splitView.PaneClosed(auto_revoke, { this, &OnSplitViewPaneClosed });
					m_splitViewPaneClosingRevoker = splitView.PaneClosing(auto_revoke, { this, &OnSplitViewPaneClosing });
					m_splitViewPaneOpenedRevoker = splitView.PaneOpened(auto_revoke, { this, &OnSplitViewPaneOpened });
					m_splitViewPaneOpeningRevoker = splitView.PaneOpening(auto_revoke, { this, &OnSplitViewPaneOpening });
				}

				UpdateIsClosedCompact();
			}

			m_topNavGrid = (Grid)GetTemplateChild(c_topNavGrid);

			// Change code to NOT do this if we're in top nav mode, to prevent it from being realized:
			if (var leftNavRepeater = GetTemplateChildT<ItemsRepeater>(c_menuItemsHost, controlProtected))
    {
				m_leftNavRepeater = leftNavRepeater;

				// API is currently in preview, so setting this via code.
				// Disabling virtualization for now because of https://github.com/microsoft/microsoft-ui-xaml/issues/2095
				if (var stackLayout = leftNavRepeater.Layout() as StackLayout())
        {
					var stackLayoutImpl = get_self<StackLayout>(stackLayout);
					stackLayoutImpl.DisableVirtualization(true);
				}

				m_leftNavItemsRepeaterElementPreparedRevoker = leftNavRepeater.ElementPrepared(auto_revoke, { this, &OnRepeaterElementPrepared });
				m_leftNavItemsRepeaterElementClearingRevoker = leftNavRepeater.ElementClearing(auto_revoke, { this, &OnRepeaterElementClearing });

				m_leftNavRepeaterLoadedRevoker = leftNavRepeater.Loaded(auto_revoke, { this, &OnRepeaterLoaded });

				m_leftNavRepeaterGettingFocusRevoker = leftNavRepeater.GettingFocus(auto_revoke, { this, &OnRepeaterGettingFocus });

				leftNavRepeater.ItemTemplate(*m_navigationViewItemsFactory);
			}

			// Change code to NOT do this if we're in left nav mode, to prevent it from being realized:
			if (var topNavRepeater = GetTemplateChildT<ItemsRepeater>(c_topNavMenuItemsHost, controlProtected))
    {
				m_topNavRepeater = topNavRepeater;

				// API is currently in preview, so setting this via code
				if (var stackLayout = topNavRepeater.Layout() as StackLayout())
        {
					var stackLayoutImpl = get_self<StackLayout>(stackLayout);
					stackLayoutImpl.DisableVirtualization(true);
				}

				m_topNavItemsRepeaterElementPreparedRevoker = topNavRepeater.ElementPrepared(auto_revoke, { this, &OnRepeaterElementPrepared });
				m_topNavItemsRepeaterElementClearingRevoker = topNavRepeater.ElementClearing(auto_revoke, { this, &OnRepeaterElementClearing });

				m_topNavRepeaterLoadedRevoker = topNavRepeater.Loaded(auto_revoke, { this, &OnRepeaterLoaded });

				m_topNavRepeaterGettingFocusRevoker = topNavRepeater.GettingFocus(auto_revoke, { this, &OnRepeaterGettingFocus });

				topNavRepeater.ItemTemplate(*m_navigationViewItemsFactory);
			}

			// Change code to NOT do this if we're in left nav mode, to prevent it from being realized:
			if (var topNavListOverflowRepeater = GetTemplateChildT<ItemsRepeater>(c_topNavMenuItemsOverflowHost, controlProtected))
    {
				m_topNavRepeaterOverflowView = topNavListOverflowRepeater;

				// API is currently in preview, so setting this via code.
				// Disabling virtualization for now because of https://github.com/microsoft/microsoft-ui-xaml/issues/2095
				if (var stackLayout = topNavListOverflowRepeater.Layout() as StackLayout())
        {
					var stackLayoutImpl = get_self<StackLayout>(stackLayout);
					stackLayoutImpl.DisableVirtualization(true);
				}

				m_topNavOverflowItemsRepeaterElementPreparedRevoker = topNavListOverflowRepeater.ElementPrepared(auto_revoke, { this, &OnRepeaterElementPrepared });
				m_topNavOverflowItemsRepeaterElementClearingRevoker = topNavListOverflowRepeater.ElementClearing(auto_revoke, { this, &OnRepeaterElementClearing });

				topNavListOverflowRepeater.ItemTemplate(*m_navigationViewItemsFactory);
			}

			if (var topNavOverflowButton = GetTemplateChildT<Button>(c_topNavOverflowButton, controlProtected))
    {
				m_topNavOverflowButton = topNavOverflowButton;
				AutomationProperties.SetName(topNavOverflowButton, ResourceAccessor.GetLocalizedStringResource(SR_NavigationOverflowButtonName));
				topNavOverflowButton.ContentResourceAccessor.GetLocalizedStringResource(SR_NavigationOverflowButtonText));
				var visual = ElementCompositionPreview.GetElementVisual(topNavOverflowButton);
				CreateAndAttachHeaderAnimation(visual);

				var toolTip = ToolTipService.GetToolTip(topNavOverflowButton);
				if (!toolTip)
				{
					var tooltip = ToolTip();
					tooltip.ContentResourceAccessor.GetLocalizedStringResource(SR_NavigationOverflowButtonToolTip));
					ToolTipService.SetToolTip(topNavOverflowButton, tooltip);
				}

				if (var flyoutBase = topNavOverflowButton.Flyout())
        {
					if (IFlyoutBase6 topNavOverflowButtonAsFlyoutBase6 = flyoutBase)
            {
						topNavOverflowButtonAsFlyoutBase6.ShouldConstrainToRootBounds(false);
					}
					m_flyoutClosingRevoker = flyoutBase.Closing(auto_revoke, { this, &OnFlyoutClosing });
				}
			}

			// Change code to NOT do this if we're in top nav mode, to prevent it from being realized:
			if (var leftFooterMenuNavRepeater = GetTemplateChildT<ItemsRepeater>(c_footerMenuItemsHost, controlProtected))
    {
				m_leftNavFooterMenuRepeater = leftFooterMenuNavRepeater;

				// API is currently in preview, so setting this via code.
				// Disabling virtualization for now because of https://github.com/microsoft/microsoft-ui-xaml/issues/2095
				if (var stackLayout = leftFooterMenuNavRepeater.Layout() as StackLayout())
        {
					var stackLayoutImpl = get_self<StackLayout>(stackLayout);
					stackLayoutImpl.DisableVirtualization(true);
				}

				m_leftNavFooterMenuItemsRepeaterElementPreparedRevoker = leftFooterMenuNavRepeater.ElementPrepared(auto_revoke, { this, &OnRepeaterElementPrepared });
				m_leftNavFooterMenuItemsRepeaterElementClearingRevoker = leftFooterMenuNavRepeater.ElementClearing(auto_revoke, { this, &OnRepeaterElementClearing });

				m_leftNavFooterMenuRepeaterLoadedRevoker = leftFooterMenuNavRepeater.Loaded(auto_revoke, { this, &OnRepeaterLoaded });

				m_leftNavFooterMenuRepeaterGettingFocusRevoker = leftFooterMenuNavRepeater.GettingFocus(auto_revoke, { this, &OnRepeaterGettingFocus });

				leftFooterMenuNavRepeater.ItemTemplate(*m_navigationViewItemsFactory);
			}

			// Change code to NOT do this if we're in left nav mode, to prevent it from being realized:
			if (var topFooterMenuNavRepeater = GetTemplateChildT<ItemsRepeater>(c_topNavFooterMenuItemsHost, controlProtected))
    {
				m_topNavFooterMenuRepeater = topFooterMenuNavRepeater;

				// API is currently in preview, so setting this via code.
				// Disabling virtualization for now because of https://github.com/microsoft/microsoft-ui-xaml/issues/2095
				if (var stackLayout = topFooterMenuNavRepeater.Layout() as StackLayout())
        {
					var stackLayoutImpl = get_self<StackLayout>(stackLayout);
					stackLayoutImpl.DisableVirtualization(true);
				}

				m_topNavFooterMenuItemsRepeaterElementPreparedRevoker = topFooterMenuNavRepeater.ElementPrepared(auto_revoke, { this, &OnRepeaterElementPrepared });
				m_topNavFooterMenuItemsRepeaterElementClearingRevoker = topFooterMenuNavRepeater.ElementClearing(auto_revoke, { this, &OnRepeaterElementClearing });

				m_topNavFooterMenuRepeaterLoadedRevoker = topFooterMenuNavRepeater.Loaded(auto_revoke, { this, &OnRepeaterLoaded });

				m_topNavFooterMenuRepeaterGettingFocusRevoker = topFooterMenuNavRepeater.GettingFocus(auto_revoke, { this, &OnRepeaterGettingFocus });

				topFooterMenuNavRepeater.ItemTemplate(*m_navigationViewItemsFactory);
			}

			m_topNavContentOverlayAreaGrid = (Border)GetTemplateChild(c_topNavContentOverlayAreaGrid);
			m_leftNavPaneAutoSuggestBoxPresenter = (ContentControl)GetTemplateChild(c_leftNavPaneAutoSuggestBoxPresenter);
			m_topNavPaneAutoSuggestBoxPresenter = (ContentControl)GetTemplateChild(c_topNavPaneAutoSuggestBoxPresenter);

			// Get pointer to the pane content area, for use in the selection indicator animation
			m_paneContentGrid = (UIElement)GetTemplateChild(c_paneContentGridName);

			m_contentLeftPadding = (FrameworkElement)GetTemplateChild(c_contentLeftPadding);

			m_paneHeaderCloseButtonColumn = (ColumnDefinition)GetTemplateChild(c_paneHeaderCloseButtonColumn);
			m_paneHeaderToggleButtonColumn = (ColumnDefinition)GetTemplateChild(c_paneHeaderToggleButtonColumn);
			m_paneHeaderContentBorderRow = (RowDefinition)GetTemplateChild(c_paneHeaderContentBorderRow);
			m_paneTitleFrameworkElement = (FrameworkElement)GetTemplateChild(c_paneTitleFrameworkElement);
			m_paneTitlePresenter = (ContentControl)GetTemplateChild(c_paneTitlePresenter);

			if (var paneTitleHolderFrameworkElement = GetTemplateChildT<FrameworkElement>(c_paneTitleHolderFrameworkElement, controlProtected))
    {
				m_paneTitleHolderFrameworkElement = paneTitleHolderFrameworkElement;
				m_paneTitleHolderFrameworkElementSizeChangedRevoker = paneTitleHolderFrameworkElement.SizeChanged(auto_revoke, { this, &OnPaneTitleHolderSizeChanged });
			}

			// Set automation name on search button
			if (var button = GetTemplateChildT<Button>(c_searchButtonName, controlProtected))
    {
				m_paneSearchButton = button;
				m_paneSearchButtonClickRevoker = button.Click(auto_revoke, { this, &OnPaneSearchButtonClick });

				var searchButtonName = ResourceAccessor.GetLocalizedStringResource(SR_NavigationViewSearchButtonName);
				AutomationProperties.SetName(button, searchButtonName);
				var toolTip = ToolTip();
				toolTip.ContentsearchButtonName);
				ToolTipService.SetToolTip(button, toolTip);
			}

			if (var backButton = GetTemplateChildT<Button>(c_navViewBackButton, controlProtected))
    {
				m_backButton = backButton;
				m_backButtonClickedRevoker = backButton.Click(auto_revoke, { this, &OnBackButtonClicked });

				hstring navigationName = ResourceAccessor.GetLocalizedStringResource(SR_NavigationBackButtonName);
				AutomationProperties.SetName(backButton, navigationName);
			}

			// Register for changes in title bar layout
			if (var coreTitleBar = CoreApplication.GetCurrentView().TitleBar())
    {
				m_coreTitleBar = coreTitleBar;
				m_titleBarMetricsChangedRevoker = coreTitleBar.LayoutMetricsChanged(auto_revoke, { this, &OnTitleBarMetricsChanged });
				m_titleBarIsVisibleChangedRevoker = coreTitleBar.IsVisibleChanged(auto_revoke, { this, &OnTitleBarIsVisibleChanged });

				if (ShouldPreserveNavigationViewRS4Behavior())
				{
					m_togglePaneTopPadding = (FrameworkElement)GetTemplateChild(c_togglePaneTopPadding);
					m_contentPaneTopPadding = (FrameworkElement)GetTemplateChild(c_contentPaneTopPadding);
				}
			}

			if (var backButtonToolTip = GetTemplateChildT<ToolTip>(c_navViewBackButtonToolTip, controlProtected))
    {
				hstring navigationBackButtonToolTip = ResourceAccessor.GetLocalizedStringResource(SR_NavigationBackButtonToolTip);
				backButtonToolTip.ContentnavigationBackButtonToolTip);
			}

			if (var closeButton = GetTemplateChildT<Button>(c_navViewCloseButton, controlProtected))
    {
				m_closeButton = closeButton;
				m_closeButtonClickedRevoker = closeButton.Click(auto_revoke, { this, &OnPaneToggleButtonClick });

				hstring navigationName = ResourceAccessor.GetLocalizedStringResource(SR_NavigationCloseButtonName);
				AutomationProperties.SetName(closeButton, navigationName);
			}

			if (var closeButtonToolTip = GetTemplateChildT<ToolTip>(c_navViewCloseButtonToolTip, controlProtected))
    {
				hstring navigationCloseButtonToolTip = ResourceAccessor.GetLocalizedStringResource(SR_NavigationButtonOpenName);
				closeButtonToolTip.ContentnavigationCloseButtonToolTip);
			}

			m_itemsContainerRow = (RowDefinition)GetTemplateChild(c_itemsContainerRow);
			m_menuItemsScrollViewer = (FrameworkElement)GetTemplateChild(c_menuItemsScrollViewer);
			m_footerItemsScrollViewer = (FrameworkElement)GetTemplateChild(c_footerItemsScrollViewer);
			m_visualItemsSeparator = (FrameworkElement)GetTemplateChild(c_visualItemsSeparator);

			m_itemsContainerSizeChangedRevoker.revoke();
			if (var itemsContainerRow = GetTemplateChildT<FrameworkElement>(c_itemsContainer, controlProtected))
    {
				m_itemsContainerSizeChangedRevoker = itemsContainerRow.SizeChanged(auto_revoke,{ this,&OnItemsContainerSizeChanged });
			}

			if (SharedHelpers.IsRS2OrHigher())
			{
				// Get hold of the outermost grid and enable XYKeyboardNavigationMode
				// However, we only want this to work in the content pane + the hamburger button (which is not inside the splitview)
				// so disable it on the grid in the content area of the SplitView
				if (var rootGrid = GetTemplateChildT<Grid>(c_rootGridName, controlProtected))
        {
					rootGrid.XYFocusKeyboardNavigation(XYFocusKeyboardNavigationMode.Enabled);
				}

				if (var contentGrid = GetTemplateChildT<Grid>(c_contentGridName, controlProtected))
        {
					contentGrid.XYFocusKeyboardNavigation(XYFocusKeyboardNavigationMode.Disabled);
				}
			}

			m_accessKeyInvokedRevoker = AccessKeyInvoked(auto_revoke, { this, &OnAccessKeyInvoked });

			UpdatePaneShadow();

			m_appliedTemplate = true;

			// Do initial setup
			UpdatePaneDisplayMode();
			UpdateHeaderVisibility();
			UpdatePaneTitleFrameworkElementParents();
			UpdateTitleBarPadding();
			UpdatePaneTabFocusNavigation();
			UpdateBackAndCloseButtonsVisibility();
			UpdateSingleSelectionFollowsFocusTemplateSetting();
			UpdatePaneVisibility();
			UpdateVisualState();
			UpdatePaneTitleMargins();
			UpdatePaneLayout();
		}

		void UpdateRepeaterItemsSource(bool forceSelectionModelUpdate)
		{
			var itemsSource = [this]()
	

	{
				if (var menuItemsSource = MenuItemsSource())
        {
					return menuItemsSource;
				}
				UpdateSelectionForMenuItems();
				return MenuItems().as< object > ();
			} ();

			// Selection Model has same representation of data regardless
			// of pane mode, so only update if the ItemsSource data itself
			// has changed.
			if (forceSelectionModelUpdate)
			{
				m_selectionModelSource.SetAt(0, itemsSource);
			}

			m_menuItemsCollectionChangedRevoker.revoke();
			m_menuItemsSource = ItemsSourceView(itemsSource);
			m_menuItemsCollectionChangedRevoker = m_menuItemsSource.CollectionChanged(auto_revoke, { this, &OnMenuItemsSourceCollectionChanged });

			if (IsTopNavigationView())
			{
				UpdateLeftRepeaterItemSource(null);
				UpdateTopNavRepeatersItemSource(itemsSource);
				InvalidateTopNavPrimaryLayout();
			}
			else
			{
				UpdateTopNavRepeatersItemSource(null);
				UpdateLeftRepeaterItemSource(itemsSource);
			}
		}

		void UpdateLeftRepeaterItemSource(object& items)
		{
			UpdateItemsRepeaterItemsSource(m_leftNavRepeater, items);
			// Left pane repeater has a new items source, update pane layout.
			UpdatePaneLayout();
		}

		void UpdateTopNavRepeatersItemSource(object& items)
		{
			// Change data source and setup vectors
			m_topDataProvider.SetDataSource(items);

			// rebinding
			UpdateTopNavPrimaryRepeaterItemsSource(items);
			UpdateTopNavOverflowRepeaterItemsSource(items);
		}

		void UpdateTopNavPrimaryRepeaterItemsSource(object& items)
		{
			if (items)
			{
				UpdateItemsRepeaterItemsSource(m_topNavRepeater, m_topDataProvider.GetPrimaryItems());
			}
			else
			{
				UpdateItemsRepeaterItemsSource(m_topNavRepeater, null);
			}
		}

		void UpdateTopNavOverflowRepeaterItemsSource(object& items)
		{
			m_topNavOverflowItemsCollectionChangedRevoker.revoke();

			if (var overflowRepeater = m_topNavRepeaterOverflowView)
    {
				if (items)
				{
					var itemsSource = m_topDataProvider.GetOverflowItems();
					overflowRepeater.ItemsSource(itemsSource);

					// We listen to changes to the overflow menu item collection so we can set the visibility of the overflow button
					// to collapsed when it no longer has any items.
					//
					// Normally, MeasureOverride() kicks off updating the button's visibility, however, it is not run when the overflow menu
					// only contains a *single* item and we
					// - either remove that menu item or
					// - remove menu items displayed in the NavigationView pane until there is enough room for the single overflow menu item
					//   to be displayed in the pane
					m_topNavOverflowItemsCollectionChangedRevoker = overflowRepeater.ItemsSourceView().CollectionChanged(auto_revoke, { this, &OnOverflowItemsSourceCollectionChanged });
				}
				else
				{
					overflowRepeater.ItemsSource(null);
				}
			}
		}

		void UpdateItemsRepeaterItemsSource(ItemsRepeater& ir,
			 object& itemsSource)
		{
			if (ir)
			{
				ir.ItemsSource(itemsSource);
			}
		}

		void UpdateFooterRepeaterItemsSource(bool sourceCollectionReset, bool sourceCollectionChanged)
		{
			if (!m_appliedTemplate) return;

			var itemsSource = [this]()
	

	{
				if (var menuItemsSource = FooterMenuItemsSource())
        {
					return menuItemsSource;
				}
				UpdateSelectionForMenuItems();
				return FooterMenuItems().as< object > ();
			} ();


			UpdateItemsRepeaterItemsSource(m_leftNavFooterMenuRepeater, null);
			UpdateItemsRepeaterItemsSource(m_topNavFooterMenuRepeater, null);

			if (!m_settingsItem || sourceCollectionChanged || sourceCollectionReset)
			{
				var dataSource = new Vector<object>();

				if (!m_settingsItem)
				{
					m_settingsItem = make < .NavigationViewItem > ();
					var settingsItem = m_settingsItem;
					settingsItem.Name("SettingsItem");
					m_navigationViewItemsFactory.SettingsItem(settingsItem);
				}

				if (sourceCollectionReset)
				{
					m_footerItemsCollectionChangedRevoker.revoke();
					m_footerItemsSource = null;
				}

				if (!m_footerItemsSource)
				{
					m_footerItemsSource = ItemsSourceView(itemsSource);
					m_footerItemsCollectionChangedRevoker = m_footerItemsSource.CollectionChanged(auto_revoke, { this, &OnFooterItemsSourceCollectionChanged });
				}

				if (m_footerItemsSource)
				{
					var settingsItem = m_settingsItem;
					var size = m_footerItemsSource.Count();

					for (int i = 0; i < size; i++)
					{
						var item = m_footerItemsSource.GetAt(i).as< object > ();
						dataSource.Append(item);
					}

					if (IsSettingsVisible())
					{
						CreateAndHookEventsToSettings();
						// add settings item to the end of footer
						dataSource.Append(settingsItem);
					}
				}

				m_selectionModelSource.SetAt(1, dataSource);
			}

			if (IsTopNavigationView())
			{
				UpdateItemsRepeaterItemsSource(m_topNavFooterMenuRepeater, m_selectionModelSource.GetAt(1));
			}
			else
			{
				if (var repeater = m_leftNavFooterMenuRepeater)
        {
					UpdateItemsRepeaterItemsSource(m_leftNavFooterMenuRepeater, m_selectionModelSource.GetAt(1));

					// Footer items changed and we need to recalculate the layout.
					// However repeater "lags" behind, so we need to force it to reevaluate itself now.
					repeater.InvalidateMeasure();
					repeater.UpdateLayout();

					// Footer items changed, so let's update the pane layout.
					UpdatePaneLayout();
				}

				if (var settings = m_settingsItem)
        {
					settings.StartBringIntoView();
				}
			}
		}

		void OnFlyoutClosing(object& sender, FlyoutBaseClosingEventArgs args)
		{
			// If the user selected an parent item in the overflow flyout then the item has not been moved to top primary yet.
			// So we need to move it.
			if (m_moveTopNavOverflowItemOnFlyoutClose && !m_selectionChangeFromOverflowMenu)
			{
				m_moveTopNavOverflowItemOnFlyoutClose = false;

				var selectedIndex = m_selectionModel.SelectedIndex();
				if (selectedIndex.GetSize() > 0)
				{
					if (var firstContainer = GetContainerForIndex(selectedIndex.GetAt(1), false /*infooter*/))
            {
						if (var firstNVI = firstContainer as NavigationViewItem())
                {
							// We want to collapse the top level item before we move it
							firstNVI.IsExpanded(false);
						}
					}

					SelectandMoveOverflowItem(SelectedItem(), selectedIndex, false /*closeFlyout*/);
				}
			}
		}

		void OnNavigationViewItemIsSelectedPropertyChanged(DependencyObject sender, DependencyProperty args)
		{
			if (var nvi = sender as NavigationViewItem())
    {
				// Check whether the container that triggered this call back is the selected container
				bool isContainerSelectedInModel = IsContainerTheSelectedItemInTheSelectionModel(nvi);
				bool isSelectedInContainer = nvi.IsSelected();

				if (isSelectedInContainer && !isContainerSelectedInModel)
				{
					var indexPath = GetIndexPathForContainer(nvi);
					UpdateSelectionModelSelection(indexPath);
				}
				else if (!isSelectedInContainer && isContainerSelectedInModel)
				{
					var indexPath = GetIndexPathForContainer(nvi);
					var indexPathFromModel = m_selectionModel.SelectedIndex();

					if (indexPathFromModel && indexPath.CompareTo(indexPathFromModel) == 0)
					{
						m_selectionModel.DeselectAt(indexPath);
					}
				}

				if (isSelectedInContainer)
				{
					nvi.IsChildSelected(false);
				}
			}
		}

		void OnNavigationViewItemExpandedPropertyChanged(DependencyObject sender, DependencyProperty args)
		{
			if (var nvi = sender as NavigationViewItem())
    {
				if (nvi.IsExpanded())
				{
					RaiseExpandingEvent(nvi);
				}

				ShowHideChildrenItemsRepeater(nvi);

				if (!nvi.IsExpanded())
				{
					RaiseCollapsedEvent(nvi);
				}
			}
		}

		void RaiseItemInvokedForNavigationViewItem(NavigationViewItem& nvi)
		{
			object nextItem = null;
			var prevItem = SelectedItem();
			var parentIR = GetParentItemsRepeaterForContainer(nvi);

			if (var itemsSourceView = parentIR.ItemsSourceView())
    {
				var inspectingDataSource = (InspectingDataSource*)(get_self<ItemsSourceView>(itemsSourceView));
				var itemIndex = parentIR.GetElementIndex(nvi);

				// Check that index is NOT -1, meaning it is actually realized
				if (itemIndex != -1)
				{
					// Something went wrong, item might not be realized yet.
					nextItem = inspectingDataSource.GetAt(itemIndex);
				}
			}

			// Determine the recommeded transition direction.
			// Any transitions other than `Default` only apply in top nav scenarios.
			var recommendedDirection = [this, prevItem, nvi, parentIR]()
	

	{
				if (IsTopNavigationView() && nvi.SelectsOnInvoked())
				{
					bool isInOverflow = parentIR == m_topNavRepeaterOverflowView;
					if (isInOverflow)
					{
						return NavigationRecommendedTransitionDirection.FromOverflow;
					}
					else if (prevItem)
					{
						return GetRecommendedTransitionDirection(NavigationViewItemBaseOrSettingsContentFromData(prevItem), nvi);
					}
				}
				return NavigationRecommendedTransitionDirection.Default;
			} ();

			RaiseItemInvoked(nextItem, IsSettingsItem(nvi) /*isSettings*/, nvi, recommendedDirection);
		}

		void OnNavigationViewItemInvoked(NavigationViewItem& nvi)
		{
			m_shouldRaiseItemInvokedAfterSelection = true;

			var selectedItem = SelectedItem();
			bool updateSelection = m_selectionModel && nvi.SelectsOnInvoked();
			if (updateSelection)
			{
				var ip = GetIndexPathForContainer(nvi);

				// Determine if we will update collapse/expand which will happen iff the item has children
				if (DoesNavigationViewItemHaveChildren(nvi))
				{
					m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise = true;
				}
				UpdateSelectionModelSelection(ip);
			}

			// Item was invoked but already selected, so raise event here.
			if (selectedItem == SelectedItem())
			{
				RaiseItemInvokedForNavigationViewItem(nvi);
			}

			ToggleIsExpandedNavigationViewItem(nvi);
			ClosePaneIfNeccessaryAfterItemIsClicked(nvi);

			if (updateSelection)
			{
				CloseFlyoutIfRequired(nvi);
			}
		}

		bool IsRootItemsRepeater(DependencyObject element)
		{
			if (element)
			{
				return (element == m_topNavRepeater ||
					element == m_leftNavRepeater ||
					element == m_topNavRepeaterOverflowView ||
					element == m_leftNavFooterMenuRepeater ||
					element == m_topNavFooterMenuRepeater);
			}
			return false;
		}

		bool IsRootGridOfFlyout(DependencyObject element)
		{
			if (var grid = element as Grid())
    {
				return grid.Name() == c_flyoutRootGrid;
			}
			return false;
		}

		ItemsRepeater GetParentRootItemsRepeaterForContainer(NavigationViewItemBase& nvib)
		{
			var parentIR = GetParentItemsRepeaterForContainer(nvib);
			var currentNvib = nvib;
			while (!IsRootItemsRepeater(parentIR))
			{
				currentNvib = GetParentNavigationViewItemForContainer(currentNvib);
				parentIR = GetParentItemsRepeaterForContainer(currentNvib);
			}
			return parentIR;
		}

		ItemsRepeater GetParentItemsRepeaterForContainer(NavigationViewItemBase& nvib)
		{
			if (var parent = VisualTreeHelper.GetParent(nvib))
    {
				if (var parentIR = parent as ItemsRepeater())
        {
					return parentIR;
				}
			}
			return null;
		}

		NavigationViewItem GetParentNavigationViewItemForContainer(NavigationViewItemBase& nvib)
		{
			// TODO: This scenario does not find parent items when in a flyout, which causes problems if item if first loaded
			// straight in the flyout. Fix. This logic can be merged with the 'GetIndexPathForContainer' logic below.
			DependencyObject parent = GetParentItemsRepeaterForContainer(nvib);
			if (!IsRootItemsRepeater(parent))
			{
				while (parent)
				{
					parent = VisualTreeHelper.GetParent(parent);
					if (var nvi = parent as NavigationViewItem())
            {
						return nvi;
					}
				}
			}
			return null;
		}

		IndexPath GetIndexPathForContainer(NavigationViewItemBase& nvib)
		{
			var path = std.CalculatorList<int>();
			bool isInFooterMenu = false;

			DependencyObject child = nvib;
			var parent = VisualTreeHelper.GetParent(child);
			if (!parent)
			{
				return IndexPath.CreateFromIndices(path);
			}

			// Search through VisualTree for a root itemsrepeater
			while (parent && !IsRootItemsRepeater(parent) && !IsRootGridOfFlyout(parent))
			{
				if (var parentIR = parent as ItemsRepeater())
        {
					if (var childElement = child as UIElement())
            {
						path.insert(path.begin(), parentIR.GetElementIndex(childElement));
					}
				}
				child = parent;
				parent = VisualTreeHelper.GetParent(parent);
			}

			// If the item is in a flyout, then we need to final index of its parent
			if (IsRootGridOfFlyout(parent))
			{
				if (var nvi = m_lastItemExpandedIntoFlyout)
        {
					child = nvi;
					parent = IsTopNavigationView() ? m_topNavRepeater : m_leftNavRepeater;
				}
			}

			// If item is in one of the disconnected ItemRepeaters, account for that in IndexPath calculations
			if (parent == m_topNavRepeaterOverflowView)
			{
				// Convert index of selected item in overflow to index in datasource
				var containerIndex = m_topNavRepeaterOverflowView.GetElementIndex(child as UIElement());
				var item = m_topDataProvider.GetOverflowItems().GetAt(containerIndex);
				var indexAtRoot = m_topDataProvider.IndexOf(item);
				path.insert(path.begin(), indexAtRoot);
			}
			else if (parent == m_topNavRepeater)
			{
				// Convert index of selected item in overflow to index in datasource
				var containerIndex = m_topNavRepeater.GetElementIndex(child as UIElement());
				var item = m_topDataProvider.GetPrimaryItems().GetAt(containerIndex);
				var indexAtRoot = m_topDataProvider.IndexOf(item);
				path.insert(path.begin(), indexAtRoot);
			}
			else if (var parentIR = parent as ItemsRepeater())
    {
				path.insert(path.begin(), parentIR.GetElementIndex(child as UIElement()));
			}

			isInFooterMenu = parent == m_leftNavFooterMenuRepeater || parent == m_topNavFooterMenuRepeater;

			path.insert(path.begin(), isInFooterMenu ? c_footerMenuBlockIndex : c_mainMenuBlockIndex);

			return IndexPath.CreateFromIndices(path);
		}

		void OnRepeaterElementPrepared(ItemsRepeater& ir, ItemsRepeaterElementPreparedEventArgs args)
		{
			// This validation is only relevant outside of the Windows build where WUXC and MUXC have distinct types.
			// Certain items are disallowed in a NavigationView's items list. Check for them.
			if (args.Element() as Windows.UI.Xaml.Controls.NavigationViewItemBase())
    {
				throw hresult_invalid_argument("MenuItems contains a Windows.UI.Xaml.Controls.NavigationViewItem. This control requires that the NavigationViewItems be of type Microsoft.UI.Xaml.Controls.NavigationViewItem.");
			}

			if (var nvib = args.Element() as NavigationViewItemBase())
    {
				var nvibImpl = get_self<NavigationViewItemBase>(nvib);
				nvibImpl.SetNavigationViewParent(this);
				nvibImpl.IsTopLevelItem(IsTopLevelItem(nvib));

				// Visual state info propagation
				var position = [this, ir]()

		{
					if (IsTopNavigationView())
					{
						if (ir == m_topNavRepeater)
						{
							return NavigationViewRepeaterPosition.TopPrimary;
						}
						if (ir == m_topNavFooterMenuRepeater)
						{
							return NavigationViewRepeaterPosition.TopFooter;
						}
						return NavigationViewRepeaterPosition.TopOverflow;
					}
					if (ir == m_leftNavFooterMenuRepeater)
					{
						return NavigationViewRepeaterPosition.LeftFooter;
					}
					return NavigationViewRepeaterPosition.LeftNav;
				} ();
				nvibImpl.Position(position);

				if (var parentNVI = GetParentNavigationViewItemForContainer(nvib))
        {
					var parentNVIImpl = get_self<NavigationViewItem>(parentNVI);
					var itemDepth = parentNVIImpl.ShouldRepeaterShowInFlyout() ? 0 : parentNVIImpl.Depth() + 1;
					nvibImpl.Depth(itemDepth);
				}

		else
				{
					nvibImpl.Depth(0);
				}

				// Apply any custom container styling
				ApplyCustomMenuItemContainerStyling(nvib, ir, args.Index());

				if (var nvi = args.Element() as NavigationViewItem())
        {
					// Propagate depth to children items if they exist
					var childDepth = [position, nvibImpl]()

			{
						if (position == NavigationViewRepeaterPosition.TopPrimary)
						{
							return 0;
						}
						return nvibImpl.Depth() + 1;

					} ();
					get_self<NavigationViewItem>(nvi).PropagateDepthToChildren(childDepth);

					// Register for item events
					var nviRevokers = make_self<NavigationViewItemRevokers>();
					nviRevokers.tappedRevoker = nvi.Tapped(auto_revoke, { this, &OnNavigationViewItemTapped });
					nviRevokers.keyDownRevoker = nvi.KeyDown(auto_revoke, { this, &OnNavigationViewItemKeyDown });
					nviRevokers.gotFocusRevoker = nvi.GotFocus(auto_revoke, { this, &OnNavigationViewItemOnGotFocus });
					nviRevokers.isSelectedRevoker = RegisterPropertyChanged(nvi, NavigationViewItemBase.IsSelectedProperty(), { this, &OnNavigationViewItemIsSelectedPropertyChanged });
					nviRevokers.isExpandedRevoker = RegisterPropertyChanged(nvi, NavigationViewItem.IsExpandedProperty(), { this, &OnNavigationViewItemExpandedPropertyChanged });
					nvi.SetValue(NavigationViewItemRevokersProperty, nviRevokers.as< object > ());
				}
			}
		}

		void ApplyCustomMenuItemContainerStyling(NavigationViewItemBase& nvib, ItemsRepeater& ir, int index)
		{
			if (var menuItemContainerStyle = MenuItemContainerStyle())
    {
				nvib.Style(menuItemContainerStyle);
			}

	else if (var menuItemContainerStyleSelector = MenuItemContainerStyleSelector())
    {
				if (var itemsSourceView = ir.ItemsSourceView())
        {
					if (var item = itemsSourceView.GetAt(index))
            {
						if (var selectedStyle = menuItemContainerStyleSelector.SelectStyle(item, nvib))
                {
							nvib.Style(selectedStyle);
						}
					}
				}
			}
		}

		void OnRepeaterElementClearing(ItemsRepeater& ir, ItemsRepeaterElementClearingEventArgs args)
		{
			if (var nvib = args.Element() as NavigationViewItemBase())
    {
				var nvibImpl = get_self<NavigationViewItemBase>(nvib);
				nvibImpl.Depth(0);
				nvibImpl.IsTopLevelItem(false);
				if (var nvi = nvib as NavigationViewItem())
        {
					// Revoke all the events that we were listing to on the item
					nvi.SetValue(NavigationViewItemRevokersProperty, null);
				}
			}
		}

		// Hook up the Settings Item Invoked event listener
		void CreateAndHookEventsToSettings()
		{
			if (!m_settingsItem)
			{
				return;
			}

			var settingsItem = m_settingsItem;
			var settingsIcon = SymbolIcon(Symbol.Setting);
			settingsItem.Icon(settingsIcon);

			// Do localization for settings item label and Automation Name
			var localizedSettingsName = ResourceAccessor.GetLocalizedStringResource(SR_SettingsButtonName);
			AutomationProperties.SetName(settingsItem, localizedSettingsName);
			settingsItem.TaglocalizedSettingsName);
			UpdateSettingsItemToolTip();

			// Add the name only in case of horizontal nav
			if (!IsTopNavigationView())
			{
				settingsItem.ContentlocalizedSettingsName);
			}
			else
			{
				settingsItem.Content(null);
			}

			// hook up SettingsItem
			SetValue(SettingsItemProperty, settingsItem);
		}

		Size MeasureOverride(Size & availableSize)
		{
			if (IsTopNavigationView() && IsTopPrimaryListVisible())
			{
				if (availableSize.Width == std.numeric_limits<float>.infinity())
				{
					// We have infinite space, so move all items to primary list
					m_topDataProvider.MoveAllItemsToPrimaryList();
				}
				else
				{
					HandleTopNavigationMeasureOverride(availableSize);
# ifdef DEBUG
					if (m_topDataProvider.Size() > 0)
					{
						// We should always have at least one item in primary.
						MUX_ASSERT(m_topDataProvider.GetPrimaryItems().Size() > 0);
					}
#endif // DEBUG
				}
			}

			m_layoutUpdatedToken.revoke();
			m_layoutUpdatedToken = LayoutUpdated(auto_revoke, { this, &OnLayoutUpdated });

			return __super.MeasureOverride(availableSize);
		}

		void OnLayoutUpdated(object& sender, object& e)
		{
			// We only need to handle once after MeasureOverride, so revoke the token.
			m_layoutUpdatedToken.revoke();

			// In topnav, when an item in overflow menu is clicked, the animation is delayed because that item is not move to primary list yet.
			// And it depends on LayoutUpdated to re-play the animation. m_lastSelectedItemPendingAnimationInTopNav is the last selected overflow item.
			if (var lastSelectedItemInTopNav = m_lastSelectedItemPendingAnimationInTopNav)
    {
				m_lastSelectedItemPendingAnimationInTopNav = null;
				AnimateSelectionChanged(lastSelectedItemInTopNav);
			}

			if (m_OrientationChangedPendingAnimation)
			{
				m_OrientationChangedPendingAnimation = false;
				AnimateSelectionChanged(SelectedItem());
			}
		}

		void OnSizeChanged(object & /*sender*/, SizeChangedEventArgs args)
		{
			var width = args.NewSize().Width;
			UpdateAdaptiveLayout(width);
			UpdateTitleBarPadding();
			UpdateBackAndCloseButtonsVisibility();
			UpdatePaneLayout();
		}

		void OnItemsContainerSizeChanged(object& sender, SizeChangedEventArgs args)
		{
			UpdatePaneLayout();
		}

		// forceSetDisplayMode: On first call to SetDisplayMode, force setting to initial values
		void UpdateAdaptiveLayout(double width, bool forceSetDisplayMode)
		{
			// In top nav, there is no adaptive pane layout
			if (IsTopNavigationView())
			{
				return;
			}

			if (!m_rootSplitView)
			{
				return;
			}

			// If we decide we want it to animate open/closed when you resize the
			// window we'll have to change how we figure out the initial state
			// instead of this:
			m_initialListSizeStateSet = false; // see UpdateIsClosedCompact()

			NavigationViewDisplayMode displayMode = NavigationViewDisplayMode.Compact;

			var paneDisplayMode = PaneDisplayMode();
			if (paneDisplayMode == NavigationViewPaneDisplayMode.Auto)
			{
				if (width >= ExpandedModeThresholdWidth())
				{
					displayMode = NavigationViewDisplayMode.Expanded;
				}
				else if (width < CompactModeThresholdWidth())
				{
					displayMode = NavigationViewDisplayMode.Minimal;
				}
			}
			else if (paneDisplayMode == NavigationViewPaneDisplayMode.Left)
			{
				displayMode = NavigationViewDisplayMode.Expanded;
			}
			else if (paneDisplayMode == NavigationViewPaneDisplayMode.LeftCompact)
			{
				displayMode = NavigationViewDisplayMode.Compact;
			}
			else if (paneDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal)
			{
				displayMode = NavigationViewDisplayMode.Minimal;
			}
			else
			{
				MUX_FAIL_FAST();
			}

			if (!forceSetDisplayMode && m_InitialNonForcedModeUpdate)
			{
				if (displayMode == NavigationViewDisplayMode.Minimal ||
					displayMode == NavigationViewDisplayMode.Compact)
				{
					ClosePane();
				}
				m_InitialNonForcedModeUpdate = false;
			}

			var previousMode = DisplayMode();
			SetDisplayMode(displayMode, forceSetDisplayMode);

			if (displayMode == NavigationViewDisplayMode.Expanded && IsPaneVisible())
			{
				if (!m_wasForceClosed)
				{
					OpenPane();
				}
			}

			if (previousMode == NavigationViewDisplayMode.Expanded
				&& displayMode == NavigationViewDisplayMode.Compact)
			{
				m_initialListSizeStateSet = false;
				ClosePane();
			}
		}

		void UpdatePaneLayout()
		{
			if (!IsTopNavigationView())
			{
				var totalAvailableHeight = [this]() {
					if (var & paneContentRow = m_itemsContainerRow)
					{
						// 20px is the padding between the two item lists
						if (var & paneFooter = m_leftNavFooterContentBorder)
						{
							return paneContentRow.ActualHeight() - 29 - paneFooter.ActualHeight();
						}
						else
						{
							return paneContentRow.ActualHeight() - 29;
						}
					}
					return 0.0;
				} ();

				// Only continue if we have a positive amount of space to manage.
				if (totalAvailableHeight > 0)
				{
					// We need this value more than twice, so cache it.
					var totalAvailableHeightHalf = totalAvailableHeight / 2;

					var heightForMenuItems = [this, totalAvailableHeight, totalAvailableHeightHalf]() {
						if (var footerItemsScrollViewer = m_footerItemsScrollViewer)
                {
							if (var footerItemsRepeater = m_leftNavFooterMenuRepeater)
                    {
								// We know the actual height of footer items, so use that to determine how to split pane.
								if (var menuItems = m_leftNavRepeater)
                        {
									var footersActualHeight = footerItemsRepeater.ActualHeight();
									var menuItemsActualHeight = menuItems.ActualHeight();
									if (totalAvailableHeight > menuItemsActualHeight + footersActualHeight)
									{
										// We have enough space for two so let everyone get as much as they need.
										footerItemsScrollViewer.MaxHeight(footersActualHeight);
										if (var & separator = m_visualItemsSeparator)
										{
											separator.Visibility(Visibility.Collapsed);
										}
										return totalAvailableHeight - footersActualHeight;
									}
									else if (menuItemsActualHeight <= totalAvailableHeightHalf)
									{
										// Footer items exceed over the half, so let's limit them.
										footerItemsScrollViewer.MaxHeight(totalAvailableHeight - menuItemsActualHeight);
										if (var separator = m_visualItemsSeparator)
                                {
											separator.Visibility(Visibility.Visible);
										}
										return menuItemsActualHeight;
									}
									else if (footersActualHeight <= totalAvailableHeightHalf)
									{
										// Menu items exceed over the half, so let's limit them.
										footerItemsScrollViewer.MaxHeight(footersActualHeight);
										if (var separator = m_visualItemsSeparator)
                                {
											separator.Visibility(Visibility.Visible);
										}
										return totalAvailableHeight - footersActualHeight;
									}
									else
									{
										// Both are more than half the height, so split evenly.
										footerItemsScrollViewer.MaxHeight(totalAvailableHeightHalf);
										if (var separator = m_visualItemsSeparator)
                                {
											separator.Visibility(Visibility.Visible);
										}
										return totalAvailableHeightHalf;
									}
								}

						else
								{
									// Couldn't determine the menuItems.
									// Let's just take all the height and let the other repeater deal with it.
									return totalAvailableHeight - footerItemsRepeater.ActualHeight();
								}
							}
							// We have no idea how much space to occupy as we are not able to get the size of the footer repeater.
							// Stick with 50% as backup.
							footerItemsScrollViewer.MaxHeight(totalAvailableHeightHalf);
						}
						// We couldn't find a good strategy, so limit to 50% percent for the menu items.
						return totalAvailableHeightHalf;
					} ();
					// Footer items should have precedence as that usually contains very
					// important items such as settings or the profile.

					if (var menuItemsScrollViewer = m_menuItemsScrollViewer)
            {
						// Update max height for menu items.
						menuItemsScrollViewer.MaxHeight(heightForMenuItems);
					}
				}
			}
		}

		void OnPaneToggleButtonClick(object& /*sender*/, RoutedEventArgs /*args*/)
		{
			if (IsPaneOpen())
			{
				m_wasForceClosed = true;
				ClosePane();
			}
			else
			{
				m_wasForceClosed = false;
				OpenPane();
			}
		}

		void OnPaneSearchButtonClick(object& /*sender*/, RoutedEventArgs /*args*/)
		{
			m_wasForceClosed = false;
			OpenPane();

			if (var autoSuggestBox = AutoSuggestBox())
    {
				autoSuggestBox.Focus(FocusState.Keyboard);
			}
		}

		void OnPaneTitleHolderSizeChanged(object& /*sender*/, SizeChangedEventArgs /*args*/)
		{
			UpdateBackAndCloseButtonsVisibility();
		}

		void OpenPane()
		{
			var scopeGuard = gsl.finally([this]()
	

		{
				m_isOpenPaneForInteraction = false;
			});
			m_isOpenPaneForInteraction = true;
			IsPaneOpen(true);
			}

			// Call this when you want an uncancellable close
			void ClosePane()
			{
				CollapseMenuItemsInRepeater(m_leftNavRepeater);
				var scopeGuard = gsl.finally([this]()
	

		{
					m_isOpenPaneForInteraction = false;
				});
			m_isOpenPaneForInteraction = true;
			IsPaneOpen(false); // the SplitView is two-way bound to this value 
		}

		// Call this when NavigationView itself is going to trigger a close
		// where you will stop the close if the cancel is triggered
		bool AttemptClosePaneLightly()
		{
			bool pendingPaneClosingCancel = false;

			if (SharedHelpers.IsRS3OrHigher())
			{
				var eventArgs = make_self<NavigationViewPaneClosingEventArgs>();
				m_paneClosingEventSource(this, *eventArgs);
				pendingPaneClosingCancel = eventArgs.Cancel();
			}

			if (!pendingPaneClosingCancel || m_wasForceClosed)
			{
				m_blockNextClosingEvent = true;
				ClosePane();
				return true;
			}

			return false;
		}

		void OnSplitViewClosedCompactChanged(DependencyObject /*sender*/, DependencyProperty args)
		{
			if (args == SplitView.IsPaneOpenProperty() ||
				args == SplitView.DisplayModeProperty())
			{
				UpdateIsClosedCompact();
			}
		}

		void OnSplitViewPaneClosed(DependencyObject /*sender*/, object& obj)
		{
			m_paneClosedEventSource(this, null);
		}

		void OnSplitViewPaneClosing(DependencyObject /*sender*/, SplitViewPaneClosingEventArgs args)
		{
			bool pendingPaneClosingCancel = false;
			if (m_paneClosingEventSource)
			{
				if (!m_blockNextClosingEvent) // If this is true, we already sent one out "manually" and don't need to forward SplitView's event
				{
					var eventArgs = make_self<NavigationViewPaneClosingEventArgs>();
					eventArgs.SplitViewClosingArgs(args);
					m_paneClosingEventSource(this, *eventArgs);
					pendingPaneClosingCancel = eventArgs.Cancel();
				}
				else
				{
					m_blockNextClosingEvent = false;
				}
			}

			if (!pendingPaneClosingCancel) // will be set in above event!
			{
				if (var splitView = m_rootSplitView)
        {
					if (var paneList = m_leftNavRepeater)
            {
						if (splitView.DisplayMode() == SplitViewDisplayMode.CompactOverlay || splitView.DisplayMode() == SplitViewDisplayMode.CompactInline)
						{
							// See UpdateIsClosedCompact 'RS3+ animation timing enhancement' for explanation:
							VisualStateManager.GoToState(this, "ListSizeCompact", true /*useTransitions*/);
							UpdatePaneToggleSize();
						}
					}
				}
			}
		}

		void OnSplitViewPaneOpened(DependencyObject /*sender*/, object& obj)
		{
			m_paneOpenedEventSource(this, null);
		}

		void OnSplitViewPaneOpening(DependencyObject /*sender*/, object& obj)
		{
			if (m_leftNavRepeater)
			{
				// See UpdateIsClosedCompact 'RS3+ animation timing enhancement' for explanation:
				VisualStateManager.GoToState(this, "ListSizeFull", true /*useTransitions*/);
			}

			m_paneOpeningEventSource(this, null);
		}

		void UpdateIsClosedCompact()
		{
			if (var splitView = m_rootSplitView)
    {
				// Check if the pane is closed and if the splitview is in either compact mode.
				var splitViewDisplayMode = splitView.DisplayMode();
				m_isClosedCompact = !splitView.IsPaneOpen() && (splitViewDisplayMode == SplitViewDisplayMode.CompactOverlay || splitViewDisplayMode == SplitViewDisplayMode.CompactInline);
				VisualStateManager.GoToState(this, m_isClosedCompact ? "ClosedCompact" : "NotClosedCompact", true /*useTransitions*/);

				// Set the initial state of the list size
				if (!m_initialListSizeStateSet)
				{
					m_initialListSizeStateSet = true;
					VisualStateManager.GoToState(this, m_isClosedCompact ? "ListSizeCompact" : "ListSizeFull", true /*useTransitions*/);
				}
				else if (!SharedHelpers.IsRS3OrHigher()) // Do any changes that would otherwise happen on opening/closing for RS2 and earlier:
				{
					// RS3+ animation timing enhancement:
					// Pre-RS3, we didn't have the full suite of Closed, Closing, Opened,
					// Opening events on SplitView. So when doing open/closed operations,
					// we have to do them immediately. Just one example: on RS2 when you
					// close the pane, the PaneTitle will disappear *immediately* which
					// looks janky. But on RS4, it'll have its visibility set after the
					// closed event fires.
					VisualStateManager.GoToState(this, m_isClosedCompact ? "ListSizeCompact" : "ListSizeFull", true /*useTransitions*/);
				}

				UpdateTitleBarPadding();
				UpdateBackAndCloseButtonsVisibility();
				UpdatePaneTitleMargins();
				UpdatePaneToggleSize();
			}
		}

		void UpdatePaneButtonsWidths()
		{
			var newButtonWidths = [this]()
	

	{
				if (DisplayMode() == NavigationViewDisplayMode.Minimal)
				{
					return (double)(c_paneToggleButtonWidth);
				}
				return CompactPaneLength();
			} ();

			if (var backButton = m_backButton)
    {
				backButton.Width(newButtonWidths);
			}
			if (var paneToggleButton = m_paneToggleButton)
    {
				paneToggleButton.MinWidth(newButtonWidths);
				if (var iconGridColumnElement = paneToggleButton.GetTemplateChild(c_paneToggleButtonIconGridColumnName))
        {
					if (var paneToggleButtonIconColumn = iconGridColumnElement as ColumnDefinition())
            {
						var width = paneToggleButtonIconColumn.Width();
						width.Value = newButtonWidths;
						paneToggleButtonIconColumn.Width(width);
					}
				}
			}
		}

		void OnBackButtonClicked(object& sender, RoutedEventArgs args)
		{
			var eventArgs = make_self<NavigationViewBackRequestedEventArgs>();
			m_backRequestedEventSource(this, *eventArgs);
		}

		bool IsOverlay()
		{
			if (var splitView = m_rootSplitView)
    {
				return splitView.DisplayMode() == SplitViewDisplayMode.Overlay;
			}

	else
			{
				return false;
			}
		}

		bool IsLightDismissible()
		{
			if (var splitView = m_rootSplitView)
    {
				return splitView.DisplayMode() != SplitViewDisplayMode.Inline && splitView.DisplayMode() != SplitViewDisplayMode.CompactInline;
			}

	else
			{
				return false;
			}
		}

		bool ShouldShowBackButton()
		{
			if (m_backButton && !ShouldPreserveNavigationViewRS3Behavior())
			{
				if (DisplayMode() == NavigationViewDisplayMode.Minimal && IsPaneOpen())
				{
					return false;
				}

				return ShouldShowBackOrCloseButton();
			}

			return false;
		}

		bool ShouldShowCloseButton()
		{
			if (m_backButton && !ShouldPreserveNavigationViewRS3Behavior() && m_closeButton)
			{
				if (!IsPaneOpen())
				{
					return false;
				}

				var paneDisplayMode = PaneDisplayMode();

				if (paneDisplayMode != NavigationViewPaneDisplayMode.LeftMinimal &&
					(paneDisplayMode != NavigationViewPaneDisplayMode.Auto || DisplayMode() != NavigationViewDisplayMode.Minimal))
				{
					return false;
				}

				return ShouldShowBackOrCloseButton();
			}

			return false;
		}

		bool ShouldShowBackOrCloseButton()
		{
			var visibility = IsBackButtonVisible();
			return (visibility == NavigationViewBackButtonVisible.Visible || (visibility == NavigationViewBackButtonVisible.Auto && !SharedHelpers.IsOnXbox()));
		}

		// The automation name and tooltip for the pane toggle button changes depending on whether it is open or closed
		// put the logic here as it will be called in a couple places
		void SetPaneToggleButtonAutomationName()
		{
			hstring navigationName;
			if (IsPaneOpen())
			{
				navigationName = ResourceAccessor.GetLocalizedStringResource(SR_NavigationButtonOpenName);
			}
			else
			{
				navigationName = ResourceAccessor.GetLocalizedStringResource(SR_NavigationButtonClosedName);
			}

			if (var paneToggleButton = m_paneToggleButton)
    {
				AutomationProperties.SetName(paneToggleButton, navigationName);
				var toolTip = ToolTip();
				toolTip.ContentnavigationName);
				ToolTipService.SetToolTip(paneToggleButton, toolTip);
			}
		}

		void UpdateSettingsItemToolTip()
		{
			if (var settingsItem = m_settingsItem)
    {
				if (!IsTopNavigationView() && IsPaneOpen())
				{
					ToolTipService.SetToolTip(settingsItem, null);
				}
				else
				{
					var localizedSettingsName = ResourceAccessor.GetLocalizedStringResource(SR_SettingsButtonName);
					var toolTip = ToolTip();
					toolTip.ContentlocalizedSettingsName);
					ToolTipService.SetToolTip(settingsItem, toolTip);
				}
			}
		}

		// Updates the PaneTitleHolder.Visibility and PaneTitleTextBlock.Parent properties based on the PaneDisplayMode, PaneTitle and IsPaneToggleButtonVisible properties.
		void UpdatePaneTitleFrameworkElementParents()
		{
			if (var paneTitleHolderFrameworkElement = m_paneTitleHolderFrameworkElement)
    {
				var isPaneToggleButtonVisible = IsPaneToggleButtonVisible();
				var isTopNavigationView = IsTopNavigationView();

				paneTitleHolderFrameworkElement.Visibility(
					(isPaneToggleButtonVisible ||
						isTopNavigationView ||
						PaneTitle().size() == 0 ||
						(PaneDisplayMode() == NavigationViewPaneDisplayMode.LeftMinimal && !IsPaneOpen())) ?
					Visibility.Collapsed : Visibility.Visible);

				if (var paneTitleFrameworkElement = m_paneTitleFrameworkElement)
        {
					var first = SetPaneTitleFrameworkElementParent(m_paneToggleButton, paneTitleFrameworkElement, isTopNavigationView || !isPaneToggleButtonVisible);
					var second = SetPaneTitleFrameworkElementParent(m_paneTitlePresenter, paneTitleFrameworkElement, isTopNavigationView || isPaneToggleButtonVisible);
					var third = SetPaneTitleFrameworkElementParent(m_paneTitleOnTopPane, paneTitleFrameworkElement, !isTopNavigationView || isPaneToggleButtonVisible);
					first? first() : second? second() : third? third() : []() { } ();
				}
			}
		}

		std.function<void()> SetPaneTitleFrameworkElementParent(ContentControl& parent, FrameworkElement& paneTitle, bool shouldNotContainPaneTitle)
		{
			if (parent)
			{
				if ((parent.Content() == paneTitle) == shouldNotContainPaneTitle)
				{
					if (shouldNotContainPaneTitle)
					{
						parent.Content(null);
					}
					else
					{
						return [parent, paneTitle]() { parent.Content(paneTitle); };
					}
				}
			}
			return null;
		}

		float2 c_frame1point1 = float2(0.9f, 0.1f);
		float2 c_frame1point2 = float2(1.0f, 0.2f);
		float2 c_frame2point1 = float2(0.1f, 0.9f);
		float2 c_frame2point2 = float2(0.2f, 1.0f);

		void AnimateSelectionChangedToItem(object& selectedItem)
		{
			if (selectedItem && !IsSelectionSuppressed(selectedItem))
			{
				AnimateSelectionChanged(selectedItem);
			}
		}

		// Please clear the field m_lastSelectedItemPendingAnimationInTopNav when calling this method to prevent garbage value and incorrect animation
		// when the layout is invalidated as it's called in OnLayoutUpdated.
		void AnimateSelectionChanged(object& nextItem)
		{
			// If we are delaying animation due to item movement in top nav overflow, dont do anything
			if (m_lastSelectedItemPendingAnimationInTopNav)
			{
				return;
			}

			UIElement prevIndicator = m_activeIndicator;
			UIElement nextIndicator = FindSelectionIndicator(nextItem);

			bool haveValidAnimation = false;
			// It's possible that AnimateSelectionChanged is called multiple times before the first animation is complete.
			// To have better user experience, if the selected target is the same, keep the first animation
			// If the selected target is not the same, abort the first animation and launch another animation.
			if (m_prevIndicator || m_nextIndicator) // There is ongoing animation
			{
				if (nextIndicator && m_nextIndicator == nextIndicator) // animate to the same target, just wait for animation complete
				{
					if (prevIndicator && prevIndicator != m_prevIndicator)
					{
						ResetElementAnimationProperties(prevIndicator, 0.0f);
					}
					haveValidAnimation = true;
				}
				else
				{
					// If the last animation is still playing, force it to complete.
					OnAnimationComplete(null, null);
				}
			}

			if (!haveValidAnimation)
			{
				UIElement paneContentGrid = m_paneContentGrid;

				if ((prevIndicator != nextIndicator) && paneContentGrid && prevIndicator && nextIndicator && SharedHelpers.IsAnimationsEnabled())
				{
					// Make sure both indicators are visible and in their original locations
					ResetElementAnimationProperties(prevIndicator, 1.0f);
					ResetElementAnimationProperties(nextIndicator, 1.0f);

					// get the item positions in the pane
					Point point = Point(0, 0);
					float prevPos;
					float nextPos;

					Point prevPosPoint = prevIndicator.TransformToVisual(paneContentGrid).TransformPoint(point);
					Point nextPosPoint = nextIndicator.TransformToVisual(paneContentGrid).TransformPoint(point);
					Size prevSize = prevIndicator.RenderSize();
					Size nextSize = nextIndicator.RenderSize();

					bool areElementsAtSameDepth = false;
					if (IsTopNavigationView())
					{
						prevPos = prevPosPoint.X;
						nextPos = nextPosPoint.X;
						areElementsAtSameDepth = prevPosPoint.Y == nextPosPoint.Y;
					}
					else
					{
						prevPos = prevPosPoint.Y;
						nextPos = nextPosPoint.Y;
						areElementsAtSameDepth = prevPosPoint.X == nextPosPoint.X;
					}

					Visual visual = ElementCompositionPreview.GetElementVisual(this);
					CompositionScopedBatch scopedBatch = visual.Compositor().CreateScopedBatch(CompositionBatchTypes.Animation);

					if (!areElementsAtSameDepth)
					{
						bool isNextBelow = prevPosPoint.Y < nextPosPoint.Y;
						prevIndicator.RenderSize().Height > prevIndicator.RenderSize().Width ?
							PlayIndicatorNonSameLevelAnimations(prevIndicator, true, isNextBelow ? false : true) :
							PlayIndicatorNonSameLevelTopPrimaryAnimation(prevIndicator, true);

						nextIndicator.RenderSize().Height > nextIndicator.RenderSize().Width ?
							PlayIndicatorNonSameLevelAnimations(nextIndicator, false, isNextBelow ? true : false) :
							PlayIndicatorNonSameLevelTopPrimaryAnimation(nextIndicator, false);

					}
					else
					{

						float outgoingEndPosition = (float)(nextPos - prevPos);
						float incomingStartPosition = (float)(prevPos - nextPos);

						// Play the animation on both the previous and next indicators
						PlayIndicatorAnimations(prevIndicator,
							0,
							outgoingEndPosition,
							prevSize,
							nextSize,
							true);
						PlayIndicatorAnimations(nextIndicator,
							incomingStartPosition,
							0,
							prevSize,
							nextSize,
							false);
					}

					scopedBatch.End();
					m_prevIndicator = prevIndicator;
					m_nextIndicator = nextIndicator;

					var strongThis = get_strong();
					scopedBatch.Completed(
	

						[strongThis](var sender, var args)
	

				{
						strongThis.OnAnimationComplete(sender, args);
					});
				}
				else
				{
					// if all else fails, or if animations are turned off, attempt to correctly set the positions and opacities of the indicators.
					ResetElementAnimationProperties(prevIndicator, 0.0f);
					ResetElementAnimationProperties(nextIndicator, 1.0f);
				}

				m_activeIndicator = nextIndicator;
			}
		}

		void PlayIndicatorNonSameLevelAnimations(UIElement& indicator, bool isOutgoing, bool fromTop)
		{
			Visual visual = ElementCompositionPreview.GetElementVisual(indicator);
			Compositor comp = visual.Compositor();

			// Determine scaling of indicator (whether it is appearing or dissapearing)
			float beginScale = isOutgoing ? 1.0f : 0.0f;
			float endScale = isOutgoing ? 0.0f : 1.0f;
			ScalarKeyFrameAnimation scaleAnim = comp.CreateScalarKeyFrameAnimation();
			scaleAnim.InsertKeyFrame(0.0f, beginScale);
			scaleAnim.InsertKeyFrame(1.0f, endScale);
			scaleAnim.Duration(600ms);

			// Determine where the indicator is animating from/to
			Size size = indicator.RenderSize();
			float dimension = IsTopNavigationView() ? size.Width : size.Height;
			float newCenter = fromTop ? 0.0f : dimension;
			var indicatorCenterPoint = visual.CenterPoint();
			indicatorCenterPoint.y = newCenter;
			visual.CenterPoint(indicatorCenterPoint);

			visual.StartAnimation("Scale.Y", scaleAnim);
		}


		void PlayIndicatorNonSameLevelTopPrimaryAnimation(UIElement& indicator, bool isOutgoing)
		{
			Visual visual = ElementCompositionPreview.GetElementVisual(indicator);
			Compositor comp = visual.Compositor();

			// Determine scaling of indicator (whether it is appearing or dissapearing)
			float beginScale = isOutgoing ? 1.0f : 0.0f;
			float endScale = isOutgoing ? 0.0f : 1.0f;
			ScalarKeyFrameAnimation scaleAnim = comp.CreateScalarKeyFrameAnimation();
			scaleAnim.InsertKeyFrame(0.0f, beginScale);
			scaleAnim.InsertKeyFrame(1.0f, endScale);
			scaleAnim.Duration(600ms);

			// Determine where the indicator is animating from/to
			Size size = indicator.RenderSize();
			float newCenter = size.Width / 2;
			var indicatorCenterPoint = visual.CenterPoint();
			indicatorCenterPoint.y = newCenter;
			visual.CenterPoint(indicatorCenterPoint);

			visual.StartAnimation("Scale.X", scaleAnim);
		}

		void PlayIndicatorAnimations(UIElement& indicator, float from, float to, Size beginSize, Size endSize, bool isOutgoing)
		{
			Visual visual = ElementCompositionPreview.GetElementVisual(indicator);
			Compositor comp = visual.Compositor();

			Size size = indicator.RenderSize();
			float dimension = IsTopNavigationView() ? size.Width : size.Height;

			float beginScale = 1.0f;
			float endScale = 1.0f;
			if (IsTopNavigationView() && fabs(size.Width) > 0.001f)
			{
				beginScale = beginSize.Width / size.Width;
				endScale = endSize.Width / size.Width;
			}

			StepEasingFunction singleStep = comp.CreateStepEasingFunction();
			singleStep.IsFinalStepSingleFrame(true);

			if (isOutgoing)
			{
				// fade the outgoing indicator so it looks nice when animating over the scroll area
				ScalarKeyFrameAnimation opacityAnim = comp.CreateScalarKeyFrameAnimation();
				opacityAnim.InsertKeyFrame(0.0f, 1.0);
				opacityAnim.InsertKeyFrame(0.333f, 1.0, singleStep);
				opacityAnim.InsertKeyFrame(1.0f, 0.0, comp.CreateCubicBezierEasingFunction(c_frame2point1, c_frame2point2));
				opacityAnim.Duration(600ms);

				visual.StartAnimation("Opacity", opacityAnim);
			}

			ScalarKeyFrameAnimation posAnim = comp.CreateScalarKeyFrameAnimation();
			posAnim.InsertKeyFrame(0.0f, from < to ? from : (from + (dimension * (beginScale - 1))));
			posAnim.InsertKeyFrame(0.333f, from < to ? (to + (dimension * (endScale - 1))) : to, singleStep);
			posAnim.Duration(600ms);

			ScalarKeyFrameAnimation scaleAnim = comp.CreateScalarKeyFrameAnimation();
			scaleAnim.InsertKeyFrame(0.0f, beginScale);
			scaleAnim.InsertKeyFrame(0.333f, abs(to - from) / dimension + (from < to ? endScale : beginScale), comp.CreateCubicBezierEasingFunction(c_frame1point1, c_frame1point2));
			scaleAnim.InsertKeyFrame(1.0f, endScale, comp.CreateCubicBezierEasingFunction(c_frame2point1, c_frame2point2));
			scaleAnim.Duration(600ms);

			ScalarKeyFrameAnimation centerAnim = comp.CreateScalarKeyFrameAnimation();
			centerAnim.InsertKeyFrame(0.0f, from < to ? 0.0f : dimension);
			centerAnim.InsertKeyFrame(1.0f, from < to ? dimension : 0.0f, singleStep);
			centerAnim.Duration(200ms);

			if (IsTopNavigationView())
			{
				visual.StartAnimation("Offset.X", posAnim);
				visual.StartAnimation("Scale.X", scaleAnim);
				visual.StartAnimation("CenterPoint.X", centerAnim);
			}
			else
			{
				visual.StartAnimation("Offset.Y", posAnim);
				visual.StartAnimation("Scale.Y", scaleAnim);
				visual.StartAnimation("CenterPoint.Y", centerAnim);
			}
		}

		void OnAnimationComplete(object& /*sender*/, CompositionBatchCompletedEventArgs /*args*/)
		{
			var indicator = m_prevIndicator;
			ResetElementAnimationProperties(indicator, 0.0f);
			m_prevIndicator = null;

			indicator = m_nextIndicator;
			ResetElementAnimationProperties(indicator, 1.0f);
			m_nextIndicator = null;
		}

		void ResetElementAnimationProperties(UIElement& element, float desiredOpacity)
		{
			if (element)
			{
				element.Opacity(desiredOpacity);
				if (Visual visual = ElementCompositionPreview.GetElementVisual(element))
        {
					visual.Of = float3(0.0f, 0.0f, 0.0f);
					visual.Scale(float3(1.0f, 1.0f, 1.0f));
					visual.Opacity(desiredOpacity);
				}
			}
		}

		NavigationViewItemBase NavigationViewItemBaseOrSettingsContentFromData(object& data)
		{
			return GetContainerForData<NavigationViewItemBase>(data);
		}

		NavigationViewItem NavigationViewItemOrSettingsContentFromData(object& data)
		{
			return GetContainerForData<NavigationViewItem>(data);
		}

		bool IsSelectionSuppressed(object& item)
		{
			if (item)
			{
				if (var nvi = NavigationViewItemOrSettingsContentFromData(item))
        {
					return !get_self<NavigationViewItem>(nvi).SelectsOnInvoked();
				}
			}

			return false;
		}

		bool ShouldPreserveNavigationViewRS4Behavior()
		{
			// Since RS5, we support topnav
			return !m_topNavGrid;
		}

		bool ShouldPreserveNavigationViewRS3Behavior()
		{
			// Since RS4, we support backbutton
			return !m_backButton;
		}

		UIElement FindSelectionIndicator(object& item)
		{
			if (item)
			{
				if (var container = NavigationViewItemOrSettingsContentFromData(item))
        {
					if (var indicator = get_self<NavigationViewItem>(container).GetSelectionIndicator())
            {
						return indicator;
					}

			else
					{
						// Indicator was not found, so maybe the layout hasn't updated yet.
						// So let's do that now.
						container.UpdateLayout();
						return get_self<NavigationViewItem>(container).GetSelectionIndicator();
					}
				}
			}
			return null;
		}

		void RaiseSelectionChangedEvent(object & nextItem, bool isSettingsItem, NavigationRecommendedTransitionDirection recommendedDirection)
		{
			var eventArgs = make_self<NavigationViewSelectionChangedEventArgs>();
			eventArgs.SelectedItem(nextItem);
			eventArgs.IsSettingsSelected(isSettingsItem);
			if (var container = NavigationViewItemBaseOrSettingsContentFromData(nextItem))
    {
				eventArgs.SelectedItemContainer(container);
			}
			eventArgs.RecommendedNavigationTransitionInfo(CreateNavigationTransitionInfo(recommendedDirection));
			m_selectionChangedEventSource(this, *eventArgs);
		}

		// SelectedItem change can be invoked by API or user's action like clicking. if it's not from API, m_shouldRaiseInvokeItemInSelectionChange would be true
		// If nextItem is selectionsuppressed, we should undo the selection. We didn't undo it OnSelectionChange because we want change by API has the same undo logic.
		void ChangeSelection(object& prevItem, object& nextItem)
		{
			bool isSettingsItem = IsSettingsItem(nextItem);

			if (IsSelectionSuppressed(nextItem))
			{
				// This should not be a common codepath. Only happens if customer passes a 'selectionsuppressed' item via API.
				UndoSelectionAndRevertSelectionTo(prevItem, nextItem);
				RaiseItemInvoked(nextItem, isSettingsItem);
			}
			else
			{
				// Other transition other than default only apply to topnav
				// when clicking overflow on topnav, transition is from bottom
				// otherwise if prevItem is on left side of nextActualItem, transition is from left
				//           if prevItem is on right side of nextActualItem, transition is from right
				// click on Settings item is considered Default
				var recommendedDirection = [this, prevItem, nextItem]()
	

		{
					if (IsTopNavigationView())
					{
						if (m_selectionChangeFromOverflowMenu)
						{
							return NavigationRecommendedTransitionDirection.FromOverflow;
						}
						else if (prevItem && nextItem)
						{
							return GetRecommendedTransitionDirection(NavigationViewItemBaseOrSettingsContentFromData(prevItem),
								NavigationViewItemBaseOrSettingsContentFromData(nextItem));
						}
					}
					return NavigationRecommendedTransitionDirection.Default;
				} ();

				// Bug 17850504, Customer may use NavigationViewItem.IsSelected in ItemInvoke or SelectionChanged Event.
				// To keep the logic the same as RS4, ItemInvoke is before unselect the old item
				// And SelectionChanged is after we selected the new item.
				var selectedItem = SelectedItem();
				if (m_shouldRaiseItemInvokedAfterSelection)
				{
					// If selection changed inside ItemInvoked, the flag does not get said to false and the event get's raised again,so we need to set it to false now!
					m_shouldRaiseItemInvokedAfterSelection = false;
					RaiseItemInvoked(nextItem, isSettingsItem, NavigationViewItemOrSettingsContentFromData(nextItem), recommendedDirection);
				}
				// Selection was modified inside ItemInvoked, skip everything here!
				if (selectedItem != SelectedItem())
				{
					return;
				}
				UnselectPrevItem(prevItem, nextItem);
				ChangeSelectStatusForItem(nextItem, true /*selected*/);

				{
					var scopeGuard = gsl.finally([this]()
	

			{
						m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise = false;
					});

					// Selection changed and we need to notify UIA
					// HOWEVER expand collapse can also trigger if an item can expand/collapse
					// There are multiple cases when selection changes:
					// - Through click on item with no children . No expand/collapse change
					// - Through click on item with children . Expand/collapse change
					// - Through API with item without children . No expand/collapse change
					// - Through API with item with children . No expand/collapse change
					if (!m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise)
					{
						if (AutomationPeer peer = FrameworkElementAutomationPeer.FromElement(this))
                {
							var navViewItemPeer = peer.as< NavigationViewAutomationPeer > ();
							get_self<NavigationViewAutomationPeer>(navViewItemPeer).RaiseSelectionChangedEvent(
								prevItem, nextItem
							);
						}
					}
					}

					RaiseSelectionChangedEvent(nextItem, isSettingsItem, recommendedDirection);
					AnimateSelectionChanged(nextItem);

					if (var nvi = NavigationViewItemOrSettingsContentFromData(nextItem))
        {
						ClosePaneIfNeccessaryAfterItemIsClicked(nvi);
					}
				}
			}

			void UpdateSelectionModelSelection(IndexPath&ip)
{
				var prevIndexPath = m_selectionModel.SelectedIndex();
				m_selectionModel.SelectAt(ip);
				UpdateIsChildSelected(prevIndexPath, ip);
			}

			void UpdateIsChildSelected(IndexPath&prevIP,  IndexPath & nextIP)
{
				if (prevIP && prevIP.GetSize() > 0)
				{
					UpdateIsChildSelectedForIndexPath(prevIP, false /*isChildSelected*/);
				}

				if (nextIP && nextIP.GetSize() > 0)
				{
					UpdateIsChildSelectedForIndexPath(nextIP, true /*isChildSelected*/);
				}
			}

			void UpdateIsChildSelectedForIndexPath(IndexPath&ip, bool isChildSelected)
{
				// Update the isChildSelected property for every container on the IndexPath (with the exception of the actual container pointed to by the indexpath)
				var container = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == c_footerMenuBlockIndex /*inFooter*/);
				// first index is fo mainmenu or footer
				// second is index of item in mainmenu or footer
				// next in menuitem children 
				var index = 2;
				while (container)
				{
					if (var nvi = container as NavigationViewItem())
        {
						nvi.IsChildSelected(isChildSelected);
						if (var nextIR = get_self<NavigationViewItem>(nvi).GetRepeater())
            {
							if (index < ip.GetSize() - 1)
							{
								container = nextIR.TryGetElement(ip.GetAt(index));
								index++;
								continue;
							}
						}
					}
					container = null;
				}
			}

			void RaiseItemInvoked(object &item,
    bool isSettings,
	NavigationViewItemBase &container,
    NavigationRecommendedTransitionDirection recommendedDirection)
{
				var invokedItem = item;
				var invokedContainer = container;

				var eventArgs = make_self<NavigationViewItemInvokedEventArgs>();

				if (container)
				{
					invokedItem = container.Content();
				}
				else
				{
					// InvokedItem is container for Settings, but Content of item for other ListViewItem
					if (!isSettings)
					{
						if (var containerFromData = NavigationViewItemBaseOrSettingsContentFromData(item))
            {
							invokedItem = containerFromData.Content();
							invokedContainer = containerFromData;
						}
					}
					else
					{
						MUX_ASSERT(item);
						invokedContainer = item as NavigationViewItemBase();
						MUX_ASSERT(invokedContainer);
					}
				}
				eventArgs.InvokedItem(invokedItem);
				eventArgs.InvokedItemContainer(invokedContainer);
				eventArgs.IsSettingsInvoked(isSettings);
				eventArgs.RecommendedNavigationTransitionInfo(CreateNavigationTransitionInfo(recommendedDirection));
				m_itemInvokedEventSource(this, *eventArgs);
			}

			// forceSetDisplayMode: On first call to SetDisplayMode, force setting to initial values
			void SetDisplayMode(NavigationViewDisplayMode&displayMode, bool forceSetDisplayMode)
{
				// Need to keep the VisualStateGroup "DisplayModeGroup" updated even if the actual
				// display mode is not changed. This is due to the fact that there can be a transition between
				// 'Minimal' and 'MinimalWithBackButton'.
				UpdateVisualStateForDisplayModeGroup(displayMode);

				if (forceSetDisplayMode || DisplayMode() != displayMode)
				{
					// Update header visibility based on what the new display mode will be
					UpdateHeaderVisibility(displayMode);

					UpdatePaneTabFocusNavigation();

					UpdatePaneToggleSize();

					RaiseDisplayModeChanged(displayMode);
				}
			}

			// To support TopNavigationView, DisplayModeGroup in visualstate(We call it VisualStateDisplayMode) is decoupled with DisplayMode.
			// The VisualStateDisplayMode is the combination of TopNavigationView, DisplayMode, PaneDisplayMode.
			// Here is the mapping:
			//    TopNav . Minimal
			//    PaneDisplayMode.Left || (PaneDisplayMode.Auto && DisplayMode.Expanded) . Expanded
			//    PaneDisplayMode.LeftCompact || (PaneDisplayMode.Auto && DisplayMode.Compact) . Compact
			//    Map others to Minimal or MinimalWithBackButton 
			NavigationViewVisualStateDisplayMode GetVisualStateDisplayMode(NavigationViewDisplayMode&displayMode)
{
				var paneDisplayMode = PaneDisplayMode();

				if (IsTopNavigationView())
				{
					return NavigationViewVisualStateDisplayMode.Minimal;
				}

				if (paneDisplayMode == NavigationViewPaneDisplayMode.Left ||
					(paneDisplayMode == NavigationViewPaneDisplayMode.Auto && displayMode == NavigationViewDisplayMode.Expanded))
				{
					return NavigationViewVisualStateDisplayMode.Expanded;
				}

				if (paneDisplayMode == NavigationViewPaneDisplayMode.LeftCompact ||
					(paneDisplayMode == NavigationViewPaneDisplayMode.Auto && displayMode == NavigationViewDisplayMode.Compact))
				{
					return NavigationViewVisualStateDisplayMode.Compact;
				}

				// In minimal mode, when the NavView is closed, the HeaderContent doesn't have
				// its own dedicated space, and must 'share' the top of the NavView with the 
				// pane toggle button ('hamburger' button) and the back button.
				// When the NavView is open, the close button is taking space instead of the back button.
				if (ShouldShowBackButton() || ShouldShowCloseButton())
				{
					return NavigationViewVisualStateDisplayMode.MinimalWithBackButton;
				}
				else
				{
					return NavigationViewVisualStateDisplayMode.Minimal;
				}
			}

			void UpdateVisualStateForDisplayModeGroup(NavigationViewDisplayMode&displayMode)
{
				if (var splitView = m_rootSplitView)
    {
					var visualStateDisplayMode = GetVisualStateDisplayMode(displayMode);
					var visualStateName = "";
					var splitViewDisplayMode = SplitViewDisplayMode.Overlay;
					var visualStateNameMinimal = "Minimal";

					switch (visualStateDisplayMode)
					{
						case NavigationViewVisualStateDisplayMode.MinimalWithBackButton:
							visualStateName = "MinimalWithBackButton";
							splitViewDisplayMode = SplitViewDisplayMode.Overlay;
							break;
						case NavigationViewVisualStateDisplayMode.Minimal:
							visualStateName = visualStateNameMinimal;
							splitViewDisplayMode = SplitViewDisplayMode.Overlay;
							break;
						case NavigationViewVisualStateDisplayMode.Compact:
							visualStateName = "Compact";
							splitViewDisplayMode = SplitViewDisplayMode.CompactOverlay;
							break;
						case NavigationViewVisualStateDisplayMode.Expanded:
							visualStateName = "Expanded";
							splitViewDisplayMode = SplitViewDisplayMode.CompactInline;
							break;
					}

					// When the pane is made invisible we need to collapse the pane part of the SplitView
					if (!IsPaneVisible())
					{
						splitViewDisplayMode = SplitViewDisplayMode.CompactOverlay;
					}

					var handled = false;
					if (visualStateName == visualStateNameMinimal && IsTopNavigationView())
					{
						// TopNavigationMinimal was introduced in 19H1. We need to fallback to Minimal if the customer uses an older template.
						handled = VisualStateManager.GoToState(this, "TopNavigationMinimal", false /*useTransitions*/);
					}
					if (!handled)
					{
						VisualStateManager.GoToState(this, visualStateName, false /*useTransitions*/);
					}

					// Updating the splitview 'DisplayMode' property in some diplaymodes causes children to be added to the popup root.
					// This causes an exception if the NavigationView is in the popup root itself (as SplitView is trying to add children to the tree while it is being measured).
					// Due to this, we want to defer updating this property for all calls coming from `OnApplyTemplate`to the OnLoaded function.
					if (m_fromOnApplyTemplate)
					{
						m_updateVisualStateForDisplayModeFromOnLoaded = true;
					}
					else
					{
						splitView.DisplayMode(splitViewDisplayMode);
					}
				}
			}

			void OnNavigationViewItemTapped(object&sender,  TappedRoutedEventArgs args)
{
				if (var nvi = sender as NavigationViewItem())
    {
					OnNavigationViewItemInvoked(nvi);
					nvi.Focus(FocusState.Pointer);
					args.Handled(true);
				}
			}

			void OnNavigationViewItemKeyDown(object&sender,  KeyRoutedEventArgs args)
{
				if ((args.OriginalKey() == VirtualKey.GamepadA
					|| args.Key() == VirtualKey.Enter
					|| args.Key() == VirtualKey.Space))
				{
					// Only handle those keys if the key is not being held down!
					if (!args.KeyStatus().WasKeyDown)
					{
						if (var nvi = sender as NavigationViewItem())
            {
							HandleKeyEventForNavigationViewItem(nvi, args);
						}
					}
				}
				else
				{
					if (var nvi = sender as NavigationViewItem())
        {
						HandleKeyEventForNavigationViewItem(nvi, args);
					}
				}
			}

			void HandleKeyEventForNavigationViewItem(NavigationViewItem&nvi,  KeyRoutedEventArgs args)
{
				var key = args.Key();
				switch (key)
				{
					case VirtualKey.Enter:
					case VirtualKey.Space:
						args.Handled(true);
						OnNavigationViewItemInvoked(nvi);
						break;
					case VirtualKey.Home:
						args.Handled(true);
						KeyboardFocusFirstItemFromItem(nvi);
						break;
					case VirtualKey.End:
						args.Handled(true);
						KeyboardFocusLastItemFromItem(nvi);
						break;
					case VirtualKey.Down:
						FocusNextDownItem(nvi, args);
						break;
					case VirtualKey.Up:
						FocusNextUpItem(nvi, args);
						break;
				}
			}

			void FocusNextUpItem(NavigationViewItem&nvi,  KeyRoutedEventArgs args)
{
				if (args.OriginalSource() != nvi)
				{
					return;
				}

				bool shouldHandleFocus = true;
				var nviImpl = get_self<NavigationViewItem>(nvi);
				var nextFocusableElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Up);

				if (var nextFocusableNVI = nextFocusableElement as NavigationViewItem())
    {

					var nextFocusableNVIImpl = get_self<NavigationViewItem>(nextFocusableNVI);

					if (nextFocusableNVIImpl.Depth() == nviImpl.Depth())
					{
						// If we not at the top of the list for our current depth and the item above us has children, check whether we should move focus onto a child
						if (DoesNavigationViewItemHaveChildren(nextFocusableNVI))
						{
							// Focus on last lowest level visible container
							if (var childRepeater = nextFocusableNVIImpl.GetRepeater())
                {
								if (var lastFocusableElement = FocusManager.FindLastFocusableElement(childRepeater))
                    {
									if (var lastFocusableNVI = lastFocusableElement as Control())
                        {
										args.Handled(lastFocusableNVI.Focus(FocusState.Keyboard));
									}
								}

					else
								{
									args.Handled(nextFocusableNVIImpl.Focus(FocusState.Keyboard));
								}

							}
						}
						else
						{
							// Traversing up a list where XYKeyboardFocus will result in correct behavior
							shouldHandleFocus = false;
						}
					}
				}

				// We are at the top of the list, focus on parent
				if (shouldHandleFocus && !args.Handled() && nviImpl.Depth() > 0)
				{
					if (var parentContainer = GetParentNavigationViewItemForContainer(nvi))
        {
						args.Handled(parentContainer.Focus(FocusState.Keyboard));
					}
				}
			}

			// If item has focusable children, move focus to first focusable child, otherise just defer to default XYKeyboardFocus behavior
			void FocusNextDownItem(NavigationViewItem&nvi,  KeyRoutedEventArgs args)
{
				if (args.OriginalSource() != nvi)
				{
					return;
				}

				if (DoesNavigationViewItemHaveChildren(nvi))
				{
					var nviImpl = get_self<NavigationViewItem>(nvi);
					if (var childRepeater = nviImpl.GetRepeater())
        {
						var firstFocusableElement = FocusManager.FindFirstFocusableElement(childRepeater);
						if (var controlFirst = firstFocusableElement as Control())
            {
							args.Handled(controlFirst.Focus(FocusState.Keyboard));
						}
					}
				}
			}

			void KeyboardFocusFirstItemFromItem(NavigationViewItemBase&nvib)
{
				var firstElement = [this, nvib]()

	{
					var parentIR = GetParentRootItemsRepeaterForContainer(nvib);
					return parentIR.TryGetElement(0);
				} ();

				if (var controlFirst = firstElement as Control())
    {
					controlFirst.Focus(FocusState.Keyboard);
				}
			}

			void KeyboardFocusLastItemFromItem(NavigationViewItemBase&nvib)
{
				var parentIR = GetParentRootItemsRepeaterForContainer(nvib);

				if (var itemsSourceView = parentIR.ItemsSourceView())
    {
					var lastIndex = itemsSourceView.Count() - 1;
					if (var lastElement = parentIR.TryGetElement(lastIndex))
        {
						if (var controlLast = lastElement as Control())
            {
							controlLast.Focus(FocusState.Programmatic);
						}
					}
				}
			}

			void OnRepeaterGettingFocus(object&sender,  GettingFocusEventArgs args)
{
				// if focus change was invoked by tab key
				// and there is selected item in ItemsRepeater that gatting focus
				// we should put focus on selected item
				if (m_TabKeyPrecedesFocusChange && args.InputDevice() == FocusInputDeviceKind.Keyboard && m_selectionModel.SelectedIndex())
				{
					if (var oldFocusedElement = args.OldFocusedElement())
        {
						if (var newRootItemsRepeater = sender as ItemsRepeater())
            {
							var isFocusOutsideCurrentRootRepeater = [this, oldFocusedElement, newRootItemsRepeater]()

				{
								bool isFocusOutsideCurrentRootRepeater = true;
								var treeWalkerCursor = oldFocusedElement;

								// check if last focused element was in same root repeater
								while (treeWalkerCursor)
								{
									if (var oldFocusedNavigationItemBase = treeWalkerCursor as NavigationViewItemBase())
                        {
										var oldParentRootRepeater = GetParentRootItemsRepeaterForContainer(oldFocusedNavigationItemBase);
										isFocusOutsideCurrentRootRepeater = oldParentRootRepeater != newRootItemsRepeater;
										break;
									}

									treeWalkerCursor = VisualTreeHelper.GetParent(treeWalkerCursor);
								}

								return isFocusOutsideCurrentRootRepeater;
							} ();

							var rootRepeaterForSelectedItem = [this]()

				{
								if (IsTopNavigationView())
								{
									return m_selectionModel.SelectedIndex().GetAt(0) == c_mainMenuBlockIndex ? m_topNavRepeater : m_topNavFooterMenuRepeater;
								}
								return m_selectionModel.SelectedIndex().GetAt(0) == c_mainMenuBlockIndex ? m_leftNavRepeater : m_leftNavFooterMenuRepeater;
							} ();

							// If focus is coming from outside the root repeater,
							// and selected item is within current repeater
							// we should put focus on selected item
							if (var argsAsIGettingFocusEventArgs2 = args as IGettingFocusEventArgs2())
                {
								if (newRootItemsRepeater == rootRepeaterForSelectedItem && isFocusOutsideCurrentRootRepeater)
								{
									var selectedContainer = GetContainerForIndexPath(m_selectionModel.SelectedIndex(), true /* lastVisible */);
									if (argsAsIGettingFocusEventArgs2.TrySetNewFocusedElement(selectedContainer))
									{
										args.Handled(true);
									}
								}
							}
						}
					}
				}

				m_TabKeyPrecedesFocusChange = false;
			}

			void OnNavigationViewItemOnGotFocus(object&sender, RoutedEventArgs e)
{
				if (var nvi = sender as NavigationViewItem())
    {
					// Achieve selection follows focus behavior
					if (IsNavigationViewListSingleSelectionFollowsFocus())
					{
						// if nvi is already selected we don't need to invoke it again
						// otherwise ItemInvoked fires twice when item was tapped
						// or fired when window gets focus
						if (nvi.SelectsOnInvoked() && !nvi.IsSelected())
						{
							if (IsTopNavigationView())
							{
								if (var parentIR = GetParentItemsRepeaterForContainer(nvi))
                    {
									if (parentIR != m_topNavRepeaterOverflowView)
									{
										OnNavigationViewItemInvoked(nvi);
									}
								}
							}
							else
							{
								OnNavigationViewItemInvoked(nvi);
							}
						}
					}
				}
			}

			void OnSettingsInvoked()
			{
				var settingsItem = m_settingsItem;
				if (settingsItem)
				{
					OnNavigationViewItemInvoked(settingsItem);
				}
			}

			void OnPreviewKeyDown(KeyRoutedEventArgse)
{
				m_TabKeyPrecedesFocusChange = false;
				__super.OnPreviewKeyDown(e);
			}

			void OnKeyDown(KeyRoutedEventArgse)
{
				var eventArgs = e;
				var key = eventArgs.Key();

				bool handled = false;
				m_TabKeyPrecedesFocusChange = false;

				switch (key)
				{
					case VirtualKey.GamepadView:
						if (!IsPaneOpen() && !IsTopNavigationView())
						{
							OpenPane();
							handled = true;
						}
						break;
					case VirtualKey.GoBack:
					case VirtualKey.XButton1:
						if (IsPaneOpen() && IsLightDismissible())
						{
							handled = AttemptClosePaneLightly();
						}
						break;
					case VirtualKey.GamepadLeftShoulder:
						handled = BumperNavigation(-1);
						break;
					case VirtualKey.GamepadRightShoulder:
						handled = BumperNavigation(1);
						break;
					case VirtualKey.Tab:
						// arrow keys navigation through ItemsRepeater don't get here
						// so handle tab key to distinguish between tab focus and arrow focus navigation
						m_TabKeyPrecedesFocusChange = true;
						break;
					case VirtualKey.Left:
						var altState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Menu);
						bool isAltPressed = (altState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;

						if (isAltPressed && IsPaneOpen() && IsLightDismissible())
						{
							handled = AttemptClosePaneLightly();
						}

						break;
				}

				eventArgs.Handled(handled);

				__super.OnKeyDown(e);
			}

			bool BumperNavigation(int offset)
			{
				// By passing an offset indicating direction (ideally 1 or -1, meaning right or left respectively)
				// we'll try to move focus to an item. We won't be moving focus to items in the overflow menu and this won't
				// work on left navigation, only dealing with the top primary list here and only with items that don't have
				// !SelectsOnInvoked set to true. If !SelectsOnInvoked is true, we'll skip the item and try focusing on the next one
				// that meets the conditions, in the same direction.
				var shoulderNavigationEnabledParamValue = ShoulderNavigationEnabled();
				var shoulderNavigationForcedDisabled = (shoulderNavigationEnabledParamValue == NavigationViewShoulderNavigationEnabled.Never);
				var shoulderNavigationOptionalDisabled = (shoulderNavigationEnabledParamValue == NavigationViewShoulderNavigationEnabled.WhenSelectionFollowsFocus
				   && SelectionFollowsFocus() == NavigationViewSelectionFollowsFocus.Disabled);

				if (!IsTopNavigationView()
					|| shoulderNavigationOptionalDisabled
					|| shoulderNavigationForcedDisabled)
				{
					return false;
				}

				var shoulderNavigationSelectionFollowsFocusEnabled = (SelectionFollowsFocus() == NavigationViewSelectionFollowsFocus.Enabled
				   && shoulderNavigationEnabledParamValue == NavigationViewShoulderNavigationEnabled.WhenSelectionFollowsFocus);

				var shoulderNavigationEnabled = (shoulderNavigationSelectionFollowsFocusEnabled
				   || shoulderNavigationEnabledParamValue == NavigationViewShoulderNavigationEnabled.Always);

				if (!shoulderNavigationEnabled)
				{
					return false;
				}

				var item = SelectedItem();

				if (item)
				{
					if (var nvi = NavigationViewItemOrSettingsContentFromData(item))
        {
				var indexPath = GetIndexPathForContainer(nvi);
				var isInFooter = indexPath.GetAt(0) == c_footerMenuBlockIndex;

				var indexInMainList = isInFooter ? -1 : indexPath.GetAt(1);
				var indexInFooter = isInFooter ? indexPath.GetAt(1) : -1;

				var topNavRepeater = m_topNavRepeater;
				var topPrimaryListSize = m_topDataProvider.GetPrimaryListSize();

				var footerRepeater = m_topNavFooterMenuRepeater;
				var footerItemsSize = FooterMenuItems().Size();

				if (IsSettingsVisible())
				{
					footerItemsSize++;
				}

				if (indexInMainList >= 0)
				{

					if (SelectSelectableItemWithOf = indexInMainList, offset, topNavRepeater, topPrimaryListSize)
                {
						return true;
					}

					// No sutable item found in main list so try to select item in footer
					if (offset > 0)
					{
						return SelectSelectableItemWithOf = -1, offset, footerRepeater, footerItemsSize;
					}

					return false;
				}

				if (indexInFooter >= 0)
				{

					if (SelectSelectableItemWithOf = indexInFooter, offset, footerRepeater, footerItemsSize)
                {
						return true;
					}

					// No sutable item found in footer so try to select item in main list
					if (offset < 0)
					{
						return SelectSelectableItemWithOf = topPrimaryListSize, offset, topNavRepeater, topPrimaryListSize;
					}
				}
			}
		}

    return false;
}

	bool SelectSelectableItemWithOf = int startIndex, int offset, ItemsRepeater & repeater, int repeaterCollectionSize
	{
		startIndex += offset;
while (startIndex > -1 && startIndex < repeaterCollectionSize)
{
			var newItem = repeater.TryGetElement(startIndex);
			if (var newNavViewItem = newItem as NavigationViewItem())
        {
				// This is done to skip Separators or other items that are not NavigationViewItems
				if (get_self<NavigationViewItem>(newNavViewItem).SelectsOnInvoked())
				{
					newNavViewItem.IsSelected(true);
					return true;
				}
			}

			startIndex += offset;
		}
return false;
	}

	object MenuItemFromContainer(DependencyObject & container)
	{
		if (container)
		{
			if (var nvib = container as NavigationViewItemBase())
        {
				if (var parentRepeater = GetParentItemsRepeaterForContainer(nvib))
            {
					var containerIndex = parentRepeater.GetElementIndex(nvib);
					if (containerIndex >= 0)
					{
						return GetItemFromIndex(parentRepeater, containerIndex);
					}
				}
			}
		}
		return null;
	}

	DependencyObject ContainerFromMenuItem(object & item)
	{
		if (var data = item)
    {
			return NavigationViewItemBaseOrSettingsContentFromData(item);
		}

		return null;
	}

	void OnTopNavDataSourceChanged(NotifyCollectionChangedEventArgs args)
	{
		CloseTopNavigationViewFlyout();

		// Assume that raw data doesn't change very often for navigationview.
		// So here is a simple implementation and for each data item change, it request a layout change
		// update this in the future if there is performance problem

		// If it's Uninitialized, it means that we didn't start the layout yet.
		if (m_topNavigationMode != TopNavigationViewLayoutState.Uninitialized)
		{
			m_topDataProvider.MoveAllItemsToPrimaryList();
		}

		m_lastSelectedItemPendingAnimationInTopNav = null;
	}

	int GetNavigationViewItemCountInPrimaryList()
	{
		return m_topDataProvider.GetNavigationViewItemCountInPrimaryList();
	}

	int GetNavigationViewItemCountInTopNav()
	{
		return m_topDataProvider.GetNavigationViewItemCountInTopNav();
	}

	SplitView GetSplitView()
	{
		return m_rootSplitView;
	}

	void TopNavigationViewItemContentChanged()
	{
		if (m_appliedTemplate)
		{
			m_topDataProvider.InvalidWidthCache();
			InvalidateMeasure();
		}
	}

	void OnAccessKeyInvoked(object & sender, AccessKeyInvokedEventArgs args)
	{
		if (args.Handled())
		{
			return;
		}

		// For topnav, invoke Morebutton, otherwise togglebutton
		var button = IsTopNavigationView() ? m_topNavOverflowButton : m_paneToggleButton;
		if (button)
		{
			if (var peer = FrameworkElementAutomationPeer.FromElement(button) as ButtonAutomationPeer())
        {
				peer.Invoke();
				args.Handled(true);
			}
		}
	}

	NavigationTransitionInfo CreateNavigationTransitionInfo(NavigationRecommendedTransitionDirection recommendedTransitionDirection)
	{
		// In current implementation, if click is from overflow item, just recommend FromRight Slide animation.
		if (recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromOverflow)
		{
			recommendedTransitionDirection = NavigationRecommendedTransitionDirection.FromRight;
		}

		if ((recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromLeft
			|| recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromRight)
			&& SharedHelpers.IsRS5OrHigher())
		{
			SlideNavigationTransitionInfo sliderNav;
			SlideNavigationTransitionEffect effect =
			   recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromRight ?
			   SlideNavigationTransitionEffect.FromRight :
			   SlideNavigationTransitionEffect.FromLeft;
			// PR 1895355: Bug 17724768: Remove Side-to-Side navigation transition velocity key
			// https://microsoft.visualstudio.com/_git/os/commit/7d58531e69bc8ad1761cff938d8db25f6fb6a841
			// We want to use Effect, but it's not in all os of rs5. as a workaround, we only apply effect to the os which is already remove velocity key.
			if (var sliderNav2 = sliderNav as ISlideNavigationTransitionInfo2())
        {
				sliderNav.Effect(effect);
			}
			return sliderNav;
		}

		else
		{
			EntranceNavigationTransitionInfo defaultInfo;
			return defaultInfo;
		}
	}

	NavigationRecommendedTransitionDirection GetRecommendedTransitionDirection(DependencyObject & prev, DependencyObject & next)
	{
		var recommendedTransitionDirection = NavigationRecommendedTransitionDirection.Default;
		var ir = m_topNavRepeater;

		if (prev && next && ir)
		{
			var prevIndexPath = GetIndexPathForContainer(prev as NavigationViewItemBase());
			var nextIndexPath = GetIndexPathForContainer(next as NavigationViewItemBase());

			var compare = prevIndexPath.CompareTo(nextIndexPath);

			switch (compare)
			{
				case -1:
					recommendedTransitionDirection = NavigationRecommendedTransitionDirection.FromRight;
					break;
				case 1:
					recommendedTransitionDirection = NavigationRecommendedTransitionDirection.FromLeft;
					break;
				default:
					recommendedTransitionDirection = NavigationRecommendedTransitionDirection.Default;
					break;
			}
		}
		return recommendedTransitionDirection;
	}

	NavigationViewTemplateSettings* GetTemplateSettings()
	{
		return get_self<NavigationViewTemplateSettings>(TemplateSettings());
	}

	bool IsNavigationViewListSingleSelectionFollowsFocus()
	{
		return (SelectionFollowsFocus() == NavigationViewSelectionFollowsFocus.Enabled);
	}

	void UpdateSingleSelectionFollowsFocusTemplateSetting()
	{
		GetTemplateSettings().SingleSelectionFollowsFocus(IsNavigationViewListSingleSelectionFollowsFocus());
	}

	void OnMenuItemsSourceCollectionChanged(object&, object&)
	{
		if (!IsTopNavigationView())
		{
			if (var repeater = m_leftNavRepeater)
        {
				repeater.UpdateLayout();
			}
			UpdatePaneLayout();
		}
	}

	void OnSelectedItemPropertyChanged(DependencyPropertyChangedEventArgs args)
	{

		var newItem = args.NewValue();
		var oldItem = args.OldValue();

		ChangeSelection(oldItem, newItem);

		if (m_appliedTemplate && IsTopNavigationView())
		{
			if (!m_layoutUpdatedToken ||
				(newItem && m_topDataProvider.IndexOf(newItem) != itemNotFound && m_topDataProvider.IndexOf(newItem, NavigationViewSplitVectorID.PrimaryList) == itemNotFound)) // selection is in overflow
			{
				InvalidateTopNavPrimaryLayout();
			}
		}
	}

	void SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(object & item)
	{
		SelectedItem(item);
	}

	void ChangeSelectStatusForItem(object & item, bool selected)
	{
		if (var container = NavigationViewItemOrSettingsContentFromData(item))
    {
			// If we unselect an item, ListView doesn't tolerate setting the SelectedItem to null. 
			// Instead we remove IsSelected from the item itself, and it make ListView to unselect it.
			// If we select an item, we follow the unselect to simplify the code.
			container.IsSelected(selected);
		}

	else if (selected)
		{
			// If we are selecting an item and have not found a realized container for it,
			// we may need to manually resolve a container for this in order to update the
			// SelectionModel's selected IndexPath.
			var ip = GetIndexPathOfItem(item);
			if (ip && ip.GetSize() > 0)
			{
				// The SelectedItem property has already been updated. So we want to block any logic from executing
				// in the SelectionModel selection changed callback.
				var scopeGuard = gsl.finally([this]()
		
				{
					m_shouldIgnoreNextSelectionChange = false;
				});
				m_shouldIgnoreNextSelectionChange = true;
				UpdateSelectionModelSelection(ip);
				}
			}
		}

		bool IsSettingsItem(object &item)
{
			bool isSettingsItem = false;
			if (item)
			{
				if (var settingItem = m_settingsItem)
        {
					isSettingsItem = (settingItem == item) || (settingItem.Content() == item);
				}
			}
			return isSettingsItem;
		}

		void UnselectPrevItem(object &prevItem, object &nextItem)
{
			if (prevItem && prevItem != nextItem)
			{
				var scopeGuard = gsl.finally([this, setIgnoreNextSelectionChangeToFalse = !m_shouldIgnoreNextSelectionChange]()
		
		{
					if (setIgnoreNextSelectionChangeToFalse)
					{
						m_shouldIgnoreNextSelectionChange = false;
					}
				});
				m_shouldIgnoreNextSelectionChange = true;
				ChangeSelectStatusForItem(prevItem, false /*selected*/);
				}
			}

			void UndoSelectionAndRevertSelectionTo(object &prevSelectedItem, object &nextItem)
{
				object selectedItem{ null };
				if (prevSelectedItem)
				{
					if (IsSelectionSuppressed(prevSelectedItem))
					{
						AnimateSelectionChanged(null);
					}
					else
					{
						ChangeSelectStatusForItem(prevSelectedItem, true /*selected*/);
						AnimateSelectionChangedToItem(prevSelectedItem);
						selectedItem = prevSelectedItem;
					}
				}
				else
				{
					// Bug 18033309, A SelectsOnInvoked=false item is clicked, if we don't unselect it from listview, the second click will not raise ItemClicked
					// because listview doesn't raise SelectionChange.
					ChangeSelectStatusForItem(nextItem, false /*selected*/);
				}
				SelectedItem(selectedItem);
			}

			void CloseTopNavigationViewFlyout()
			{
				if (var button = m_topNavOverflowButton)
    {
				if (var flyout = button.Flyout())
        {
					flyout.Hide();
				}
			}
		}

		void UpdateVisualState(bool useTransitions)
		{
			if (m_appliedTemplate)
			{
				var box = AutoSuggestBox();
				VisualStateManager.GoToState(this, box ? "AutoSuggestBoxVisible" : "AutoSuggestBoxCollapsed", false /*useTransitions*/);

				bool isVisible = IsSettingsVisible();
				VisualStateManager.GoToState(this, isVisible ? "SettingsVisible" : "SettingsCollapsed", false /*useTransitions*/);

				if (IsTopNavigationView())
				{
					UpdateVisualStateForOverflowButton();
				}
				else
				{
					UpdateLeftNavigationOnlyVisualState(useTransitions);
				}
			}
		}

		void UpdateVisualStateForOverflowButton()
		{
			var state = (OverflowLabelMode() == NavigationViewOverflowLabelMode.MoreLabel) ?
				"OverflowButtonWithLabel" :
				"OverflowButtonNoLabel";
			VisualStateManager.GoToState(this, state, false /* useTransitions*/);
		}

		void UpdateLeftNavigationOnlyVisualState(bool useTransitions)
		{
			bool isToggleButtonVisible = IsPaneToggleButtonVisible();
			VisualStateManager.GoToState(this, isToggleButtonVisible ? "TogglePaneButtonVisible" : "TogglePaneButtonCollapsed", false /*useTransitions*/);
		}

		void InvalidateTopNavPrimaryLayout()
		{
			if (m_appliedTemplate && IsTopNavigationView())
			{
				InvalidateMeasure();
			}
		}

		float MeasureTopNavigationViewDesiredWidth(Size &availableSize)
{
			return LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavGrid, availableSize);
		}

		float MeasureTopNavMenuItemsHostDesiredWidth(Size &availableSize)
{
			return LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavRepeater, availableSize);
		}

		float GetTopNavigationViewActualWidth()
		{
			double width = LayoutUtils.GetActualWidthFor(m_topNavGrid);
			MUX_ASSERT(width < std.numeric_limits<float>.max());
			return (float)(width);
		}

		bool HasTopNavigationViewItemNotInPrimaryList()
		{
			return m_topDataProvider.GetPrimaryListSize() != m_topDataProvider.Size();
		}

		void ResetAndRearrangeTopNavItems(Size &availableSize)
{
			if (HasTopNavigationViewItemNotInPrimaryList())
			{
				m_topDataProvider.MoveAllItemsToPrimaryList();
			}
			ArrangeTopNavItems(availableSize);
		}

		void HandleTopNavigationMeasureOverride(Size &availableSize)
{
			// Determine if TopNav is in Overflow
			if (HasTopNavigationViewItemNotInPrimaryList())
			{
				HandleTopNavigationMeasureOverrideOverflow(availableSize);
			}
			else
			{
				HandleTopNavigationMeasureOverrideNormal(availableSize);
			}

			if (m_topNavigationMode == TopNavigationViewLayoutState.Uninitialized)
			{
				m_topNavigationMode = TopNavigationViewLayoutState.Initialized;
			}
		}

		void HandleTopNavigationMeasureOverrideNormal(Windows.Foundation.Size&availableSize)
{
			var desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
			if (desiredWidth > availableSize.Width)
			{
				ResetAndRearrangeTopNavItems(availableSize);
			}
		}

		void HandleTopNavigationMeasureOverrideOverflow(Windows.Foundation.Size&availableSize)
{
			var desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
			if (desiredWidth > availableSize.Width)
			{
				ShrinkTopNavigationSize(desiredWidth, availableSize);
			}
			else if (desiredWidth < availableSize.Width)
			{
				var fullyRecoverWidth = m_topDataProvider.WidthRequiredToRecoveryAllItemsToPrimary();
				if (availableSize.Width >= desiredWidth + fullyRecoverWidth + m_topNavigationRecoveryGracePeriodWidth)
				{
					// It's possible to recover from Overflow to Normal state, so we restart the MeasureOverride from first step
					ResetAndRearrangeTopNavItems(availableSize);
				}
				else
				{
					var movableItems = FindMovableItemsRecoverToPrimaryList(availableSize.Width - desiredWidth, { }/*includeItems*/);
					m_topDataProvider.MoveItemsToPrimaryList(movableItems);
				}
			}
		}

		void ArrangeTopNavItems(Size &availableSize)
{
			SetOverflowButtonVisibility(Visibility.Collapsed);
			var desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
			if (!(desiredWidth < availableSize.Width))
			{
				// overflow
				SetOverflowButtonVisibility(Visibility.Visible);
				var desiredWidthForOverflowButton = MeasureTopNavigationViewDesiredWidth(c_infSize);

				MUX_ASSERT(desiredWidthForOverflowButton >= desiredWidth);
				m_topDataProvider.OverflowButtonWidth(desiredWidthForOverflowButton - desiredWidth);

				ShrinkTopNavigationSize(desiredWidthForOverflowButton, availableSize);
			}
		}

		void SetOverflowButtonVisibility(Visibility &visibility)
{
			if (visibility != TemplateSettings().OverflowButtonVisibility())
			{
				GetTemplateSettings().OverflowButtonVisibility(visibility);
			}
		}

		void SelectOverflowItem(object &item, IndexPath & ip)
{

			var itemBeingMoved = [item, ip, this]()

	{
				if (ip.GetSize() > 2)
				{
					return GetItemFromIndex(m_topNavRepeaterOverflowView, m_topDataProvider.ConvertOriginalIndexToIndex(ip.GetAt(1)));
				}
				return item;
			} ();

			// Calculate selected overflow item size.
			var selectedOverflowItemIndex = m_topDataProvider.IndexOf(itemBeingMoved);
			MUX_ASSERT(selectedOverflowItemIndex != itemNotFound);
			var selectedOverflowItemWidth = m_topDataProvider.GetWidthForItem(selectedOverflowItemIndex);

			bool needInvalidMeasure = !m_topDataProvider.IsValidWidthForItem(selectedOverflowItemIndex);

			if (!needInvalidMeasure)
			{
				var actualWidth = GetTopNavigationViewActualWidth();
				var desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
				MUX_ASSERT(desiredWidth <= actualWidth);

				// Calculate selected item size
				var selectedItemIndex = itemNotFound;
				var selectedItemWidth = 0.f;
				if (var selectedItem = SelectedItem())
        {
					selectedItemIndex = m_topDataProvider.IndexOf(selectedItem);
					if (selectedItemIndex != itemNotFound)
					{
						selectedItemWidth = m_topDataProvider.GetWidthForItem(selectedItemIndex);
					}
				}

				var widthAtLeastToBeRemoved = desiredWidth + selectedOverflowItemWidth - actualWidth;

				// calculate items to be removed from primary because a overflow item is selected. 
				// SelectedItem is assumed to be removed from primary first, then added it back if it should not be removed
				var itemsToBeRemoved = FindMovableItemsToBeRemovedFromPrimaryList(widthAtLeastToBeRemoved, { } /*excludeItems*/);

				// calculate the size to be removed
				var toBeRemovedItemWidth = m_topDataProvider.CalculateWidthForItems(itemsToBeRemoved);

				var widthAvailableToRecover = toBeRemovedItemWidth - widthAtLeastToBeRemoved;
				var itemsToBeAdded = FindMovableItemsRecoverToPrimaryList(widthAvailableToRecover, { selectedOverflowItemIndex }/*includeItems*/);

				CollectionHelper.unique_push_back(itemsToBeAdded, selectedOverflowItemIndex);

				// Keep track of the item being moved in order to know where to animate selection indicator
				m_lastSelectedItemPendingAnimationInTopNav = itemBeingMoved;
				if (ip && ip.GetSize() > 0)
				{
					for (std.CalculatorList<int>.iterator it = itemsToBeRemoved.begin(); it != itemsToBeRemoved.end(); ++it)
					{
						if (*it == ip.GetAt(1))
						{
							if (var indicator = m_activeIndicator)
                    {
						// If the previously selected item is being moved into overflow, hide its indicator
						// as we will no longer need to animate from its location.
						AnimateSelectionChanged(null);
					}
					break;
				}
			}
		}

		if (m_topDataProvider.HasInvalidWidth(itemsToBeAdded))
		{
			needInvalidMeasure = true;
		}
		else
		{
			// Exchange items between Primary and Overflow
			{
				m_topDataProvider.MoveItemsToPrimaryList(itemsToBeAdded);
				m_topDataProvider.MoveItemsOutOfPrimaryList(itemsToBeRemoved);
			}

			if (NeedRearrangeOfTopElementsAfterOverflowSelectionChanged(selectedOverflowItemIndex))
			{
				needInvalidMeasure = true;
			}

			if (!needInvalidMeasure)
			{
				SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
				InvalidateMeasure();
			}
		}
	}

    // TODO: Verify that this is no longer needed and delete
    if (needInvalidMeasure)
{
	// not all items have known width, need to redo the layout
	m_topDataProvider.MoveAllItemsToPrimaryList();
	SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
	InvalidateTopNavPrimaryLayout();
}
}

bool NeedRearrangeOfTopElementsAfterOverflowSelectionChanged(int selectedOriginalIndex)
{
	bool needRearrange = false;

	var primaryList = m_topDataProvider.GetPrimaryItems();
	var primaryListSize = primaryList.Size();
	var indexInPrimary = m_topDataProvider.ConvertOriginalIndexToIndex(selectedOriginalIndex);
	// We need to verify that through various overflow selection combinations, the primary
	// items have not been put into a state of non-logical item layout (aka not in proper sequence).
	// To verify this, if the newly selected item has items following it in the primary items:
	// - we verify that they are meant to follow the selected item as specified in the original order
	// - we verify that the preceding item is meant to directly precede the selected item in the original order
	// If these two conditions are not met, we move all items to the primary list and trigger a re-arrangement of the items.
	if (indexInPrimary < (int)(primaryListSize - 1))
	{
		var nextIndexInPrimary = indexInPrimary + 1;
		var nextIndexInOriginal = selectedOriginalIndex + 1;
		var prevIndexInOriginal = selectedOriginalIndex - 1;

		// Check whether item preceding the selected is not directly preceding
		// in the original.
		if (indexInPrimary > 0)
		{
			std.CalculatorList<int> prevIndexInVector;
			prevIndexInVector.push_back(nextIndexInPrimary - 1);
			var prevOriginalIndexOfPrevPrimaryItem = m_topDataProvider.ConvertPrimaryIndexToIndex(prevIndexInVector);
			if (prevOriginalIndexOfPrevPrimaryItem.at(0) != prevIndexInOriginal)
			{
				needRearrange = true;
			}
		}


		// Check whether items following the selected item are out of order
		while (!needRearrange && nextIndexInPrimary < (int)(primaryListSize))
		{
			std.CalculatorList<int> nextIndexInVector;
			nextIndexInVector.push_back(nextIndexInPrimary);
			var originalIndex = m_topDataProvider.ConvertPrimaryIndexToIndex(nextIndexInVector);
			if (nextIndexInOriginal != originalIndex.at(0))
			{
				needRearrange = true;
				break;
			}
			nextIndexInPrimary++;
			nextIndexInOriginal++;
		}
	}

	return needRearrange;
}

void ShrinkTopNavigationSize(float desiredWidth, Size & availableSize)
{
	UpdateTopNavigationWidthCache();

	var selectedItemIndex = GetSelectedItemIndex();

	var possibleWidthForPrimaryList = MeasureTopNavMenuItemsHostDesiredWidth(c_infSize) - (desiredWidth - availableSize.Width);
	if (possibleWidthForPrimaryList >= 0)
	{
		// Remove all items which is not visible except first item and selected item.
		var itemToBeRemoved = FindMovableItemsBeyondAvailableWidth(possibleWidthForPrimaryList);
		// should keep at least one item in primary
		KeepAtLeastOneItemInPrimaryList(itemToBeRemoved, true/*shouldKeepFirst*/);
		m_topDataProvider.MoveItemsOutOfPrimaryList(itemToBeRemoved);
	}

	// measure again to make sure SelectedItem is realized
	desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);

	var widthAtLeastToBeRemoved = desiredWidth - availableSize.Width;
	if (widthAtLeastToBeRemoved > 0)
	{
		var itemToBeRemoved = FindMovableItemsToBeRemovedFromPrimaryList(widthAtLeastToBeRemoved, { selectedItemIndex });

// At least one item is kept on primary list
KeepAtLeastOneItemInPrimaryList(itemToBeRemoved, false/*shouldKeepFirst*/);

// There should be no item is virtualized in this step
MUX_ASSERT(!m_topDataProvider.HasInvalidWidth(itemToBeRemoved));
m_topDataProvider.MoveItemsOutOfPrimaryList(itemToBeRemoved);
    }
}

std.CalculatorList<int> FindMovableItemsRecoverToPrimaryList(float availableWidth, std.CalculatorList<int> & includeItems)
{
	std.CalculatorList<int> toBeMoved;

	var size = m_topDataProvider.Size();

	// Included Items take high priority, all of them are included in recovery list
	for (var index : includeItems)
    {
	var width = m_topDataProvider.GetWidthForItem(index);
	toBeMoved.push_back(index);
	availableWidth -= width;
}

int i = 0;
while (i < size && availableWidth > 0)
{
	if (!m_topDataProvider.IsItemInPrimaryList(i) && !CollectionHelper.contains(includeItems, i))
	{
		var width = m_topDataProvider.GetWidthForItem(i);
		if (availableWidth >= width)
		{
			toBeMoved.push_back(i);
			availableWidth -= width;
		}
		else
		{
			break;
		}
	}
	i++;
}
// Keep at one item is not in primary list. Two possible reason: 
//  1, Most likely it's caused by m_topNavigationRecoveryGracePeriod
//  2, virtualization and it doesn't have cached width
if (i == size && !toBeMoved.empty())
{
	toBeMoved.pop_back();
}
return toBeMoved;
}

std.CalculatorList<int> FindMovableItemsToBeRemovedFromPrimaryList(float widthAtLeastToBeRemoved, std.CalculatorList<int> & excludeItems)
{
	std.CalculatorList<int> toBeMoved;

	int i = m_topDataProvider.Size() - 1;
	while (i >= 0 && widthAtLeastToBeRemoved > 0)
	{
		if (m_topDataProvider.IsItemInPrimaryList(i))
		{
			if (!CollectionHelper.contains(excludeItems, i))
			{
				var width = m_topDataProvider.GetWidthForItem(i);
				toBeMoved.push_back(i);
				widthAtLeastToBeRemoved -= width;
			}
		}
		i--;
	}

	return toBeMoved;
}

std.CalculatorList<int> FindMovableItemsBeyondAvailableWidth(float availableWidth)
{
	std.CalculatorList<int> toBeMoved;
	if (var ir = m_topNavRepeater)
    {
	int selectedItemIndexInPrimary = m_topDataProvider.IndexOf(SelectedItem(), NavigationViewSplitVectorID.PrimaryList);
	int size = m_topDataProvider.GetPrimaryListSize();

	float requiredWidth = 0;

	for (int i = 0; i < size; i++)
	{
		if (i != selectedItemIndexInPrimary)
		{
			bool shouldMove = true;
			if (requiredWidth <= availableWidth)
			{
				var container = ir.TryGetElement(i);
				if (container)
				{
					if (var containerAsUIElement = container as UIElement())
                        {
		var width = containerAsUIElement.DesiredSize().Width;
		requiredWidth += width;
		shouldMove = requiredWidth > availableWidth;
	}
}

					else
{
	// item is virtualized but not realized.                    
}
                }

                if (shouldMove)
{
	toBeMoved.push_back(i);
}
            }
        }
    }

    return m_topDataProvider.ConvertPrimaryIndexToIndex(toBeMoved);
}

void KeepAtLeastOneItemInPrimaryList(std.CalculatorList<int>& itemInPrimaryToBeRemoved, bool shouldKeepFirst)
{
	if (!itemInPrimaryToBeRemoved.empty() && (int)(itemInPrimaryToBeRemoved.size()) == m_topDataProvider.GetPrimaryListSize())
	{
		if (shouldKeepFirst)
		{
			itemInPrimaryToBeRemoved.erase(itemInPrimaryToBeRemoved.begin());
		}
		else
		{
			itemInPrimaryToBeRemoved.pop_back();
		}
	}
}

int GetSelectedItemIndex()
{
	return m_topDataProvider.IndexOf(SelectedItem());
}

double GetPaneToggleButtonWidth()
{
	return (double)SharedHelpers.FindInApplicationResources("PaneToggleButtonWidth", c_paneToggleButtonWidth);
}

double GetPaneToggleButtonHeight()
{
	return (double)SharedHelpers.FindInApplicationResources("PaneToggleButtonHeight", c_paneToggleButtonHeight);
}

void UpdateTopNavigationWidthCache()
{
	int size = m_topDataProvider.GetPrimaryListSize();
	if (var ir = m_topNavRepeater)
    {
	for (int i = 0; i < size; i++)
	{
		if (var container = ir.TryGetElement(i))
            {
		if (var containerAsUIElement = container as UIElement())
                {
			var width = containerAsUIElement.DesiredSize().Width;
			m_topDataProvider.UpdateWidthForPrimaryItem(i, width);
		}
	}

			else
	{
		break;
	}
}
    }
}

bool IsTopNavigationView()
{
	return PaneDisplayMode() == NavigationViewPaneDisplayMode.Top;
}

bool IsTopPrimaryListVisible()
{
	return m_topNavRepeater && (TemplateSettings().TopPaneVisibility() == Visibility.Visible);
}

void CoerceToGreaterThanZero(double& value)
{
	// Property coercion for OpenPaneLength, CompactPaneLength, CompactModeThresholdWidth, ExpandedModeThresholdWidth
	value = std.max(value, 0.0);
}

void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
{
	IDependencyProperty property = args.Property();

	if (property == IsPaneOpenProperty)
	{
		OnIsPaneOpenChanged();
		UpdateVisualStateForDisplayModeGroup(DisplayMode());
	}
	else if (property == CompactModeThresholdWidthProperty ||
		property == ExpandedModeThresholdWidthProperty)
	{
		UpdateAdaptiveLayout(ActualWidth());
	}
	else if (property == AlwaysShowHeaderProperty || property == HeaderProperty)
	{
		UpdateHeaderVisibility();
	}
	else if (property == SelectedItemProperty)
	{
		OnSelectedItemPropertyChanged(args);
	}
	else if (property == PaneTitleProperty)
	{
		UpdatePaneTitleFrameworkElementParents();
		UpdateBackAndCloseButtonsVisibility();
		UpdatePaneToggleSize();
	}
	else if (property == IsBackButtonVisibleProperty)
	{
		UpdateBackAndCloseButtonsVisibility();
		UpdateAdaptiveLayout(ActualWidth());
		if (IsTopNavigationView())
		{
			InvalidateTopNavPrimaryLayout();
		}

		if (g_IsTelemetryProviderEnabled && IsBackButtonVisible() == NavigationViewBackButtonVisible.Collapsed)
		{
			//  Explicitly disabling BackUI on NavigationView
			[[gsl.suppress(con.4)]] TraceLoggingWrite(
				g_hTelemetryProvider,
				"NavigationView_DisableBackUI",
				TraceLoggingDescription("Developer explicitly disables the BackUI on NavigationView"));
		}
		// Enabling back button shifts grid instead of resizing, so let's update the layout.
		if (var backButton = m_backButton)
        {
	backButton.UpdateLayout();
}
UpdatePaneLayout();
    }

	else if (property == MenuItemsSourceProperty)
{
	UpdateRepeaterItemsSource(true /*forceSelectionModelUpdate*/);
}
else if (property == MenuItemsProperty)
{
	UpdateRepeaterItemsSource(true /*forceSelectionModelUpdate*/);
}
else if (property == FooterMenuItemsSourceProperty)
{
	UpdateFooterRepeaterItemsSource(true /*sourceCollectionReset*/, true /*sourceCollectionChanged*/);
}
else if (property == FooterMenuItemsProperty)
{
	UpdateFooterRepeaterItemsSource(true /*sourceCollectionReset*/, true /*sourceCollectionChanged*/);
}
else if (property == PaneDisplayModeProperty)
{
	// m_wasForceClosed is set to true because ToggleButton is clicked and Pane is closed.
	// When PaneDisplayMode is changed, reset the force flag to make the Pane can be opened automatically again.
	m_wasForceClosed = false;

	CollapseTopLevelMenuItems(auto_unbox(args.OldValue()));
	UpdatePaneToggleButtonVisibility();
	UpdatePaneDisplayMode(auto_unbox(args.OldValue()), auto_unbox(args.NewValue()));
	UpdatePaneTitleFrameworkElementParents();
	UpdatePaneVisibility();
	UpdateVisualState();
	UpdatePaneButtonsWidths();
}
else if (property == IsPaneVisibleProperty)
{
	UpdatePaneVisibility();
	UpdateVisualStateForDisplayModeGroup(DisplayMode());

	// When NavView is in expaneded mode with fixed window size, setting IsPaneVisible to false doesn't closes the pane
	// We manually close/open it for this case
	if (!IsPaneVisible() && IsPaneOpen())
	{
		ClosePane();
	}

	if (IsPaneVisible() && DisplayMode() == NavigationViewDisplayMode.Expanded && !IsPaneOpen())
	{
		OpenPane();
	}
}
else if (property == OverflowLabelModeProperty)
{
	if (m_appliedTemplate)
	{
		UpdateVisualStateForOverflowButton();
		InvalidateTopNavPrimaryLayout();
	}
}
else if (property == AutoSuggestBoxProperty)
{
	InvalidateTopNavPrimaryLayout();
	if (args.OldValue())
	{
		m_autoSuggestBoxSuggestionChosenRevoker.revoke();
	}
	if (var newAutoSuggestBox = args.NewValue() as AutoSuggestBox())
        {
		m_autoSuggestBoxSuggestionChosenRevoker = newAutoSuggestBox.SuggestionChosen(auto_revoke, { this, &OnAutoSuggestBoxSuggestionChosen });
	}
}
else if (property == SelectionFollowsFocusProperty)
{
	UpdateSingleSelectionFollowsFocusTemplateSetting();
}
else if (property == IsPaneToggleButtonVisibleProperty)
{
	UpdatePaneTitleFrameworkElementParents();
	UpdateBackAndCloseButtonsVisibility();
	UpdatePaneToggleButtonVisibility();
	UpdateVisualState();
}
else if (property == IsSettingsVisibleProperty)
{
	UpdateFooterRepeaterItemsSource(false /*sourceCollectionReset*/, true /*sourceCollectionChanged*/);
}
else if (property == CompactPaneLengthProperty)
{
	// Need to update receiver margins when CompactPaneLength changes
	UpdatePaneShadow();

	// Update pane-button-grid width when pane is closed and we are not in minimal
	UpdatePaneButtonsWidths();
}
else if (property == IsTitleBarAutoPaddingEnabledProperty)
{
	UpdateTitleBarPadding();
}
else if (property == MenuItemTemplateProperty ||
	property == MenuItemTemplateSelectorProperty)
{
	SyncItemTemplates();
}
}

void UpdateNavigationViewItemsFactory()
{
	object newItemTemplate = MenuItemTemplate();
	if (!newItemTemplate)
	{
		newItemTemplate = MenuItemTemplateSelector();
	}
	m_navigationViewItemsFactory.UserElementFactory(newItemTemplate);
}

void SyncItemTemplates()
{
	UpdateNavigationViewItemsFactory();
}

void OnRepeaterLoaded(object & sender, RoutedEventArgs args)
{
	if (var item = SelectedItem())
    {
	if (!IsSelectionSuppressed(item))
	{
		if (var navViewItem = NavigationViewItemOrSettingsContentFromData(item))
            {
			navViewItem.IsSelected(true);
		}
	}
	AnimateSelectionChanged(item);
}
}

// If app is .net app, the lifetime of NavigationView maybe depends on garbage collection.
// Unlike other revoker, TitleBar is in global space and we need to stop receiving changed event when it's unloaded.
// So we do hook it in Loaded and Unhook it in Unloaded
void OnUnloaded(object & sender, RoutedEventArgs args)
{
	m_titleBarMetricsChangedRevoker.revoke();
	m_titleBarIsVisibleChangedRevoker.revoke();
}

void OnLoaded(object & sender, RoutedEventArgs args)
{
	if (m_updateVisualStateForDisplayModeFromOnLoaded)
	{
		m_updateVisualStateForDisplayModeFromOnLoaded = false;
		UpdateVisualStateForDisplayModeGroup(DisplayMode());
	}

	if (var coreTitleBar = m_coreTitleBar)
    {
	m_titleBarMetricsChangedRevoker = coreTitleBar.LayoutMetricsChanged(auto_revoke, { this, &OnTitleBarMetricsChanged });
	m_titleBarIsVisibleChangedRevoker = coreTitleBar.IsVisibleChanged(auto_revoke, { this, &OnTitleBarIsVisibleChanged });
}
// Update pane buttons now since we the CompactPaneLength is actually known now.
UpdatePaneButtonsWidths();
}

void OnIsPaneOpenChanged()
{
	var isPaneOpen = IsPaneOpen();
	if (isPaneOpen && m_wasForceClosed)
	{
		m_wasForceClosed = false; // remove the pane open flag since Pane is opened.
	}
	else if (!m_isOpenPaneForInteraction && !isPaneOpen)
	{
		if (var splitView = m_rootSplitView)
        {
	// splitview.IsPaneOpen and nav.IsPaneOpen is two way binding. If nav.IsPaneOpen=false and splitView.IsPaneOpen=true,
	// then the pane has been closed by API and we treat it as a forced close.
	// If, however, splitView.IsPaneOpen=false, then nav.IsPaneOpen is just following the SplitView here and the pane
	// was closed, for example, due to app window resizing. We don't set the force flag in this situation.
	m_wasForceClosed = splitView.IsPaneOpen();
}

		else
{
	// If there is no SplitView (for example it hasn't been loaded yet) then nav.IsPaneOpen was set directly
	// so we treat it as a closed force.
	m_wasForceClosed = true;
}
    }

    SetPaneToggleButtonAutomationName();
UpdatePaneTabFocusNavigation();
UpdateSettingsItemToolTip();
UpdatePaneTitleFrameworkElementParents();

if (SharedHelpers.IsThemeShadowAvailable())
{
	if (var splitView = m_rootSplitView)
        {
		var displayMode = splitView.DisplayMode();
		var isOverlay = displayMode == SplitViewDisplayMode.Overlay || displayMode == SplitViewDisplayMode.CompactOverlay;
		if (var paneRoot = splitView.Pane())
            {
			var currentTranslation = paneRoot.Translation();
			var translation = float3{ currentTranslation.x, currentTranslation.y, IsPaneOpen() && isOverlay ? c_paneElevationTranslationZ : 0.0f };
			paneRoot.Translation(translation);
		}
	}
}
UpdatePaneButtonsWidths();
}

void UpdatePaneToggleButtonVisibility()
{
	var visible = IsPaneToggleButtonVisible() && !IsTopNavigationView();
	GetTemplateSettings().PaneToggleButtonVisibility(Util.VisibilityFromBool(visible));
}

void UpdatePaneDisplayMode()
{
	if (!m_appliedTemplate)
	{
		return;
	}
	if (!IsTopNavigationView())
	{
		UpdateAdaptiveLayout(ActualWidth(), true /*forceSetDisplayMode*/);

		SwapPaneHeaderContent(m_leftNavPaneHeaderContentBorder, m_paneHeaderOnTopPane, "PaneHeader");
		SwapPaneHeaderContent(m_leftNavPaneCustomContentBorder, m_paneCustomContentOnTopPane, "PaneCustomContent");
		SwapPaneHeaderContent(m_leftNavFooterContentBorder, m_paneFooterOnTopPane, "PaneFooter");

		CreateAndHookEventsToSettings();

		if (UIElement8 thisAsUIElement8 = this)
        {
	if (var paneToggleButton = m_paneToggleButton)
            {
		thisAsUIElement8.KeyTipTarget(paneToggleButton);
	}
}

    }

	else
{
	ClosePane();
	SetDisplayMode(NavigationViewDisplayMode.Minimal, true);

	SwapPaneHeaderContent(m_paneHeaderOnTopPane, m_leftNavPaneHeaderContentBorder, "PaneHeader");
	SwapPaneHeaderContent(m_paneCustomContentOnTopPane, m_leftNavPaneCustomContentBorder, "PaneCustomContent");
	SwapPaneHeaderContent(m_paneFooterOnTopPane, m_leftNavFooterContentBorder, "PaneFooter");

	CreateAndHookEventsToSettings();

	if (UIElement8 thisAsUIElement8 = this)
        {
		if (var topNavOverflowButton = m_topNavOverflowButton)
            {
			thisAsUIElement8.KeyTipTarget(topNavOverflowButton);
		}
	}
}

UpdateContentBindingsForPaneDisplayMode();
UpdateRepeaterItemsSource(false /*forceSelectionModelUpdate*/);
UpdateFooterRepeaterItemsSource(false /*sourceCollectionReset*/, false /*sourceCollectionChanged*/);
if (var selectedItem = SelectedItem())
    {
	m_OrientationChangedPendingAnimation = true;
}
}

void UpdatePaneDisplayMode(NavigationViewPaneDisplayMode oldDisplayMode, NavigationViewPaneDisplayMode newDisplayMode)
{
	if (!m_appliedTemplate)
	{
		return;
	}

	UpdatePaneDisplayMode();

	// For better user experience, We help customer to Open/Close Pane automatically when we switch between LeftMinimal <. Left.
	// From other navigation PaneDisplayMode to LeftMinimal, we expect pane is closed.
	// From LeftMinimal to Left, it is expected the pane is open. For other configurations, this seems counterintuitive.
	// See #1702 and #1787
	if (!IsTopNavigationView())
	{
		if (IsPaneOpen())
		{
			if (newDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal)
			{
				ClosePane();
			}
		}
		else
		{
			if (oldDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal
				&& newDisplayMode == NavigationViewPaneDisplayMode.Left)
			{
				OpenPane();
			}
		}
	}
}

void UpdatePaneVisibility()
{
	var templateSettings = GetTemplateSettings();
	if (IsPaneVisible())
	{
		if (IsTopNavigationView())
		{
			templateSettings.LeftPaneVisibility(Visibility.Collapsed);
			templateSettings.TopPaneVisibility(Visibility.Visible);
		}
		else
		{
			templateSettings.TopPaneVisibility(Visibility.Collapsed);
			templateSettings.LeftPaneVisibility(Visibility.Visible);
		}

		VisualStateManager.GoToState(this, "PaneVisible", false /*useTransitions*/);
	}
	else
	{
		templateSettings.TopPaneVisibility(Visibility.Collapsed);
		templateSettings.LeftPaneVisibility(Visibility.Collapsed);

		VisualStateManager.GoToState(this, "PaneCollapsed", false /*useTransitions*/);
	}
}

void SwapPaneHeaderContent(tracker_ref<ContentControl> newParentTrackRef, tracker_ref<ContentControl> oldParentTrackRef, hstring & propertyPathName)
{
	if (var newParent = newParentTrackRef)
    {
	if (var oldParent = oldParentTrackRef)
        {
		oldParent.ClearValue(ContentControl.ContentProperty());
	}

	SharedHelpers.SetBinding(propertyPathName, newParent, ContentControl.ContentProperty());
}
}

void UpdateContentBindingsForPaneDisplayMode()
{
	UIElement autoSuggestBoxContentControl = null;
	UIElement notControl = null;
	if (!IsTopNavigationView())
	{
		autoSuggestBoxContentControl = m_leftNavPaneAutoSuggestBoxPresenter;
		notControl = m_topNavPaneAutoSuggestBoxPresenter;
	}
	else
	{
		autoSuggestBoxContentControl = m_topNavPaneAutoSuggestBoxPresenter;
		notControl = m_leftNavPaneAutoSuggestBoxPresenter;
	}

	if (autoSuggestBoxContentControl)
	{
		if (notControl)
		{
			notControl.ClearValue(ContentControl.ContentProperty());
		}

		SharedHelpers.SetBinding("AutoSuggestBox", autoSuggestBoxContentControl, ContentControl.ContentProperty());
	}
}

void UpdateHeaderVisibility()
{
	if (!m_appliedTemplate)
	{
		return;
	}

	UpdateHeaderVisibility(DisplayMode());
}

void UpdateHeaderVisibility(NavigationViewDisplayMode displayMode)
{
	// Ignore AlwaysShowHeader property in case DisplayMode is Minimal and it's not Top NavigationView
	bool showHeader = AlwaysShowHeader() || (!IsTopNavigationView() && displayMode == NavigationViewDisplayMode.Minimal);

	// Like bug 17517627, Customer like WallPaper Studio 10 expects a HeaderContent visual even if Header() is null. 
	// App crashes when they have dependency on that visual, but the crash is not directly state that it's a header problem.   
	// NavigationView doesn't use quirk, but we determine the version by themeresource.
	// As a workaround, we 'quirk' it for RS4 or before release. if it's RS4 or before, HeaderVisible is not related to Header().
	// If theme resource is RS5 or later, we will not show header if header is null.
	if (SharedHelpers.IsRS5OrHigher())
	{
		showHeader = Header() && showHeader;
	}
	VisualStateManager.GoToState(this, showHeader ? "HeaderVisible" : "HeaderCollapsed", false /*useTransitions*/);
}

void UpdatePaneTabFocusNavigation()
{
	if (!m_appliedTemplate)
	{
		return;
	}

	if (SharedHelpers.IsRS2OrHigher())
	{
		KeyboardNavigationMode mode = KeyboardNavigationMode.Local;

		if (var splitView = m_rootSplitView)
        {
	// If the pane is open in an overlay (light-dismiss) mode, trap keyboard focus inside the pane
	if (IsPaneOpen() && (splitView.DisplayMode() == SplitViewDisplayMode.Overlay || splitView.DisplayMode() == SplitViewDisplayMode.CompactOverlay))
	{
		mode = KeyboardNavigationMode.Cycle;
	}
}

if (var paneContentGrid = m_paneContentGrid)
        {
	paneContentGrid.TabFocusNavigation(mode);
}
    }
}

void UpdatePaneToggleSize()
{
	if (!ShouldPreserveNavigationViewRS3Behavior())
	{
		if (var splitView = m_rootSplitView)
        {
	double width = GetPaneToggleButtonWidth();
	double togglePaneButtonWidth = width;

	if (ShouldShowBackButton() && splitView.DisplayMode() == SplitViewDisplayMode.Overlay)
	{
		double backButtonWidth = c_backButtonWidth;
		if (var backButton = m_backButton)
                {
			backButtonWidth = backButton.Width();
		}

		width += backButtonWidth;
	}

	if (!m_isClosedCompact && PaneTitle().size() > 0)
	{
		if (splitView.DisplayMode() == SplitViewDisplayMode.Overlay && IsPaneOpen())
		{
			width = OpenPaneLength();
			togglePaneButtonWidth = OpenPaneLength() - ((ShouldShowBackButton() || ShouldShowCloseButton()) ? c_backButtonWidth : 0);
		}
		else if (!(splitView.DisplayMode() == SplitViewDisplayMode.Overlay && !IsPaneOpen()))
		{
			width = OpenPaneLength();
			togglePaneButtonWidth = OpenPaneLength();
		}
	}

	if (var toggleButton = m_paneToggleButton)
            {
		toggleButton.Width(togglePaneButtonWidth);
	}
}
    }
}

void UpdateBackAndCloseButtonsVisibility()
{
	if (!m_appliedTemplate)
	{
		return;
	}

	var shouldShowBackButton = ShouldShowBackButton();
	var backButtonVisibility = Util.VisibilityFromBool(shouldShowBackButton);
	var visualStateDisplayMode = GetVisualStateDisplayMode(DisplayMode());
	bool useLeftPaddingForBackOrCloseButton =
	   (visualStateDisplayMode == NavigationViewVisualStateDisplayMode.Minimal && !IsTopNavigationView()) ||
	   visualStateDisplayMode == NavigationViewVisualStateDisplayMode.MinimalWithBackButton;
	double leftPaddingForBackOrCloseButton = 0.0;
	double paneHeaderPaddingForToggleButton = 0.0;
	double paneHeaderPaddingForCloseButton = 0.0;
	double paneHeaderContentBorderRowMinHeight = 0.0;

	GetTemplateSettings().BackButtonVisibility(backButtonVisibility);

	if (m_paneToggleButton && IsPaneToggleButtonVisible())
	{
		paneHeaderContentBorderRowMinHeight = GetPaneToggleButtonHeight();
		paneHeaderPaddingForToggleButton = GetPaneToggleButtonWidth();

		if (useLeftPaddingForBackOrCloseButton)
		{
			leftPaddingForBackOrCloseButton = paneHeaderPaddingForToggleButton;
		}
	}

	if (var backButton = m_backButton)
    {
	if (ShouldPreserveNavigationViewRS4Behavior())
	{
		backButton.Visibility(backButtonVisibility);
	}

	if (useLeftPaddingForBackOrCloseButton && backButtonVisibility == Visibility.Visible)
	{
		leftPaddingForBackOrCloseButton += backButton.Width();
	}
}

if (var closeButton = m_closeButton)
    {
	var closeButtonVisibility = Util.VisibilityFromBool(ShouldShowCloseButton());

	closeButton.Visibility(closeButtonVisibility);

	if (closeButtonVisibility == Visibility.Visible)
	{
		paneHeaderContentBorderRowMinHeight = std.max(paneHeaderContentBorderRowMinHeight, closeButton.Height());

		if (useLeftPaddingForBackOrCloseButton)
		{
			paneHeaderPaddingForCloseButton = closeButton.Width();
			leftPaddingForBackOrCloseButton += paneHeaderPaddingForCloseButton;
		}
	}
}

if (var contentLeftPadding = m_contentLeftPadding)
    {
	contentLeftPadding.Width(leftPaddingForBackOrCloseButton);
}

if (var paneHeaderToggleButtonColumn = m_paneHeaderToggleButtonColumn)
    {
	// Account for the PaneToggleButton's width in the PaneHeader's placement.
	paneHeaderToggleButtonColumn.Width(GridLengthHelper.FromValueAndType(paneHeaderPaddingForToggleButton, GridUnitType.Pixel));
}

if (var paneHeaderCloseButtonColumn = m_paneHeaderCloseButtonColumn)
    {
	// Account for the CloseButton's width in the PaneHeader's placement.
	paneHeaderCloseButtonColumn.Width(GridLengthHelper.FromValueAndType(paneHeaderPaddingForCloseButton, GridUnitType.Pixel));
}

if (var paneTitleHolderFrameworkElement = m_paneTitleHolderFrameworkElement)
    {
	if (paneHeaderContentBorderRowMinHeight == 0.00 && paneTitleHolderFrameworkElement.Visibility() == Visibility.Visible)
	{
		// Handling the case where the PaneTottleButton is collapsed and the PaneTitle's height needs to push the rest of the NavigationView's UI down.
		paneHeaderContentBorderRowMinHeight = paneTitleHolderFrameworkElement.ActualHeight();
	}
}

if (var paneHeaderContentBorderRow = m_paneHeaderContentBorderRow)
    {
	paneHeaderContentBorderRow.MinHeight(paneHeaderContentBorderRowMinHeight);
}

if (var paneContentGridAsUIE = m_paneContentGrid)
    {
	if (var paneContentGrid = paneContentGridAsUIE as Grid())
        {
		var rowDefs = paneContentGrid.RowDefinitions();

		if (rowDefs.Size() >= c_backButtonRowDefinition)
		{
			var rowDef = rowDefs.GetAt(c_backButtonRowDefinition);

			int backButtonRowHeight = 0;
			if (!IsOverlay() && shouldShowBackButton)
			{
				backButtonRowHeight = c_backButtonHeight;
			}
			else if (ShouldPreserveNavigationViewRS3Behavior())
			{
				// This row represented the height of the hamburger+margin in RS3 and prior
				backButtonRowHeight = c_toggleButtonHeightWhenShouldPreserveNavigationViewRS3Behavior;
			}

			var length = GridLengthHelper.FromPixels(backButtonRowHeight);
			rowDef.Height(length);
		}
	}
}

if (!ShouldPreserveNavigationViewRS4Behavior())
{
	VisualStateManager.GoToState(this, shouldShowBackButton ? "BackButtonVisible" : "BackButtonCollapsed", false /*useTransitions*/);
}
UpdateTitleBarPadding();
}

void UpdatePaneTitleMargins()
{
	if (ShouldPreserveNavigationViewRS4Behavior())
	{
		if (var paneTitleFrameworkElement = m_paneTitleFrameworkElement)
        {
	double width = GetPaneToggleButtonWidth();

	if (ShouldShowBackButton() && IsOverlay())
	{
		width += c_backButtonWidth;
	}

	paneTitleFrameworkElement.Margin({ width, 0, 0, 0 }); // see "Hamburger title" on uni
}
    }
}

void UpdateSelectionForMenuItems()
{
	// Allow customer to set selection by NavigationViewItem.IsSelected.
	// If there are more than two items are set IsSelected=true, the first one is actually selected.
	// If SelectedItem is set, IsSelected is ignored.
	//         <MenuItems>
	//              <NavigationViewItem Content = "Collection" IsSelected = "True" / >
	//         </MenuItems>
	if (!SelectedItem())
	{
		bool foundFirstSelected = false;

		// firstly check Menu items
		if (var menuItems = MenuItems() as IVector<object>())
        {
	foundFirstSelected = UpdateSelectedItemFromMenuItems(menuItems);
}

// then do same for footer items and tell wenever selected item alreadyfound in MenuItems
if (var footerItems = FooterMenuItems() as IVector<object>())
        {
	UpdateSelectedItemFromMenuItems(footerItems, foundFirstSelected);
}
    }
}

bool UpdateSelectedItemFromMenuItems(impl.com_ref<IVector<object>>& menuItems, bool foundFirstSelected)
{
	for (int i = 0; i < (int)(menuItems.Size()); i++)
	{
		if (var item = menuItems.GetAt(i) as NavigationViewItem())
        {
	if (item.IsSelected())
	{
		if (!foundFirstSelected)
		{
			var scopeGuard = gsl.finally([this]()

						{
				m_shouldIgnoreNextSelectionChange = false;
			});
			m_shouldIgnoreNextSelectionChange = true;
			SelectedItem(item);
			foundFirstSelected = true;
			}

				else
			{
				item.IsSelected(false);
			}
		}
	}
}
return foundFirstSelected;
}

void OnTitleBarMetricsChanged(object& /*sender*/, object& /*args*/)
{
	UpdateTitleBarPadding();
}

void OnTitleBarIsVisibleChanged(CoreApplicationViewTitleBar& /*sender*/, object& /*args*/)
{
	UpdateTitleBarPadding();
}

void ClosePaneIfNeccessaryAfterItemIsClicked(NavigationViewItem& selectedContainer)
{
	if (IsPaneOpen() &&
		DisplayMode() != NavigationViewDisplayMode.Expanded &&
		!DoesNavigationViewItemHaveChildren(selectedContainer) &&
		!m_shouldIgnoreNextSelectionChange)
	{
		ClosePane();
	}
}

bool NeedTopPaddingForRS5OrHigher(CoreApplicationViewTitleBar & coreTitleBar)
{
	// Starting on RS5, we will be using the following IsVisible API together with ExtendViewIntoTitleBar
	// to decide whether to try to add top padding or not.
	// We don't add padding when in fullscreen or tablet mode.
	return coreTitleBar.IsVisible() && coreTitleBar.ExtendViewIntoTitleBar()
		&& !IsFullScreenOrTabletMode();
}

void UpdateTitleBarPadding()
{
	if (!m_appliedTemplate)
	{
		return;
	}

	double topPadding = 0;

	if (var coreTitleBar = m_coreTitleBar)
    {
	bool needsTopPadding = false;

	// Do not set a top padding when the IsTitleBarAutoPaddingEnabled property is set to False.
	if (IsTitleBarAutoPaddingEnabled())
	{
		if (ShouldPreserveNavigationViewRS3Behavior())
		{
			needsTopPadding = true;
		}
		else if (ShouldPreserveNavigationViewRS4Behavior())
		{
			// For RS4 apps maintain the behavior that we shipped for RS4.
			// We keep this behavior for app compact purposes.
			needsTopPadding = !coreTitleBar.ExtendViewIntoTitleBar();
		}
		else
		{
			needsTopPadding = NeedTopPaddingForRS5OrHigher(coreTitleBar);
		}
	}

	if (needsTopPadding)
	{
		// Only add extra padding if the NavView is the "root" of the app,
		// but not if the app is expanding into the titlebar
		UIElement root = Window.Current().Content();
		GeneralTransform gt = TransformToVisual(root);
		Point pos = gt.TransformPoint(Point());

		if (pos.Y == 0.0f)
		{
			topPadding = coreTitleBar.Height();
		}
	}

	if (ShouldPreserveNavigationViewRS4Behavior())
	{
		if (var fe = m_togglePaneTopPadding)
            {
			fe.Height(topPadding);
		}

		if (var fe = m_contentPaneTopPadding)
            {
			fe.Height(topPadding);
		}
	}

	var paneTitleHolderFrameworkElement = m_paneTitleHolderFrameworkElement;
	var paneToggleButton = m_paneToggleButton;

	bool setPaneTitleHolderFrameworkElementMargin = paneTitleHolderFrameworkElement && paneTitleHolderFrameworkElement.Visibility() == Visibility.Visible;
	bool setPaneToggleButtonMargin = !setPaneTitleHolderFrameworkElementMargin && paneToggleButton && paneToggleButton.Visibility() == Visibility.Visible;

	if (setPaneTitleHolderFrameworkElementMargin || setPaneToggleButtonMargin)
	{
		var thickness = ThicknessHelper.FromLengths(0, 0, 0, 0);

		if (ShouldShowBackButton())
		{
			if (IsOverlay())
			{
				thickness = ThicknessHelper.FromLengths(c_backButtonWidth, 0, 0, 0);
			}
			else
			{
				thickness = ThicknessHelper.FromLengths(0, c_backButtonHeight, 0, 0);
			}
		}
		else if (ShouldShowCloseButton() && IsOverlay())
		{
			thickness = ThicknessHelper.FromLengths(c_backButtonWidth, 0, 0, 0);
		}

		if (setPaneTitleHolderFrameworkElementMargin)
		{
			// The PaneHeader is hosted by PaneTitlePresenter and PaneTitleHolder.
			paneTitleHolderFrameworkElement.Margin(thickness);
		}
		else
		{
			// The PaneHeader is hosted by PaneToggleButton
			paneToggleButton.Margin(thickness);
		}
	}
}

if (var templateSettings = TemplateSettings())
    {
	// 0.0 and 0.00000000 is not the same in double world. try to reduce the number of TopPadding update event. epsilon is 0.1 here.
	if (fabs(templateSettings.TopPadding() - topPadding) > 0.1)
	{
		GetTemplateSettings().TopPadding(topPadding);
	}
}
}

void OnAutoSuggestBoxSuggestionChosen(AutoSuggestBox& sender, Windows.UI.Xaml.Controls.AutoSuggestBoxSuggestionChosenEventArgs args)
{
	// When in compact or minimal, we want to close pane when an item gets selected.
	if (DisplayMode() != NavigationViewDisplayMode.Expanded && args.SelectedItem() != null)
	{
		ClosePane();
	}
}

void RaiseDisplayModeChanged(NavigationViewDisplayMode& displayMode)
{
	SetValue(DisplayModeProperty, displayMode);
	var eventArgs = make_self<NavigationViewDisplayModeChangedEventArgs>();
	eventArgs.DisplayMode(displayMode);
	m_displayModeChangedEventSource(this, *eventArgs);
}

// This method attaches the series of animations which are fired off dependent upon the amount 
// of space give and the length of the strings involved. It occurs upon re-rendering.
void CreateAndAttachHeaderAnimation(Visual& visual)
{
	var compositor = visual.Compositor();
	var cubicFunction = compositor.CreateCubicBezierEasingFunction({ 0.0f, 0.35f }, { 0.15f, 1.0f });
var moveAnimation = compositor.CreateVector3KeyFrameAnimation();
moveAnimation.Target("Offset");
moveAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", cubicFunction);
moveAnimation.Duration(200ms);

var collection = compositor.CreateImplicitAnimationCollection();
collection.Insert("Offset", moveAnimation);
visual.ImplicitAnimations(collection);
}

bool IsFullScreenOrTabletMode()
{
	// ApplicationView.GetForCurrentView() is an expensive call - make sure to cache the ApplicationView
	if (!m_applicationView)
	{
		m_applicationView = ViewManagement.ApplicationView.GetForCurrentView();
	}

	// UIViewSettings.GetForCurrentView() is an expensive call - make sure to cache the UIViewSettings
	if (!m_uiViewSettings)
	{
		m_uiViewSettings = ViewManagement.UIViewSettings.GetForCurrentView();
	}

	bool isFullScreenMode = m_applicationView.IsFullScreenMode();
	bool isTabletMode = m_uiViewSettings.UserInteractionMode() == ViewManagement.UserInteractionMode.Touch;

	return isFullScreenMode || isTabletMode;
}

void UpdatePaneShadow()
{
	if (SharedHelpers.IsThemeShadowAvailable())
	{
		Canvas shadowReceiver = (Canvas)GetTemplateChild(c_paneShadowReceiverCanvas);
		if (!shadowReceiver)
		{
			shadowReceiver = Canvas();
			shadowReceiver.Name(c_paneShadowReceiverCanvas);

			if (var contentGrid = GetTemplateChildT<Grid>(c_contentGridName, this))
            {
	contentGrid.SetRowSpan(shadowReceiver, contentGrid.RowDefinitions().Size());
	contentGrid.SetRow(shadowReceiver, 0);
	// Only register to columns if those are actually defined
	if (contentGrid.ColumnDefinitions().Size() > 0)
	{
		contentGrid.SetColumn(shadowReceiver, 0);
		contentGrid.SetColumnSpan(shadowReceiver, contentGrid.ColumnDefinitions().Size());
	}
	contentGrid.Children().Append(shadowReceiver);

	ThemeShadow shadow;
	shadow.Receivers().Append(shadowReceiver);
	if (var splitView = m_rootSplitView)
                {
		if (var paneRoot = splitView.Pane())
                    {
			if (var paneRoot_uiElement10 = paneRoot as UIElement10 ())
                        {
				paneRoot_uiElement10.Shadow(shadow);
			}
		}
	}
}
        }


        // Shadow will get clipped if casting on the splitView.Content directly
        // Creating a canvas with negative margins as receiver to allow shadow to be drawn outside the content grid 
        Thickness shadowReceiverMargin = { 0, -c_paneElevationTranslationZ, -c_paneElevationTranslationZ, -c_paneElevationTranslationZ };

// Ensuring shadow is aligned to the left
shadowReceiver.HorizontalAlignment(HorizontalAlignment.Left);

// Ensure shadow is as wide as the pane when it is open
if (DisplayMode() == NavigationViewDisplayMode.Compact)
{
	shadowReceiver.Width(OpenPaneLength());
}
else
{
	shadowReceiver.Width(OpenPaneLength() - shadowReceiverMargin.Right);
}
shadowReceiver.Margin(shadowReceiverMargin);
    }
}

template < typename T > T GetContainerForData(object & data)
{
	if (!data)
	{
		return null;
	}

	if (var nvi = data as T())
    {
		return nvi;
	}

	// First conduct a basic top level search in main menu, which should succeed for a lot of scenarios.
	var mainRepeater = IsTopNavigationView() ? m_topNavRepeater : m_leftNavRepeater;
	var itemIndex = GetIndexFromItem(mainRepeater, data);
	if (itemIndex >= 0)
	{
		if (var container = mainRepeater.TryGetElement(itemIndex))
        {
			return container as T();
		}
	}

	// then look in footer menu
	var footerRepeater = IsTopNavigationView() ? m_topNavFooterMenuRepeater : m_leftNavFooterMenuRepeater;
	itemIndex = GetIndexFromItem(footerRepeater, data);
	if (itemIndex >= 0)
	{
		if (var container = footerRepeater.TryGetElement(itemIndex))
        {
			return container as T();
		}
	}

	// If unsuccessful, unfortunately we are going to have to search through the whole tree
	// TODO: Either fix or remove implementation for TopNav.
	// It may not be required due to top nav rarely having realized children in its default state.
	if (var container = SearchEntireTreeForContainer(mainRepeater, data))
    {
		return container as T();
	}

	if (var container = SearchEntireTreeForContainer(footerRepeater, data))
    {
		return container as T();
	}

	return null;
}

UIElement SearchEntireTreeForContainer(ItemsRepeater& rootRepeater, object& data)
{
	// TODO: Temporary inefficient solution that results in unnecessary time complexity, fix.
	var index = GetIndexFromItem(rootRepeater, data);
	if (index != -1)
	{
		return rootRepeater.TryGetElement(index);
	}

	for (int i = 0; i < GetContainerCountInRepeater(rootRepeater); i++)
	{
		if (var container = rootRepeater.TryGetElement(i))
        {
	if (var nvi = container as NavigationViewItem())
            {
		if (var nviRepeater = get_self<NavigationViewItem>(nvi).GetRepeater())
                {
			if (var foundElement = SearchEntireTreeForContainer(nviRepeater, data))
                    {
				return foundElement;
			}
		}
	}
}
    }
    return null;
}

IndexPath SearchEntireTreeForIndexPath(ItemsRepeater& rootRepeater, object& data, bool isFooterRepeater)
{
	for (int i = 0; i < GetContainerCountInRepeater(rootRepeater); i++)
	{
		if (var container = rootRepeater.TryGetElement(i))
        {
	if (var nvi = container as NavigationViewItem())
            {
		var ip = new IndexPath> (std.vector < int({ isFooterRepeater? c_footerMenuBlockIndex : c_mainMenuBlockIndex, i }));
		if (var indexPath = SearchEntireTreeForIndexPath(nvi, data, ip))
                {
			return indexPath;
		}
	}
}
    }
    return null;
}

// There are two possibilities here if the passed in item has children. Either the children of the passed in container have already been realized,
// in which case we simply just iterate through the children containers, or they have not been realized yet and we have to iterate through the data
// and manually realize each item.
IndexPath SearchEntireTreeForIndexPath(NavigationViewItem& parentContainer, object& data, IndexPath& ip)
{
	bool areChildrenRealized = false;
	if (var childrenRepeater = get_self<NavigationViewItem>(parentContainer).GetRepeater())
    {
	if (DoesRepeaterHaveRealizedContainers(childrenRepeater))
	{
		areChildrenRealized = true;
		for (int i = 0; i < GetContainerCountInRepeater(childrenRepeater); i++)
		{
			if (var container = childrenRepeater.TryGetElement(i))
                {
			if (var nvi = container as NavigationViewItem())
                    {
				var newIndexPath = get_self<IndexPath>(ip).CloneWithChildIndex(i);
				if (nvi.Content() == data)
				{
					return newIndexPath;
				}
				else
				{
					if (var foundIndexPath = SearchEntireTreeForIndexPath(nvi, data, newIndexPath))
                            {
						return foundIndexPath;
					}
				}
			}
		}
	}
}
    }

    //If children are not realized, manually realize and search.
    if (!areChildrenRealized)
{
	if (var childrenData = GetChildren(parentContainer))
        {
		// Get children data in an enumarable form
		var newDataSource = childrenData as ItemsSourceView();
		if (childrenData && !newDataSource)
		{
			newDataSource = ItemsSourceView(childrenData);
		}

		for (int i = 0; i < newDataSource.Count(); i++)
		{
			var newIndexPath = get_self<IndexPath>(ip).CloneWithChildIndex(i);
			var childData = newDataSource.GetAt(i);
			if (childData == data)
			{
				return newIndexPath;
			}
			else
			{
				// Resolve databinding for item and search through that item's children
				if (var nvib = ResolveContainerForItem(childData, i))
                    {
			if (var nvi = nvib as NavigationViewItem())
                        {
				// Process x:bind
				if (var extension = CachedVisualTreeHelpers.GetDataTemplateComponent(nvi))
                            {
					// Clear out old data. 
					extension.Recycle();
					int nextPhase = VirtualizationInfo.PhaseReachedEnd;
					// Run Phase 0
					extension.ProcessBindings(childData, i, 0 /* currentPhase */, nextPhase);

					// TODO: If nextPhase is not -1, ProcessBinding for all the phases
				}

				if (var foundIndexPath = SearchEntireTreeForIndexPath(nvi, data, newIndexPath))
                            {
					return foundIndexPath;
				}

				//TODO: Recycle container!
			}
		}
	}
}
        }
    }

    return null;
}

NavigationViewItemBase ResolveContainerForItem(object& item, int index)
{
	var args = make_self<ElementFactoryGetArgs>();
	args.Data(item);
	args.Index(index);

	if (var container = m_navigationViewItemsFactory.GetElement((ElementFactoryGetArgs)(*args)))
    {
	if (var nvib = container as NavigationViewItemBase())
        {
		return nvib;
	}
}
return null;
}

void RecycleContainer(UIElement& container)
{
	var args = make_self<ElementFactoryRecycleArgs>();
	args.Element(container);
	m_navigationViewItemsFactory.RecycleElement((ElementFactoryRecycleArgs)(*args));
}

int GetContainerCountInRepeater(ItemsRepeater& ir)
{
	if (ir)
	{
		if (var repeaterItemSourceView = ir.ItemsSourceView())
        {
	return repeaterItemSourceView.Count();
}
    }
    return -1;
}

bool DoesRepeaterHaveRealizedContainers(ItemsRepeater& ir)
{
	if (ir)
	{
		if (ir.TryGetElement(0))
		{
			return true;
		}
	}
	return false;
}

int GetIndexFromItem(ItemsRepeater& ir, object& data)
{
	if (ir)
	{
		if (var itemsSourceView = ir.ItemsSourceView())
        {
	return itemsSourceView.IndexOf(data);
}
    }
    return -1;
}

object GetItemFromIndex(ItemsRepeater& ir, int index)
{
	if (ir)
	{
		if (var itemsSourceView = ir.ItemsSourceView())
        {
	return itemsSourceView.GetAt(index);
}
    }
    return null;
}

IndexPath GetIndexPathOfItem(object& data)
{
	if (var nvib = data as NavigationViewItemBase())
    {
	return GetIndexPathForContainer(nvib);
}

// In the databinding scenario, we need to conduct a search where we go through every item,
// realizing it if necessary.
if (IsTopNavigationView())
{
	// First search through primary list
	if (var ip = SearchEntireTreeForIndexPath(m_topNavRepeater, data, false /*isFooterRepeater*/))
        {
		return ip;
	}

	// If item was not located in primary list, search through overflow
	if (var ip = SearchEntireTreeForIndexPath(m_topNavRepeaterOverflowView, data, false /*isFooterRepeater*/))
        {
		return ip;
	}

	// If item was not located in primary list and overflow, search through footer
	if (var ip = SearchEntireTreeForIndexPath(m_topNavFooterMenuRepeater, data, true /*isFooterRepeater*/))
        {
		return ip;
	}
}
else
{
	if (var ip = SearchEntireTreeForIndexPath(m_leftNavRepeater, data, false /*isFooterRepeater*/))
        {
		return ip;
	}

	// If item was not located in primary list, search through footer
	if (var ip = SearchEntireTreeForIndexPath(m_leftNavFooterMenuRepeater, data, true /*isFooterRepeater*/))
        {
		return ip;
	}
}

return new IndexPath> (std.vector < int(0));
}

UIElement GetContainerForIndex(int index, bool inFooter)
{
	if (IsTopNavigationView())
	{
		// Get the repeater that is presenting the first item
		var ir = inFooter ? m_topNavFooterMenuRepeater
			: (m_topDataProvider.IsItemInPrimaryList(index) ? m_topNavRepeater : m_topNavRepeaterOverflowView);

		// Get the index of the item in the repeater
		var irIndex = inFooter ? index : m_topDataProvider.ConvertOriginalIndexToIndex(index);

		// Get the container of the first item
		if (var container = ir.TryGetElement(irIndex))
        {
	return container;
}
    }

	else
{
	if (var container = inFooter ? m_leftNavFooterMenuRepeater.TryGetElement(index)
		: m_leftNavRepeater.TryGetElement(index))
        {
		return container as NavigationViewItemBase();
	}
}
return null;
}

NavigationViewItemBase GetContainerForIndexPath(IndexPath& ip, bool lastVisible)
{
	if (ip && ip.GetSize() > 0)
	{
		if (var container = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == c_footerMenuBlockIndex /*inFooter*/))
        {
	if (lastVisible)
	{
		if (var nvi = container as NavigationViewItem())
                {
			if (!nvi.IsExpanded())
			{
				return nvi;
			}
		}
	}

	// TODO: Fix below for top flyout scenario once the flyout is introduced in the XAML.
	// We want to be able to retrieve containers for items that are in the flyout.
	// This will return null if requesting children containers of
	// items in the primary list, or unrealized items in the overflow popup.
	// However this should not happen.
	return GetContainerForIndexPath(container, ip, lastVisible);
}
    }
    return null;
}


NavigationViewItemBase GetContainerForIndexPath(UIElement& firstContainer, IndexPath& ip, bool lastVisible)
{
	var container = firstContainer;
	if (ip.GetSize() > 2)
	{
		for (int i = 2; i < ip.GetSize(); i++)
		{
			bool succeededGettingNextContainer = false;
			if (var nvi = container as NavigationViewItem())
            {
	if (lastVisible && nvi.IsExpanded() == false)
	{
		return nvi;
	}

	if (var nviRepeater = get_self<NavigationViewItem>(nvi).GetRepeater())
                {
		if (var nextContainer = nviRepeater.TryGetElement(ip.GetAt(i)))
                    {
			container = nextContainer;
			succeededGettingNextContainer = true;
		}
	}
}
// If any of the above checks failed, it means something went wrong and we have an index for a non-existent repeater.
if (!succeededGettingNextContainer)
{
	return null;
}
        }
    }
    return container as NavigationViewItemBase();
}

bool IsContainerTheSelectedItemInTheSelectionModel(NavigationViewItemBase& nvib)
{
	if (var selectedItem = m_selectionModel.SelectedItem())
    {
	var selectedItemContainer = selectedItem as NavigationViewItemBase();
	if (!selectedItemContainer)
	{
		selectedItemContainer = GetContainerForIndexPath(m_selectionModel.SelectedIndex());
	}

	return selectedItemContainer == nvib;
}
return false;
}

ItemsRepeater LeftNavRepeater()
{
	return m_leftNavRepeater;
}

NavigationViewItem GetSelectedContainer()
{
	if (var selectedItem = SelectedItem())
    {
	if (var selectedItemContainer = selectedItem as NavigationViewItem())
        {
		return selectedItemContainer;
	}

		else
	{
		return NavigationViewItemOrSettingsContentFromData(selectedItem);
	}
}
return null;
}

void Expand(NavigationViewItem& item)
{
	ChangeIsExpandedNavigationViewItem(item, true /*isExpanded*/);
}

void Collapse(NavigationViewItem& item)
{
	ChangeIsExpandedNavigationViewItem(item, false /*isExpanded*/);
}

bool DoesNavigationViewItemHaveChildren(NavigationViewItem& nvi)
{
	return nvi.MenuItems().Size() > 0 || nvi.MenuItemsSource() != null || nvi.HasUnrealizedChildren();
}

void ToggleIsExpandedNavigationViewItem(NavigationViewItem& nvi)
{
	ChangeIsExpandedNavigationViewItem(nvi, !nvi.IsExpanded());
}

void ChangeIsExpandedNavigationViewItem(NavigationViewItem& nvi, bool isExpanded)
{
	if (DoesNavigationViewItemHaveChildren(nvi))
	{
		nvi.IsExpanded(isExpanded);
	}
}

NavigationViewItem FindLowestLevelContainerToDisplaySelectionIndicator()
{
	var indexIntoIndex = 1;
	var selectedIndex = m_selectionModel.SelectedIndex();
	if (selectedIndex && selectedIndex.GetSize() > 1)
	{
		if (var container = GetContainerForIndex(selectedIndex.GetAt(indexIntoIndex), selectedIndex.GetAt(0) == c_footerMenuBlockIndex /* inFooter */))
        {
	if (var nvi = container as NavigationViewItem())
            {
		var nviImpl = get_self<NavigationViewItem>(nvi);
		var isRepeaterVisible = nviImpl.IsRepeaterVisible();
		while (nvi && isRepeaterVisible && !nvi.IsSelected() && nvi.IsChildSelected())
		{
			indexIntoIndex++;
			isRepeaterVisible = false;
			if (var repeater = nviImpl.GetRepeater())
                    {
				if (var childContainer = repeater.TryGetElement(selectedIndex.GetAt(indexIntoIndex)))
                        {
					nvi = childContainer as NavigationViewItem();
					nviImpl = get_self<NavigationViewItem>(nvi);
					isRepeaterVisible = nviImpl.IsRepeaterVisible();
				}
			}
		}
		return nvi;
	}
}
    }
    return null;
}

void ShowHideChildrenItemsRepeater(NavigationViewItem& nvi)
{
	var nviImpl = get_self<NavigationViewItem>(nvi);

	nviImpl.ShowHideChildren();

	if (nviImpl.ShouldRepeaterShowInFlyout())
	{
		nvi.IsExpanded() ? m_lastItemExpandedIntoFlyout = nvi) : m_lastItemExpandedIntoFlyout.set(null;
    }

    // If SelectedItem is being hidden/shown, animate SelectionIndicator
    if (!nvi.IsSelected() && nvi.IsChildSelected())
{
	if (!nviImpl.IsRepeaterVisible() && nvi.IsChildSelected())
	{
		AnimateSelectionChanged(nvi);
	}
	else
	{
		AnimateSelectionChanged(FindLowestLevelContainerToDisplaySelectionIndicator());
	}
}

nviImpl.RotateExpandCollapseChevron(nvi.IsExpanded());
}

object GetChildren(NavigationViewItem& nvi)
{
	if (nvi.MenuItems().Size() > 0)
	{
		return nvi.MenuItems();
	}
	return nvi.MenuItemsSource();
}

ItemsRepeater GetChildRepeaterForIndexPath(IndexPath& ip)
{
	if (var container = GetContainerForIndexPath(ip) as NavigationViewItem())
    {
	return get_self<NavigationViewItem>(container).GetRepeater();
}
return null;
}


object GetChildrenForItemInIndexPath(IndexPath& ip, bool forceRealize)
{
	if (ip && ip.GetSize() > 1)
	{
		if (var container = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == c_footerMenuBlockIndex /*inFooter*/))
        {
	return GetChildrenForItemInIndexPath(container, ip, forceRealize);
}
    }
    return null;
}

object GetChildrenForItemInIndexPath(UIElement& firstContainer, IndexPath& ip, bool forceRealize)
{
	var container = firstContainer;
	bool shouldRecycleContainer = false;
	if (ip.GetSize() > 2)
	{
		for (int i = 2; i < ip.GetSize(); i++)
		{
			bool succeededGettingNextContainer = false;
			if (var nvi = container as NavigationViewItem())
            {
	var nextContainerIndex = ip.GetAt(i);
	var nviRepeater = get_self<NavigationViewItem>(nvi).GetRepeater();
	if (nviRepeater && DoesRepeaterHaveRealizedContainers(nviRepeater))
	{
		if (var nextContainer = nviRepeater.TryGetElement(nextContainerIndex))
                    {
			container = nextContainer;
			succeededGettingNextContainer = true;
		}
	}
	else if (forceRealize)
	{
		if (var childrenData = GetChildren(nvi))
                    {
			if (shouldRecycleContainer)
			{
				RecycleContainer(nvi);
				shouldRecycleContainer = false;
			}

			// Get children data in an enumarable form
			var newDataSource = childrenData as ItemsSourceView();
			if (childrenData && !newDataSource)
			{
				newDataSource = ItemsSourceView(childrenData);
			}

			if (var data = newDataSource.GetAt(nextContainerIndex))
                        {
				// Resolve databinding for item and search through that item's children
				if (var nvib = ResolveContainerForItem(data, nextContainerIndex))
                            {
					if (var nextContainer = nvib as NavigationViewItem())
                                {
						// Process x:bind
						if (var extension = CachedVisualTreeHelpers.GetDataTemplateComponent(nextContainer))
                                    {
							// Clear out old data. 
							extension.Recycle();
							int nextPhase = VirtualizationInfo.PhaseReachedEnd;
							// Run Phase 0
							extension.ProcessBindings(data, nextContainerIndex, 0 /* currentPhase */, nextPhase);

							// TODO: If nextPhase is not -1, ProcessBinding for all the phases
						}

						container = nextContainer;
						shouldRecycleContainer = true;
						succeededGettingNextContainer = true;
					}
				}
			}
		}
	}

}
// If any of the above checks failed, it means something went wrong and we have an index for a non-existent repeater.
if (!succeededGettingNextContainer)
{
	return null;
}
        }
    }

    if (var nvi = container as NavigationViewItem())
    {
	var children = GetChildren(nvi);
	if (shouldRecycleContainer)
	{
		RecycleContainer(nvi);
	}
	return children;
}

return null;
}

void CollapseTopLevelMenuItems(NavigationViewPaneDisplayMode oldDisplayMode)
{
	// We want to make sure only top level items are visible when switching pane modes
	if (oldDisplayMode == NavigationViewPaneDisplayMode.Top)
	{
		CollapseMenuItemsInRepeater(m_topNavRepeater);
		CollapseMenuItemsInRepeater(m_topNavRepeaterOverflowView);
	}
	else
	{
		CollapseMenuItemsInRepeater(m_leftNavRepeater);
	}
}

void CollapseMenuItemsInRepeater(ItemsRepeater& ir)
{
	for (int index = 0; index < GetContainerCountInRepeater(ir); index++)
	{
		if (var element = ir.TryGetElement(index))
        {
	if (var nvi = element as NavigationViewItem())
            {
		ChangeIsExpandedNavigationViewItem(nvi, false /*isExpanded*/);
	}
}
    }
}

void RaiseExpandingEvent(NavigationViewItemBase& container)
{
	var eventArgs = make_self<NavigationViewItemExpandingEventArgs>(this);
	eventArgs.ExpandingItemContainer(container);
	m_expandingEventSource(this, *eventArgs);
}

void RaiseCollapsedEvent(NavigationViewItemBase& container)
{
	var eventArgs = make_self<NavigationViewItemCollapsedEventArgs>(this);
	eventArgs.CollapsedItemContainer(container);
	m_collapsedEventSource(this, *eventArgs);
}

bool IsTopLevelItem(NavigationViewItemBase& nvib)
{
	return IsRootItemsRepeater(GetParentItemsRepeaterForContainer(nvib));
}
    }
}
