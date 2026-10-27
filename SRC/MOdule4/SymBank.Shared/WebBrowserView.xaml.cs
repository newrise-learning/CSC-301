using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SymBank.Shared {
	public partial class WebBrowserView : BaseView {
		public WebBrowserView() {
			InitializeComponent();
			Region = ShellRegions.MainRegion;
			Header = "Web Browser";
		}

		public void Open(string path) {
			try {
				Uri location = new Uri(path, UriKind.Absolute);
				webBrowser.Navigate(location);
			} catch (Exception ex) {
				Shell.Failure("Cannot open site. " + ex.Message);
			}
		}

		private void BaseView_Loaded(object sender, RoutedEventArgs e) {
			txtLocation.Focus();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e) {
			webBrowser.Refresh();
		}

		private void btnPrevious_Click(object sender, RoutedEventArgs e) {
			if (webBrowser.CanGoBack) webBrowser.GoBack();
		}
		private void btnNext_Click(object sender, RoutedEventArgs e) {
			if (webBrowser.CanGoForward) webBrowser.GoForward();
		}
		private void btnOpen_Click(object sender, RoutedEventArgs e) {
			Open(txtLocation.Text);
		}

		private void btnClose_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
