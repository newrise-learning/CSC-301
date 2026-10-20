using System;
using System.IO;

namespace Symbion.Loggers {
	public class FileLogger : BaseLogger {
		private string _filename;

		public override string Source {
			get {
				return base.Source;
			}
			set {
				base.Source = value;
				_filename = Path.ChangeExtension(value, ".log");
			}
		}

		public override void Write(string message, LogType logType) {
			string text = $"\"{DateTime.Now}\",\"{logType}\",\"{message}\"\r\n";
			File.AppendAllText(_filename, text);
		}
	}
}
