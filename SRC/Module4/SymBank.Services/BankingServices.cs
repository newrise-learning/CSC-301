using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace SymBank.Services {
	[ServiceContract]
	public class BankingServices: IAccountService, ITransactionService {
		public static string UserName {
			get { return Thread.CurrentPrincipal.Identity.Name; }
		}
		public void Add(Account item) {
			try { }
			catch (Exception ex) {
				throw new FaultException("Add account failed. " + ex.Message);
			}
		}
		public Account GetAccount(int code) {
			try { return null; }
			catch (Exception ex) {
				throw new FaultException("Get account failed. " + ex.Message);
			}
		}
		public List<Account> GetAccountList() {
			try {
				var dc = new SymBankDataContext();
				return dc.Accounts.ToList();
			}
			catch (Exception ex) {
				throw new FaultException("Get account list failed. " + ex.Message);
			}
		}
		public List<Account> GetAccountsForName(string name) {
			try { return null; }
			catch (Exception ex) {
				throw new FaultException(
				"Search accounts list failed. " + ex.Message);
			}
		}
		public int Debit(int source, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountDebit(source, amount, UserName, DateTime.Now, ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
				"Debit account failed. " + ex.Message);
			}
		}
		public int Credit(int source, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountCredit(source, amount, UserName, DateTime.Now, ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
				"Credit account failed. " + ex.Message);
			}
		}
		 public int Transfer(int source, int target, decimal amount) {
			try {
				int? transactionCode = null;
				var dc = new SymBankDataContext();
				dc.AccountTransfer(source, target, amount, UserName, DateTime.Now, ref transactionCode);
				return (int)transactionCode;
			}
			catch (Exception ex) {
				throw new FaultException(
				"Account transfer failed. " + ex.Message);
			}
		}
	}
}
