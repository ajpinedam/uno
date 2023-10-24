#nullable enable
using System;
using System.Linq;
using SkiaSharp;

namespace Microsoft.UI.Composition;

public partial class CompositionViewBox
{
	public SKRect GetRect()
		=> new(Offset.X, Offset.Y, Offset.X + Size.X, Offset.Y + Size.Y);
}
