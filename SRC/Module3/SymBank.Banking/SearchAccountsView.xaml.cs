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
	/// Interaction logic for SearchAccountsView.xaml
	/// </summary>
	public partial class SearchAccountsView : BaseView {
		private IAccountController _accountController;
		public SearchAccountsView() {
			InitializeComponent();
			_accountController = ServiceRepository.Get<IAccountController>();
			Region = ShellRegions.MainRegion;
			Header = "Account Search";
			SearchCommand = new AsyncDelegateCommand(
				StartSearch, SearchCompleted);
		}

		private List<Account> _tempResults;

		private void StartSearch(object paremter) {
			_tempResults = _accountController.GetAccountsForName(txtSearch.Text);
		}

		private void SearchCompleted(Exception ex) {
			if (ex != null) Shell.Failure(
			   "Error searching for accounts.\n" + ex.Message);
			else {
				Shell.Status = string.Format(
					"Search completed. {0} items found.",
					_tempResults.Count);
			}
		}

		private void BaseView_Loaded(object sender, RoutedEventArgs e) {

        }

		private async void btnSearch_Click(object sender, RoutedEventArgs e) {
			SearchCommand.Execute(null);
			btnSearch.IsEnabled = false;
			try {
				var result = await _accountController.GetAccountsForNameAsync(txtSearch.Text);
				lsbAccounts.ItemsSource = result;
			}
			catch (Exception ex) {
				Shell.Failure("Search accounts failed." + ex.Message);
			}
			finally {
				btnSearch.IsEnabled = true;
				txtSearch.Focus();
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
			Close();
		}

		public AsyncDelegateCommand SearchCommand { get; private set; }

	}
}
