namespace Microsoft.UI.Xaml.Controls
{
	/// <summary>
	/// Provides event data for the NavigationViewItem.Expanding event.
	/// </summary>
	public partial class NavigationViewItemExpandingEventArgs
    {
		internal NavigationViewItemExpandingEventArgs(
			object expandingItem,
			NavigationViewItemBase expandingItemContainer)
		{
			ExpandingItem = expandingItem;
			ExpandingItemContainer = expandingItemContainer;
		}

		/// <summary>
		/// Gets the object that is expanding after the NavigationViewItem.Expanding event.
		/// </summary>
		public object ExpandingItem { get; }

		/// <summary>
		/// Gets the container of the expanding item after a NavigationViewItem.Expanding event.
		/// </summary>
		public NavigationViewItemBase ExpandingItemContainer { get; }
	}
}
