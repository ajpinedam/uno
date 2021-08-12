using System;
using System.Collections.Generic;
using System.Text;

namespace Uno.UI.UI.Xaml.Controls
{
    public partial class ScrollViewerViewChangingEventArgs
    {
		public bool IsInertial { get; set; }

		public ScrollViewerView NextView { get; set; }

		public ScrollViewerView FinalView { get; set; }
	}
}
