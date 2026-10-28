using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly1 {
	class Program {
		static void Main(string[] args) {
			Assembly a1 = Assembly.GetEntryAssembly();
			Assembly a2 = Assembly.GetExecutingAssembly();
			Assembly a3 = Assembly.GetCallingAssembly();
			Assembly a4 = Assembly.GetAssembly(typeof(Program));
			Assembly a5 = typeof(DebugHelper).Assembly;
			Console.WriteLine(a1.FullName);
			Console.WriteLine(a2.FullName);
			Console.WriteLine(a3.FullName);
			Console.WriteLine(a4.FullName);
			Console.WriteLine(a5.FullName);
		}

	}
}

