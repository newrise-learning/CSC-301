using Symbion;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SymBank.Shared {
	public class ListBoxRegionAdapter : IRegionAdapter {
		private ListBox _region;

		private Dictionary<IView, Expander> _views;

		public ListBoxRegionAdapter(ListBox region) {
			_views = new Dictionary<IView, Expander>();
			_region = region;
		}

		public void Add(IView view) {
			var host = new Expander();
			_views.Add(view, host);
			host.Header = view.Header;
			host.Content = view;
			_region.Items.Add(host);
			_region.SelectedItem = host;
			if (!_region.IsVisible)
				_region.Visibility = Visibility.Visible;
		}

		public void Remove(IView view) {
			var host = _views[view];
			_region.Items.Remove(host);
			_views.Remove(view);
			if (_views.Count == 0)
				_region.Visibility = Visibility.Collapsed;
		}
	}
}
