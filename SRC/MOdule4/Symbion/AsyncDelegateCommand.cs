using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Symbion {
	public class AsyncDelegateCommand : ICommand {
		private Predicate<object> _canExecute;
		private Action<object> _execute;
		private Action<Exception> _completed;
		private bool _running;

		public bool Running { get { return _running; } }

		public AsyncDelegateCommand(Action<object> execute, Action<Exception> completed) {
			_execute = execute; _completed = completed;
		}

		public AsyncDelegateCommand(Predicate<object> canExecute, Action<object> execute, Action<Exception> completed) {
			_canExecute = canExecute;
			_execute = execute;
			_completed = completed;
		}

		public event EventHandler CanExecuteChanged;

		public void NotifyCanExecuteChanged() {
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
			NotifyCanExecuteChanged();

		}

		private Task ExecuteAsync(object parameter) {
			var task = new Task(() => _execute(parameter));
			task.Start(); return task;
		}

		public bool CanExecute(object parameter) {
			if (_running) return false;
			if (_canExecute == null) return true;
			return _canExecute(parameter);
		}

		public async void Execute(object parameter) {
			if (_running) return; _running = true;
			NotifyCanExecuteChanged();
			try {
				if (_execute != null) await ExecuteAsync(parameter);
				if (_completed != null) _completed(null);
			} catch (Exception ex) {
				if (_completed != null)
					_completed(ex);
			}
			_running = false;
		}

	}
}
