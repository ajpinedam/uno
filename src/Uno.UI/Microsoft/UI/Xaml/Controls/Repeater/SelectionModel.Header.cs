using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class SelectionModel
    {
		private SelectionNode m_rootNode = null;
		private bool m_singleSelect = false;

		IList<IndexPath> m_selectedIndicesCached = null;
		IList<object> m_selectedItemsCached = null;

		internal event PropertyChangedEventHandler PropertyChanged;

		// Cached Event args to avoid creation cost every time
		private SelectionModelChildrenRequestedEventArgs m_childrenRequestedEventArgs = new SelectionModelChildrenRequestedEventArgs();
		private SelectionModelSelectionChangedEventArgs m_selectionChangedEventArgs = new SelectionModelSelectionChangedEventArgs();

		// use just one instance of a leaf node to avoid creating a bunch of these.
		private SelectionNode m_leafNode;
	}
}
