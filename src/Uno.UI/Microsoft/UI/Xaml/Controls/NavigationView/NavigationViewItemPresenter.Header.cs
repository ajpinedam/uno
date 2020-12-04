using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls.Primitives
{
	public partial class NavigationViewItemPresenter
	{
		private double m_compactPaneLengthValue = 40;

		private NavigationViewItemHelper<NavigationViewItemPresenter> m_helper = this;

		private Grid m_contentGrid = this;
		private Grid m_expandCollapseChevron = this;

		winrt::event_token m_expandCollapseChevronTappedToken { };

		private double m_leftIndentation = 0;

		private Storyboard m_chevronExpandedStoryboard = null;
		private Storyboard m_chevronCollapsedStoryboard = null;
	}
}
