using System;
using System.Windows.Input;

namespace Symbion {
	public class DelegateCommand : ICommand {
		private Predicate<object> _canExecute;
		private Action<object> _execute;

		public DelegateCommand(Action<object> execute) {
			_canExecute = null;
			_execute = execute;
		}

		public DelegateCommand(
			Predicate<object> canExecute,
			Action<object> execute) {
			_canExecute = canExecute;
			_execute = execute;
		}


		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) {
			if (_canExecute == null) return true;
			return _canExecute(parameter);
		}

		public void Execute(object parameter) {
			if (_execute != null)
				_execute(parameter);
		}

		public void NotifyCanExecuteChanged() {
			if (CanExecuteChanged != null)
				CanExecuteChanged.Invoke(this,
					EventArgs.Empty);
		}
	}
}
