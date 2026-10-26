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

namespace SymBank.Banking {
	/// <summary>
	/// Interaction logic for AddAccountView.xaml
	/// </summary>
	public partial class AddAccountView : BaseView {
		public AddAccountView() {
			InitializeComponent();
			Region = ShellRegions.MainRegion;
			Header = "New Account";
		}

		private void BaseView_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
