using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Symbion {
	public class BaseLogger : BaseService, ILogger {
		private string _source;
		public virtual string Source {
			get { return _source; }
			set {
				Debug.Assert(value != null,
				"Source property cannot be null.");
				_source = value;
			}
		}
		public BaseLogger() {
			Assembly assembly = Assembly.GetEntryAssembly();
			Source = Path.GetFileNameWithoutExtension(assembly.Location);
		}

		public virtual void Write(string message, LogType logType = LogType.Information) {
			Console.WriteLine($"\"{Source}\", \"{logType}\", \"{message}\"");
		}

		public void Message(string message) { Write(message, LogType.Information); }
		public void Warning(string message) { Write(message, LogType.Warning); }
		public void Failure(string message) { Write(message, LogType.Error); }
	}
}
