using Symbion;
using System;
using System.Security.Principal;

namespace Module1 {
	class Program {
		static void Main() {
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			new PrincipalAuthorization().Add<IAuthorization>();
			LoggerFactory.CreateInstance().Add();
			ModuleLoader.Load("Modules.xml");
			ModuleLoader.Init();
			ModuleLoader.Exit();
		}
	}
}
