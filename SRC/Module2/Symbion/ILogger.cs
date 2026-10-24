namespace Symbion {
	public interface ILogger : IService {
		string Source { get; set; }
		void Write(string message, LogType logType = LogType.Information);
		void Warning(string message);
		void Message(string message);
		void Failure(string message);
	}
}
