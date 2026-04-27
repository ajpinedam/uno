using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers;
using Uno.UI.Samples.Controls;
using Windows.Media.Capture;

namespace UITests.Windows_Media;

[Sample(
	"CameraCapture",
	IsManualTest = true,
	Description = "iPad regression repro: after CameraCaptureUI.CaptureFileAsync dismisses (cancel or photo taken), tap input on the underlying page is dead while scrolling still works. Test buttons should each log a tap; if their counter never increments after dismiss but the list still scrolls, the bug is reproduced. iOS/Android only.")]
public sealed partial class CameraCaptureUI_InputAfterDismiss : Page
{
	private int _totalTaps;

	public CameraCaptureUI_InputAfterDismiss()
	{
		this.InitializeComponent();
	}

	private bool IsTargetSupported() =>
#if HAS_UNO
		DeviceTargetHelper.IsMobile();
#else
		true;
#endif

	private async void OpenCamera_Click(object sender, RoutedEventArgs e)
	{
		if (!IsTargetSupported())
		{
			StatusText.Text = "Status: CameraCaptureUI is only supported on iOS, Android, and WinUI.";
			return;
		}

		StatusText.Text = "Status: opening camera…";

		try
		{
			var captureUI = new CameraCaptureUI();
			captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

			var file = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

			StatusText.Text = file is null
				? "Status: camera dismissed (cancelled). Now tap the test buttons. iPad bug: taps will not register; scroll still works."
				: $"Status: photo captured ({file.Path}). Now tap the test buttons. iPad bug: taps will not register; scroll still works.";
		}
		catch (Exception ex)
		{
			StatusText.Text = $"Status: error — {ex.Message}";
		}
	}

	private void TestButton_Click(object sender, RoutedEventArgs e)
	{
		_totalTaps++;
		var tag = (sender as Button)?.Tag?.ToString() ?? "?";
		TapCountText.Text = $"Total taps registered: {_totalTaps} (last: button {tag})";
	}

	private void Reset_Click(object sender, RoutedEventArgs e)
	{
		_totalTaps = 0;
		TapCountText.Text = "Total taps registered: 0";
		StatusText.Text = "Status: ready. Open the camera, then tap test buttons after dismiss.";
	}
}
