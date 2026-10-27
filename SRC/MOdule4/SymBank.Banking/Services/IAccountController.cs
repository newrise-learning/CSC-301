using SymBank.Data;
using Symbion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SymBank.Banking.Services {
	public interface IAccountController : IService {
		void Add(Account item);
		Account GetAccount(int code);
		List<Account> GetAccountList();
		List<Account> GetAccountsForName(string name);
		Task<List<Account>> GetAccountsForNameAsync(string name);
	}
}
