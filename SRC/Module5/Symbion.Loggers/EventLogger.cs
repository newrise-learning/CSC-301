using System.Diagnostics;

namespace Symbion.Loggers {
	internal class EventLogger : BaseLogger {
		public override void Write(string message,
			LogType logType = LogType.Information) {
			EventLogEntryType entryType = EventLogEntryType.Information;
			if (logType == LogType.Error) entryType = EventLogEntryType.Error;
			else if (logType == LogType.Warning) entryType = EventLogEntryType.Warning;
			EventLog.WriteEntry(Source, message, entryType);
		}
	}
}
