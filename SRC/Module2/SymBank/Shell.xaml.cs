
using SymBank.Shared;
using Symbion;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SymBank {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Shell : Window, IShell {

		private Dictionary<string, IRegionAdapter> _regions;

		public Dictionary<string, IRegionAdapter> Regions {
			get { return _regions; }
		}

		public object Status {
			set { lblStatus.Content = value; }
		}

		public Shell() {
			InitializeComponent();
			_regions = new Dictionary<string, IRegionAdapter>();
			_regions.Add(ShellRegions.SideRegion, new ListBoxRegionAdapter(sideRegion));
			_regions.Add(ShellRegions.MainRegion, new TabControlRegionAdapter(mainRegion));
			this.Add<IShell>();
		}


		public void Failure(string message) {
			MessageBox.Show(this, message, "Error",
				MessageBoxButton.OK, MessageBoxImage.Error);
		}

		public void Success(string message) {
			MessageBox.Show(this, message, "Information",
				MessageBoxButton.OK, MessageBoxImage.Information);
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
