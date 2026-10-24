using System;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace SymBank.Services {
//	[System.ServiceModel.ServiceContract]
	public class BankingServices {
		public static string UserName {
			get {
				return Thread.CurrentPrincipal.Identity.Name;
			}
		}	
		public void Add(Account item) {
			try {
				var dc = new SymBankDataContext();
				dc.AccountAdd(item.Code,
					item.Type, item.Name,
					item.ZipCode, UserName,
					DateTime.UtcNow, item.Balance);
			}
			catch (Exception ex) {
				throw new FaultException(
					"Add account failed. " +
					ex.Message);
			}
		}

		public Account GetAccount(int code) {
			try {
				var dc = new SymBankDataContext();
				return dc.Accounts.Single(a => a.Code == code);
			}
			catch (Exception ex) {
				throw new FaultException(
					"Get account failed. " +
					ex.Message);
			}
		}

		public List<Account> GetAccountList() {
			try {
				var dc = new SymBankDataContext();
				return dc.Accounts.ToList();
			}
			catch (Exception ex) {
				throw new FaultException(
					"Get account list failed. "
					+ ex.Message);
			}
		}

		public List<Account> GetAccountsForName(string name) {
			try {
				name = name.ToLower();
				var dc = new SymBankDataContext();
				var query = from a in dc.Accounts
					where a.Name.ToLower().Contains(name)
					orderby a.Name select a;
				return query.ToList();
			}
			catch (Exception ex) {
				throw new FaultException(
					"Search accounts list failed. " +
					ex.Message);
			}
		}

		public int Debit(int source, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountDebit(source, amount,
					UserName, DateTime.UtcNow,
					ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
					"Debit account failed. " +
					ex.Message);
			}
		}

		public int Credit(int source, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountCredit(source, amount,
					UserName, DateTime.UtcNow,
					ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
					"Credit account failed. " +
					ex.Message);
			}
		}

		public int Transfer(int source, int target, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountTransfer(source, target,
					amount, UserName, DateTime.UtcNow,
					ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
					"Account transfer failed. " +
					ex.Message);
			}
		}
	}
}