using SymBank.Banking.Controllers;
using SymBank.Banking.Services;
using Symbion;
using System.Windows.Navigation;

namespace SymBank.Banking {
	public class BankingModule : BaseModule {
		public override void Init() {
			MenuBarBuilder mb = Shell.MenuBars["main"];
			ToolBarBuilder tb = Shell.ToolBars["main"];
			var menu = mb.GetMenu("menu_accounts");
			if (menu == null) {
				menu = mb.Create("menu_accounts", "_Accounts");
				mb.AddMenu(menu);
			}
			var addAccountCommand = new DelegateCommand(p => new AddAccountView().Show());
			var addAccountIcon = "/SymBank.Banking;component/Images/user_add.png";
			var addAccountMenuItem = mb.Create(
				"menu_addaccount",
				"_Add new Account",
				addAccountCommand,
				null, addAccountIcon);
			var addAccountButton = tb.CreateButton(
				"button_addaccount", "Add bew account",
				addAccountCommand, addAccountIcon);
			mb.AddItem(menu, addAccountMenuItem);
			tb.AddSeparator();
			tb.AddItem(addAccountButton);

			var searchAccountsMenuItem = mb.Create(
				"menuitem_serchaccounts",
				"_Search for Accounts",
				new DelegateCommand(
					p => new SearchAccountsView().Show()));
			mb.AddItem(menu, searchAccountsMenuItem);

			base.Init();
			var obj = new BankingController();
			obj.Add<IAccountController>();
			obj.Add<ITransactionController>();
		}
	}
}
