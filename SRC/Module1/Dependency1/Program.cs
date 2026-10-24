using Symbion;
using System;
using System.Security.Principal;

namespace Dependency1 {
	class Program {
		static void Main(string[] args) {
			//ServiceRepository.Add(typeof(ILogger), LoggerFactory.CreateInstance());
			//ServiceRepository.Add(LoggerFactory.CreateInstance());
			LoggerFactory.CreateInstance().Add();

			//ILogger logger = (ILogger)ServiceRepository.Get(typeof(ILogger));
			ILogger logger = ServiceRepository.Get<ILogger>();
			if (logger != null) logger.Write("Logger service located!");

			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			new PrincipalAuthorization().Add<IAuthorization>();
			var auth = ServiceRepository.Get<IAuthorization>();
			Console.WriteLine(auth.UserName);
			Console.WriteLine(auth.IsInRole("Everyone"));
			Console.WriteLine(auth.IsInRole("Administrators"));
			Console.WriteLine(auth.IsInRole("Banking"));
		}
	}
}
