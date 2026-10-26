using Symbion;
using System;

namespace Activation1 {
	class Program {
		static void Main() {
			ILogger logger = LoggerFactory.CreateInstance();
			Console.WriteLine(logger.Source);
			logger.Write("This is the 1st message.", LogType.Information);
			logger.Write("This is the 2nd message.", LogType.Warning);
			logger.Write("This is the 3rd message.", LogType.Error);
			logger.Write("This is the 4th message.");

			logger.Message("Operation completed successfully.");
			logger.Warning("Operation may not have succeeded.");
			logger.Failure("Operation has failed.");
		}
	}
}
