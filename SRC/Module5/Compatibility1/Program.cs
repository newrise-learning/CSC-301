using Symbion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compatibility1 {
	class Program {
		static object Copy(object obj) {
			if (obj is ICloneable) {
				ICloneable item = (ICloneable)obj;
				return item.Clone();
			}
			return null;
		}

		static object Copy2(object obj) {
			ICloneable item = obj as ICloneable;
			return obj != null ? item.Clone() : null;
		}


		static void Main(string[] args) {

			var obj = new DebugLogger();
			LogTo1(obj);
			LogTo2(obj);
			LogTo3(obj);
			var obj1 = Copy("Hello!");
			var obj2 = Copy(new ArrayList());
			var obj3 = Copy(new int[4]);
			var obj4 = Copy(DateTime.Now);
			if (obj4 == null)
				Console.WriteLine("No copy.");
		}
		static void LogTo1(DebugLogger logger) {
			logger.Message("Hello!");
			logger.Message("Goodbye!");
		}
		static void LogTo2(BaseLogger logger) {
			logger.Message("Hello!");
			logger.Message("Goodbye!");
		}
		static void LogTo3(ILogger logger) {
			logger.Message("Hello!");
			logger.Message("Goodbye!");
		}


	}
}
