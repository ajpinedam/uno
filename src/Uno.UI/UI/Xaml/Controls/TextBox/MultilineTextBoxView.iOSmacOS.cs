using CoreGraphics;
using System;
using Uno.Extensions;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Uno.UI.Controls;
using Uno.UI.Extensions;

#if __IOS__
using UIKit;
using _TextView = UIKit.UITextView;
#elif __MACOS__
using AppKit;
using _TextView = AppKit.NSTextView;
#endif

namespace Windows.UI.Xaml.Controls
{
	public partial class MultilineTextBoxView : _TextView, ITextBoxView, DependencyObject, IFontScalable, IUIScrollView
	{
		private MultilineTextBoxDelegate _delegate;
		private readonly WeakReference<TextBox> _textBox;
		private WeakReference<Uno.UI.Controls.Window> _window;

#if __IOS__
		CGPoint IUIScrollView.UpperScrollLimit { get { return (CGPoint)( ContentSize - Frame.Size); } }
#elif __MACOS__
		CGPoint IUIScrollView.UpperScrollLimit { get { return (CGPoint)(this.TextContainer.ContainerSize - Frame.Size); } }
#endif

		public MultilineTextBoxView(TextBox textBox)
		{
			_textBox = new WeakReference<TextBox>(textBox);
			_window = new WeakReference<Uno.UI.Controls.Window>(textBox.FindFirstParent<Uno.UI.Controls.Window>());
			InitializeBinder();
			Initialize();
		}

		private void Initialize()
		{
			Delegate = _delegate = new MultilineTextBoxDelegate(_textBox);

#if __IOS__
			BackgroundColor = UIColor.Clear;
#elif __MACOS__
			BackgroundColor = NSColor.Clear;
#endif

			TextContainer.LineFragmentPadding = 0;
		}

#if __IOS__
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				// The native control will ignore a value of null and retain an empty string. We coalesce the null to prevent a spurious empty string getting bounced back via two-way binding.
				value = value ?? string.Empty;
				if (base.Text != value)
				{
					base.Text = value;
					OnTextChanged();
				}
			}
		}
#elif __MACOS__
		public string Text
		{
			get
			{
				return base.Value;
			}
			set
			{
				// The native control will ignore a value of null and retain an empty string. We coalesce the null to prevent a spurious empty string getting bounced back via two-way binding.
				value = value ?? string.Empty;
				if (base.Value != value)
				{
					base.Value = value;
					OnTextChanged();
				}
			}
		}
#endif

		public void SetTextNative(string text) => Text = text;

		internal void OnTextChanged()
		{
			var textBox = _textBox?.GetTarget();
			if (textBox != null)
			{
				var text = textBox.ProcessTextInput(Text);
				SetTextNative(text);
			}

#if __IOS__
			SetNeedsLayout();
#elif __MACOS__
			NeedsLayout = true;
#endif

			//We need to schedule the scrolling on the dispatcher so that we wait for the whole UI to be done before scrolling.
			//Because the multiline must have its height set so we can set properly the scrollviewer insets

			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, () => ScrollToCursor() );
		}

		internal void ScrollToCursor()
		{
			var window = _window.GetTarget();

			if (window == null)
			{
				// TextBox may not yet have been attached to window when it was templated
				window = _textBox.GetTarget().FindFirstParent<Uno.UI.Controls.Window>();
				_window = new WeakReference<Uno.UI.Controls.Window>(window);
			}
			
#if __IOS__

			if (this.IsFirstResponder)
			{
				window.MakeVisible(this, BringIntoViewMode.BottomRightOfViewPort);
			}
#elif __MACOS__
			window.MakeVisible(this, BringIntoViewMode.BottomRightOfViewPort);
#endif

		}



#if __IOS__
		public override CGSize SizeThatFits(CGSize size)
		{
			var textBox = _textBox.GetTarget();

			if (textBox != null)
			{
				//bug in base.SizeThatFits(size) where we get stuck and size is never return for value NaN
				if (nfloat.IsNaN(size.Width))
				{
					size = new CGSize(nfloat.PositiveInfinity, nfloat.PositiveInfinity);
				}

				//at this point size returned represent all the space available
				//to have the same behavior of Windows, we need to call UIView.SizeThatFits() to return a size that best fits
				var expectedSize = base.SizeThatFits(size);

				//Disable the scroll if you are given enough space. Else framework will use the scrollview to move text up
				ScrollEnabled = expectedSize.Height >= size.Height;

				var canTakeAllSpace = expectedSize.Height < size.Height && !nfloat.IsInfinity(size.Height) && size.Height != textBox.MaxHeight;
				// if textBox.Height is set, size.Height will be the same
				var shouldTakeAllSpace = !double.IsNaN(textBox.Height) || textBox.VerticalAlignment == VerticalAlignment.Stretch;
				if (canTakeAllSpace && shouldTakeAllSpace)
				{
					expectedSize.Height = size.Height;//Take all the space given
				}

				canTakeAllSpace = expectedSize.Width < size.Width && !nfloat.IsInfinity(size.Width) && size.Width != textBox.MaxWidth;
				// if textBox.Width is set, size.Width will be the same
				shouldTakeAllSpace = !double.IsNaN(textBox.Width) || textBox.HorizontalAlignment == HorizontalAlignment.Stretch;
				if (canTakeAllSpace && shouldTakeAllSpace)
				{
					expectedSize.Width = size.Width;//Take all the space given
				}

				var result = IFrameworkElementHelper.SizeThatFits(this, expectedSize);//Adjust for NaN and MaxHeight..

				return result;
			}
			else
			{
				return CGSize.Empty;
			}
		}
#endif

		public void UpdateFont()
		{
			var textBox = _textBox.GetTarget();

			if (textBox != null)
			{
#if __IOS__
				var newFont = UIFontHelper.TryGetFont((nfloat)textBox.FontSize, textBox.FontWeight, textBox.FontStyle, textBox.FontFamily);
#elif __MACOS__
				var newFont = NSFontHelper.TryGetFont((nfloat)textBox.FontSize, textBox.FontWeight, textBox.FontStyle, textBox.FontFamily);
#endif
				if (newFont != null)
				{
					base.Font = newFont;
					this.InvalidateMeasure();
				}
			}
		}

		public Brush Foreground
		{
			get { return (Brush)GetValue(ForegroundProperty); }
			set { SetValue(ForegroundProperty, value); }
		}

		public static readonly DependencyProperty ForegroundProperty =
			DependencyProperty.Register(
				"Foreground",
				typeof(Brush),
				typeof(MultilineTextBoxView),
				new FrameworkPropertyMetadata(
					defaultValue: SolidColorBrushHelper.Black,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((MultilineTextBoxView)s).OnForegroundChanged((Brush)e.OldValue, (Brush)e.NewValue)
				)
			);

		public void OnForegroundChanged(Brush oldValue, Brush newValue)
		{
			var textBox = _textBox.GetTarget();

			if (textBox != null)
			{
				var scb = newValue as SolidColorBrush;

				if (scb != null)
				{
					this.TextColor = scb.Color;

#if __IOS__
					this.TintColor = scb.Color;
#endif

				}
			}
		}

#if __IOS__
		public void UpdateTextAlignment()
		{
			var textBox = _textBox.GetTarget();

			if (textBox != null)
			{
				TextAlignment = textBox.TextAlignment.ToNativeTextAlignment();
			}
		}
#endif

#if __IOS__
		public override UITextRange SelectedTextRange
		{
			get
			{
				return base.SelectedTextRange;
			}
			set
			{
				if (base.SelectedTextRange != value)
				{
					base.SelectedTextRange = value;
					_textBox.GetTarget()?.OnSelectionChanged();
				}
			}
		}
#endif


		public void RefreshFont()
		{
			UpdateFont();
		}
	}
}
