#if HAS_UNO_WINUI
using Microsoft.UI.Xaml.Automation.Peers;
#else
using Windows.UI.Xaml.Automation.Peers;
#endif

namespace Windows.UI.Xaml.Controls
{
	public partial class NavigationViewItemAutomationPeer : ListViewItemAutomationPeer
	{
		public NavigationViewItemAutomationPeer( global::Windows.UI.Xaml.Controls.NavigationViewItem owner) : base(owner)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.NavigationViewItemAutomationPeer", "NavigationViewItemAutomationPeer.NavigationViewItemAutomationPeer(NavigationViewItem owner)");
		}
	}
}
