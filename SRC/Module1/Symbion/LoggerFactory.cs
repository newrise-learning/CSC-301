using System;
using System.Configuration;

namespace Symbion {
	public static class LoggerFactory {
		public const string DefaultLogger = "Symbion.DebugLogger;Symbion";
		private static readonly string _typeName;
		private static readonly string _assemblyName;
		static LoggerFactory() {
			string key = typeof(ILogger).FullName;
			string value = ConfigurationManager.AppSettings[key];
			if (value == null) value = DefaultLogger;
			string[] fields = value.Split(';');
			_typeName = fields[0].Trim();
			_assemblyName = fields[1].Trim();
		}
		public static ILogger CreateInstance() {
			return (ILogger)Activator.CreateInstance(
				_assemblyName, _typeName).Unwrap();
		}
	}
}
