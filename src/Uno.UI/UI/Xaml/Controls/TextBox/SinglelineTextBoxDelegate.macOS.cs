using Foundation;
using Uno.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppKit;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace Windows.UI.Xaml.Controls
{
	public class SinglelineTextBoxDelegate : NSTextFieldDelegate
	{
		private WeakReference<TextBox> _textBox;

		public SinglelineTextBoxDelegate(WeakReference<TextBox> textbox)
		{
			_textBox = textbox;
		}

		public bool IsKeyboardHiddenOnEnter { get; set; }

		public override bool TextShouldBeginEditing(NSControl control, NSText fieldEditor)
		{
			return !_textBox.GetTarget()?.IsReadOnly ?? false;
		}

		public override void EditingBegan(NSNotification notification)
		{
			_textBox.GetTarget()?.Focus(FocusState.Pointer);
		}
	}
}
