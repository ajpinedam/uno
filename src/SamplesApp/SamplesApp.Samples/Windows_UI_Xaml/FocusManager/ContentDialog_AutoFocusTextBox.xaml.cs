using System;
using Uno.UI.Samples.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace UITests.Windows_UI_Xaml.FocusTests;

[Sample("Focus", "Dialogs",
	Name = "ContentDialog_AutoFocusTextBox",
	Description = "Issue #22258: a ContentDialog whose first focusable control is a TextBox should pop the soft keyboard on open (WASM Skia / iOS Safari).",
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
		// The first TextBox is the first focusable element, so the dialog auto-focuses it on
		// open (the #22258 repro). The second TextBox exists so the issue's workaround can be
		// performed: tap the second box, then tap back to the first — the keyboard then opens.
		var dialog = new ContentDialog
		{
			XamlRoot = XamlRoot,
			Title = "Auto-focus TextBox",
			Content = new StackPanel
			{
				Spacing = 8,
				Children =
				{
					new TextBox { PlaceholderText = "First (auto-focused) — keyboard should open automatically" },
					new TextBox { PlaceholderText = "Second — tap here, then tap back to validate the workaround" },
				},
			},
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
			Content = new StackPanel
			{
				Spacing = 8,
				Children =
				{
					new PasswordBox { PlaceholderText = "First (auto-focused) — keyboard should open automatically" },
					new TextBox { PlaceholderText = "Second — tap here, then tap back to validate the workaround" },
				},
			},
			PrimaryButtonText = "OK",
			CloseButtonText = "Cancel",
		};

		await dialog.ShowAsync();
	}
}
