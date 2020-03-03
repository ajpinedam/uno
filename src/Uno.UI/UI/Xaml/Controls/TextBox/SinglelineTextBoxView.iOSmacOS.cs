using CoreGraphics;
using System;
using Uno.Extensions;
using Windows.UI.Xaml.Media;
using Uno.UI.Controls;
using Foundation;

#if __IOS__
using UIKit;
using _TextField = UIKit.UITextField
#elif __MACOS__
using AppKit;
using _TextField = AppKit.NSTextField;
#endif


namespace Windows.UI.Xaml.Controls
{
	public partial class SinglelineTextBoxView : _TextField, ITextBoxView, DependencyObject, IFontScalable
	{
		private SinglelineTextBoxDelegate _delegate;
		private readonly WeakReference<TextBox> _textBox;

		public SinglelineTextBoxView(TextBox textBox)
		{
			_textBox = new WeakReference<TextBox>(textBox);

			InitializeBinder();
			Initialize();
		}

		private void OnEditingChanged(object sender, EventArgs e)
		{
			OnTextChanged();
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
				return base.StringValue;
			}

			set
			{
				// The native control will ignore a value of null and retain an empty string. We coalesce the null to prevent a spurious empty string getting bounced back via two-way binding.
				value = value ?? string.Empty;
				if (base.StringValue != value)
				{
					base.StringValue = value;
					OnTextChanged();
				}
			}
		}
#endif

		private void OnTextChanged()
		{
			var textBox = _textBox?.GetTarget();
			if (textBox != null)
			{
				var text = textBox.ProcessTextInput(Text);
				SetTextNative(text);
			}
		}

		public void SetTextNative(string text) => Text = text;

		private void Initialize()
		{

#if __IOS__
			//Set native VerticalAlignment to top-aligned (default is center) to match Windows text placement
			base.VerticalAlignment = UIControlContentVerticalAlignment.Top;
#endif
			Delegate = _delegate = new SinglelineTextBoxDelegate(_textBox)
			{
				IsKeyboardHiddenOnEnter = true
			};

			RegisterLoadActions(
				() =>
				{
#if __IOS__

					this.EditingChanged += OnEditingChanged;
					this.EditingDidEnd += OnEditingChanged;
#endif
				},
				() =>
				{
#if __IOS__
					this.EditingChanged -= OnEditingChanged;
					this.EditingDidEnd -= OnEditingChanged;
#endif
				}
			);
		}

#if __IOS__
		public override CGSize SizeThatFits(CGSize size)
		{
			return IFrameworkElementHelper.SizeThatFits(this, base.SizeThatFits(size));
		}
#endif


#if __IOS__

		public override CGRect TextRect(CGRect forBounds)
		{
			return GetTextRect(forBounds);
		}

		public override CGRect PlaceholderRect(CGRect forBounds)
		{
			return GetTextRect(forBounds);
		}

		public override CGRect EditingRect(CGRect forBounds)
		{
			return GetTextRect(forBounds);
		}

		private CGRect GetTextRect(CGRect forBounds)
		{
			if (IsStoreInitialized)
			{
				// This test is present because most virtual methods are
				// called before the ctor has finished executing.

				return new CGRect(
					forBounds.X,
					forBounds.Y,
					forBounds.Width,
					forBounds.Height
				);
			}
			else
			{
				return CGRect.Empty;
			}
		}
#endif

		public void UpdateFont()
		{
			var textBox = _textBox.GetTarget();

			if (textBox != null)
			{
#if __IOS__
				var newFont = UIFontHelper.TryGetFont((float)textBox.FontSize, textBox.FontWeight, textBox.FontStyle, textBox.FontFamily);
#elif __MACOS__
				var newFont = NSFontHelper.TryGetFont((float)textBox.FontSize, textBox.FontWeight, textBox.FontStyle, textBox.FontFamily);
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

		public bool HasMarkedText => throw new NotImplementedException();

		public nint ConversationIdentifier => throw new NotImplementedException();

		public NSRange MarkedRange => throw new NotImplementedException();

		public NSRange SelectedRange => throw new NotImplementedException();

		public NSString[] ValidAttributesForMarkedText => throw new NotImplementedException();

		public static readonly DependencyProperty ForegroundProperty =
			DependencyProperty.Register(
				"Foreground",
				typeof(Brush),
				typeof(SinglelineTextBoxView),
				new FrameworkPropertyMetadata(
					defaultValue: SolidColorBrushHelper.Black,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((SinglelineTextBoxView)s).OnForegroundChanged((Brush)e.OldValue, (Brush)e.NewValue)
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

		public void RefreshFont()
		{
			UpdateFont();
		}

#if __IOS__
		public override UITextRange SelectedTextRange
		{
			get
			{
				return base.SelectedTextRange;
			}
			set
			{
				var textBox = _textBox.GetTarget();

				if (textBox != null && base.SelectedTextRange != value)
				{
					base.SelectedTextRange = value;
					textBox.OnSelectionChanged();
				}
			}
		}
#endif

#if __MACOS__
		#region "Some Interface"
		public void InsertText(NSObject insertString)
		{
			throw new NotImplementedException();
		}

		public void SetMarkedText(NSObject @string, NSRange selRange)
		{
			throw new NotImplementedException();
		}

		public void UnmarkText()
		{
			throw new NotImplementedException();
		}

		public NSAttributedString GetAttributedSubstring(NSRange range)
		{
			throw new NotImplementedException();
		}

		public CGRect GetFirstRectForCharacterRange(NSRange range)
		{
			throw new NotImplementedException();
		}

		public nuint GetCharacterIndex(CGPoint point)
		{
			throw new NotImplementedException();
		}
		#endregion
#endif

	}
}
