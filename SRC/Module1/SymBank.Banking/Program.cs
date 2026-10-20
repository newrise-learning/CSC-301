using SymBank.Banking.Services;
using Symbion;
using System;
using System.Security.Principal;

namespace SymBank.Banking {
	class Program {
		static void Main(string[] args) {
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			new PrincipalAuthorization().Add<IAuthorization>();
			LoggerFactory.CreateInstance().Add();
			ModuleLoader.Load("Modules.xml");
			ModuleLoader.Init();
			ModuleLoader.Exit();
			IAccountController service1 = ServiceRepository.Get<IAccountController>();
			ITransactionController service2 = ServiceRepository.Get<ITransactionController>();
			if (service1 != null) Console.WriteLine("service1 located");
			if (service2 != null) Console.WriteLine("service2 located");

		}
	}
}
