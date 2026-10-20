using Symbion;
using System;

namespace Encapsulation1 {
	class Program {
		static void Main(string[] args) {
			//	BaseLogger logger = new DebugLogger();
			//	ILogger logger = (ILogger)Activator.CreateInstance("Symbion", "Symbion.DebugLogger").Unwrap();
			ILogger logger = LoggerFactory.CreateInstance();
			Console.WriteLine(logger.Source);
			logger.Write("This is a 1st message.", LogType.Information);
			logger.Write("This is 2nd message.", LogType.Warning);
			logger.Write("This is 3rd message.", LogType.Error);
			logger.Write("This is 4th message.");
			logger.Message("Operation completed successfully.");
			logger.Warning("Operation may not have succeeded.");
			logger.Error("Operation has failed.");
		}
	}
}
