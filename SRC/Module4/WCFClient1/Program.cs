using SymBank.Services;
using System;

namespace WCFClient1 {
	class Program {
		static void Main(string[] args) {
			var obj = new BankingServices();
			IAccountService service1 = obj;
			ITransactionService service2 = obj;
			var list = service1.GetAccountList();
			foreach (var item in list)
				Console.WriteLine(
					"{0},{1},{2}",
					item.Code, item.Name, item.Balance);
			int ref1 = service2.Debit(200, 200m);
			int ref2 = service2.Credit(300, 500m);
			int ref3 = service2.Transfer(200, 300, 500m);
			Console.WriteLine(ref1);
			Console.WriteLine(ref2);
			Console.WriteLine(ref3);
		}
	}
}
