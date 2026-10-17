using System;
using Uno.UI.Samples.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace UITests.Windows_UI_Xaml.FocusTests;

[Sample("Focus", "Dialogs",
	Name = "ContentDialog_AutoFocusTextBox",
	Description = "Issue #22258: when a ContentDialog auto-focuses a TextBox/PasswordBox on open, the soft keyboard should appear (WASM Skia / iOS Safari). A dialog with no text input must NOT open the keyboard.",
	IsManualTest = true,
	IgnoreInSnapshotTests = true)]
public sealed partial class ContentDialog_AutoFocusTextBox : Page
{
	public ContentDialog_AutoFocusTextBox()
	{
		this.InitializeComponent();
	}

	private async void OnShowTextBoxDialog(object sender, RoutedEventArgs e)
	{
		var dialog = new ContentDialog
		{
			XamlRoot = XamlRoot,
			Title = "Auto-focus TextBox",
			Content = new TextBox { PlaceholderText = "Keyboard should open automatically" },
			PrimaryButtonText = "OK",
			CloseButtonText = "Cancel",
		};

		await dialog.ShowAsync();
	}

	private async void OnShowPasswordDialog(object sender, RoutedEventArgs e)
	{
		var dialog = new ContentDialog
		{
			XamlRoot = XamlRoot,
			Title = "Auto-focus PasswordBox",
			Content = new PasswordBox { PlaceholderText = "Keyboard should open automatically" },
			PrimaryButtonText = "OK",
			CloseButtonText = "Cancel",
		};

		await dialog.ShowAsync();
	}

	private async void OnShowButtonsOnlyDialog(object sender, RoutedEventArgs e)
	{
		// No text input — the first focusable is a button. The soft keyboard must NOT appear.
		var dialog = new ContentDialog
		{
			XamlRoot = XamlRoot,
			Title = "No text input",
			Content = new TextBlock { Text = "This dialog has no text input. The soft keyboard should not open." },
			PrimaryButtonText = "OK",
			CloseButtonText = "Cancel",
		};

		await dialog.ShowAsync();
	}
}
