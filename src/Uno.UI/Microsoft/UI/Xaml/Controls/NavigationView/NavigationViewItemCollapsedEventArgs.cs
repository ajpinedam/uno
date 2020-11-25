namespace Microsoft.UI.Xaml.Controls
{
	/// <summary>
	/// Provides event data for the NavigationViewItem.Collapsed event.
	/// </summary>
	public partial class NavigationViewItemCollapsedEventArgs
    {
		internal NavigationViewItemCollapsedEventArgs(
			object collapsedItem,
			NavigationViewItemBase collapsedItemContainer)
		{
			CollapsedItem = collapsedItem;
			CollapsedItemContainer = collapsedItemContainer;
		}

		/// <summary>
		/// Gets the object that has been collapsed after
		/// the NavigationViewItem.Collapsed event.
		/// </summary>
		public object CollapsedItem { get; }

		/// <summary>
		/// Gets the container of the object that was collapsed
		/// in the NavigationViewItem.Collapsed event.
		/// </summary>
		public NavigationViewItemBase CollapsedItemContainer { get; }
	}
}
