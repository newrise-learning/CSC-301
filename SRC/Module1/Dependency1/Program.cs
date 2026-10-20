using Symbion;
using System;
using System.Security.Principal;

namespace Dependency1 {
	class Program {
		static void Main(string[] args) {
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			new PrincipalAuthorization().Add<IAuthorization>();
			LoggerFactory.CreateInstance().Add();
			ILogger logger = ServiceRepository.Get<ILogger>();
			if (logger != null) logger.Write("Logger service located.");
			var auth = ServiceRepository.Get<IAuthorization>();
			Console.WriteLine(auth.UserName);
			Console.WriteLine(auth.IsInRole("Everyone"));
			Console.WriteLine(auth.IsInRole("Adminstrators"));
			Console.WriteLine(auth.IsInRole("Banking"));

		}
	}
}
