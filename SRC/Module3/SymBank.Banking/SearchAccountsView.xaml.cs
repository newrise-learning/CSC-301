using SymBank.Banking.Services;
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
	/// Interaction logic for SearchAccountsView.xaml
	/// </summary>
	public partial class SearchAccountsView : BaseView {
		private IAccountController _accountController;
		public SearchAccountsView() {
			InitializeComponent();
			_accountController = ServiceRepository.Get<IAccountController>();
			Region = ShellRegions.MainRegion;
			Header = "Account Search";
		}


		private void BaseView_Loaded(object sender, RoutedEventArgs e) {

        }

		private void btnSearch_Click(object sender, RoutedEventArgs e) {
			try {
				lsbAccounts.ItemsSource =
					_accountController.GetAccountsForName(txtSearch.Text);
			}
			catch (Exception ex) {
				Shell.Failure("Search accounts failed." + ex.Message);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
