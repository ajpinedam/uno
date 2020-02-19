using SampleControl.Presentation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SamplesApp
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();


			///Content = new TextBlock() { Text= "Hello macOS!", FontSize = 72, Margin = new Thickness(12) };
			//, 
			Content = new TextBox() {  PlaceholderText = "Hello macOS!", FontSize = 72, Margin = new Thickness(12), Height=100, Background = SolidColorBrushHelper.White };
		}
	}
}
