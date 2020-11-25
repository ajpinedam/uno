namespace Microsoft.UI.Xaml.Controls
{
	/// <summary>
	/// Provides data for the NavigationView.PaneClosing event.
	/// </summary>
	public partial class NavigationViewPaneClosingEventArgs
    {
		internal NavigationViewPaneClosingEventArgs()
		{
		}

		/// <summary>
		/// Gets or sets a value that indicates whether
		/// the event should be canceled.
		/// </summary>
		public bool Cancel { get; set; }
	}
}
