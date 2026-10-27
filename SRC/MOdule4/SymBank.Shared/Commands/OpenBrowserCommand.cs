using System;
using System.Windows.Input;

namespace SymBank.Shared.Commands {
	public class OpenBrowserCommand : ICommand {
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) {
			return parameter != null;
		}

		public void Execute(object parameter) {
			WebBrowserView view = new WebBrowserView();
			view.Open(parameter.ToString());
			view.Show();
		}
	}
}
