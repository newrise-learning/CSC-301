using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymBank.Shared {
	/// <summary>
	/// Interaction logic for WebBrowserView.xaml
	/// </summary>
	public partial class WebBrowserView : BaseView {
		public WebBrowserView() {
			InitializeComponent();
			Region = ShellRegions.MainRegion;
			Header = "Web Browser";

		}
		public void Open(string path) {
			try { Uri location = new Uri(path, UriKind.Absolute); webBrowser.Navigate(location); }
			catch (Exception ex) { Shell.Failure("Cannot open site. " + ex.Message); }
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e) { webBrowser.Refresh(); }
		private void btnPrevious_Click(object sender, RoutedEventArgs e) {
			if (webBrowser.CanGoBack) webBrowser.GoBack();
		}
		private void btnNext_Click(object sender, RoutedEventArgs e) {
			if (webBrowser.CanGoForward) webBrowser.GoForward();
		}
		private void btnOpen_Click(object sender, RoutedEventArgs e) { Open(txtLocation.Text); }
		private void btnClose_Click(object sender, RoutedEventArgs e) { Close(); }
	}
}
