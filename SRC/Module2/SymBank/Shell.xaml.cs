using SymBank.Shared;
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

namespace SymBank {
	public partial class Shell : Window, IShell {
		private Dictionary<string, IRegionAdapter> _regions;
		public Dictionary<string, IRegionAdapter> Regions {
			get { return _regions; }
		}

		public Shell() {
			InitializeComponent();
			_regions = new Dictionary<string, IRegionAdapter>();
			_regions.Add(ShellRegions.SideRegion, new ListBoxRegionAdapter(sideRegion));
			_regions.Add(ShellRegions.MainRegion, new TabControlRegionAdapter(mainRegion));
			this.Add<IShell>();
		}
		public object Status { set { lblStatus.Content = value; } }
		public void Success(string message) {
			MessageBox.Show(this, message, "Information",
			MessageBoxButton.OK, MessageBoxImage.Information);
		}
		public void Failure(string message) {
			MessageBox.Show(this, message, "Error",
			MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void Window_Loaded(object sender, RoutedEventArgs e) {
			ModuleLoader.Init();
		}
		private void mnuWebBrowser_Click(object sender, RoutedEventArgs e) {
			WebBrowserView view = new WebBrowserView();
			view.Open("http://www.google.com");
			view.Show();
		}
	}
}
