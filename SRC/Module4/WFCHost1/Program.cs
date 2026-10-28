using SymBank.Services;
using System;
using System.ServiceModel;

namespace WFCHost1 {
	class Program {
		static void Main(string[] args) {
			ServiceHost host = new ServiceHost(typeof(BankingServices));
			host.Open();
			host.AddServiceEndpoint(
				typeof(IAccountService),
				new BasicHttpBinding(),
				"http://localhost/8080/symbank/services/account"
				);
			host.AddServiceEndpoint(
				typeof(ITransactionService),
				new BasicHttpBinding(),
				"http://localhost/8080/symbank/services/transaction"
				);
			host.AddServiceEndpoint(
				typeof(IAccountService),
				new NetTcpBinding(),
				"tcp://localhost/8081/symbank/services/account"
				);
			host.AddServiceEndpoint(
				typeof(ITransactionService),
				new NetTcpBinding(),
				"tcp://localhost/8081/symbank/services/transaction"
				);
			foreach (var endpoint in host.Description.Endpoints) {
				Console.WriteLine(endpoint.Address);
				Console.WriteLine(endpoint.Binding);
				Console.WriteLine(endpoint.Contract.ContractType);
			}
			while (true) {
				Console.WriteLine("Host started. Press F12 to terminate.");
				var input = Console.ReadKey(true);
				if (input.Key == ConsoleKey.F12) break;
			}
			host.Close();
		}
	}
}
