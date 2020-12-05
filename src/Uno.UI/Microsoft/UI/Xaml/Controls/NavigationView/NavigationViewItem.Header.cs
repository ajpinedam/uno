using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.Disposables;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class NavigationViewItem
	{
		internal SerialDisposable EventRevoker { get; } = new SerialDisposable();

		internal ItemsRepeater GetRepeater() { return m_repeater; }

		private readonly SerialDisposable m_splitViewIsPaneOpenChangedRevoker = null;
		private readonly SerialDisposable m_splitViewDisplayModeChangedRevoker = null;
		private readonly SerialDisposable m_splitViewCompactPaneLengthChangedRevoker = null;

		private readonly SerialDisposable m_presenterPointerPressedRevoker = null;
		private readonly SerialDisposable m_presenterPointerEnteredRevoker = null;
		private readonly SerialDisposable m_presenterPointerMovedRevoker = null;
		private readonly SerialDisposable m_presenterPointerReleasedRevoker = null;
		private readonly SerialDisposable m_presenterPointerExitedRevoker = null;
		private readonly SerialDisposable m_presenterPointerCanceledRevoker = null;
		private readonly SerialDisposable m_presenterPointerCaptureLostRevoker = null;

		private readonly SerialDisposable m_repeaterElementPreparedRevoker = null;
		private readonly SerialDisposable m_repeaterElementClearingRevoker = null;
		private readonly SerialDisposable m_itemsSourceViewCollectionChangedRevoker = null;

		private readonly SerialDisposable m_flyoutClosingRevoker = null;
		private readonly SerialDisposable m_isEnabledChangedRevoker = null;

		private ToolTip m_toolTip = null;
		private NavigationViewItemHelper<NavigationViewItem> m_helper = null;
		private NavigationViewItemPresenter m_navigationViewItemPresenter = null;
		private object m_suggestedToolTipContent = null;
		private ItemsRepeater m_repeater = null;
		private Grid m_flyoutContentGrid = null;
		private Grid m_rootGrid = null;

		private bool m_isClosedCompact = false;

		private bool m_appliedTemplate = false;
		private bool m_hasKeyboardFocus = false;

		// Visual state tracking
		private Pointer m_capturedPointer = null;
		private uint m_trackedPointerId = 0;
		private bool m_isPressed = false;
		private bool m_isPointerOver = false;

		private bool m_isRepeaterParentedToFlyout = false;
	}
}
