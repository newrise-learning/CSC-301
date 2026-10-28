using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Symbion {
	public class TabControlRegionAdapter : IRegionAdapter {
		private TabControl _region;
		private Dictionary<IView, TabItem> _views;
		public TabControlRegionAdapter(TabControl region) {
			_views = new Dictionary<IView, TabItem>();
			_region = region;
		}
		public void Add(IView view) {
			var host = new TabItem();
			_views.Add(view, host);
			host.Header = view.Header;
			host.Content = view;
			_region.Items.Add(host);
			_region.SelectedItem = host;
			if (!_region.IsVisible) _region.Visibility = Visibility.Visible;
		}
		public void Remove(IView view) {
			var host = _views[view];
			_region.Items.Remove(host);
			_views.Remove(view);
			if (_views.Count == 0) _region.Visibility = Visibility.Collapsed;
		}
	}
}
