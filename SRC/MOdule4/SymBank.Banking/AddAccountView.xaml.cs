using SymBank.Banking.Services;
using SymBank.Data;
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
		private IAccountController _accountController;
		private Account _account; 
		public AddAccountView() {
			InitializeComponent();
			DataContext = _account = new Account();
			_accountController = ServiceRepository.Get<IAccountController>();
			Region = ShellRegions.MainRegion;
			Header = "New Account";
		}

		private void BaseView_Loaded(object sender, RoutedEventArgs e) {

        }

		private void btnAdd_Click(object sender, RoutedEventArgs e) {
			try {
				_account.Name.NotNullOrEmpty("Name");
				_account.Name.Length.InRange("Length of name", 1, 30);
				_account.ZipCode.Matches("Zip code", @"^\d{5}$");
				_account.Balance.InRange("Balance", 100m, Decimal.MaxValue);
				_accountController.Add(_account);
				Shell.Success("Account added successfully!");
				//	Close();
				_account = new Account();
				DataContext = _account;
			}
			catch (Exception ex) {
				Shell.Failure(
					"Cannot add account. " + ex.Message);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
