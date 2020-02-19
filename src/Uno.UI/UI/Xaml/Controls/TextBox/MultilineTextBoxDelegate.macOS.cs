using System;
using AppKit;
using Foundation;
using Uno.Extensions;

namespace Windows.UI.Xaml.Controls
{
	public class MultilineTextBoxDelegate : NSTextViewDelegate
	{
		private readonly WeakReference<TextBox> _textBox;

		public MultilineTextBoxDelegate(WeakReference<TextBox> textbox)
		{
			_textBox = textbox;
		}

		public override void TextDidChange(NSNotification notification)
		{
			
		}

		public override void TextDidBeginEditing(NSNotification notification)
		{
			_textBox.GetTarget()?.Focus(FocusState.Pointer);
		}

		
		public override void TextDidEndEditing(NSNotification notification)
		{
			
		}

		public override bool ShouldChangeTextInRange(NSTextView textView, NSRange affectedCharRange, string replacementString)
		{
			return base.ShouldChangeTextInRange(textView, affectedCharRange, replacementString);
		}

		public override bool TextShouldEndEditing(NSText textObject)
		{
			return base.TextShouldEndEditing(textObject);
		}
		
		public override bool TextShouldBeginEditing(NSText textObject)
		{
			return base.TextShouldBeginEditing(textObject);
		}
	}
}
