using Accessibility;
using SymBank.Banking.Services;
using SymBank.Data;
using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SymBank.Banking.Controllers {
	[Service(typeof(IAccountController))]
	[Service(typeof(ITransactionController))]
	// [Service(ServiceType = typeof(IAccountController))]
	// [Service(ServiceType = typeof(ITransactionController))]
	public class BankingController : IAccountController, ITransactionController {
		private IAuthorization _auth;
		public string UserName {
			get {
				if (_auth == null)
					_auth = ServiceRepository.Get<IAuthorization>();
				return _auth.UserName;
			}
		}
		public void Add(Account item) {
			var dc = new SymBankDataContext();
			dc.AccountAdd(item.Code, item.Type, item.Name, item.ZipCode, UserName, DateTime.Now, item.Balance);
		}

		public int Credit(int source, decimal amount) {
			int? transactionCode = null;
			var dc = new SymBankDataContext();
			dc.AccountCredit(source, amount, UserName, DateTime.Now, ref transactionCode);
			return (int)transactionCode;
		}

		public int Debit(int source, decimal amount) {
			int? transactionCode = null;
			var dc = new SymBankDataContext();
			dc.AccountDebit(source, amount, UserName, DateTime.Now, ref transactionCode);
			return (int)transactionCode;
		}

		public Account GetAccount(int code) {
			var dc = new SymBankDataContext();
			return dc.Accounts.Single(a => a.Code == code);
		//	return dc.Accounts.SingleOrDefault(a => a.Code == code);
		}

		public List<Account> GetAccountList() {
			var dc = new SymBankDataContext();
			return dc.Accounts.ToList();
		}

		public List<Account> GetAccountsForName(string name) {
			name = name.ToLower();
			var dc = new SymBankDataContext();
			var query = from account in dc.Accounts
						where account.Name.ToLower().Contains(name)
						orderby account.Name
						select account;
			Thread.Sleep(6000);
			return query.ToList();
		}

		public Task<List<Account>> GetAccountsForNameAsync(string name) {
			var task = new Task<List<Account>>(() => GetAccountsForName(name));
			task.Start(); return task;
		}

		public int Transfer(int source, int target, decimal amount) {
			int? transactionCode = null;
			var dc = new SymBankDataContext();
			dc.AccountTransfer(source, target, amount, UserName, DateTime.Now, ref transactionCode);
			return (int)transactionCode;
		}
	}
}
