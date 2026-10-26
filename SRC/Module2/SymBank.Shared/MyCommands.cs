using SymBank.Shared.Commands;
using Symbion;
using System.Diagnostics;
using System.Windows.Input;

namespace SymBank.Shared.Commands {
	public static class MyCommands {
		public static readonly OpenBrowserCommand OpenBrowser =
			new OpenBrowserCommand();

		public static readonly ICommand Open = new
			DelegateCommand(p => p != null, p => Process.Start(p.ToString()));
	}
}
