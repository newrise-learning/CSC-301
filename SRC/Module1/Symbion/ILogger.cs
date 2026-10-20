namespace Symbion {
	public interface ILogger : IService {
		string Source { get; set; }
		void Write(string message, LogType logType = LogType.Information);
		void Message(string message);
		void Warning(string message);
		void Error(string message);
		void Failure(string message);
	}
}
