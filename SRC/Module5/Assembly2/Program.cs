using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly2 {
	class Program {
		static void Main(string[] args) {
			Assembly a6 = Assembly.Load("Symbion");
		//	Assembly a7 = Assembly.LoadFile(@"C:\Symbolicon\CSC-301\SRC\Module5\Symbion\bin\Release\Symbion.dll");
		//	Assembly a8 = Assembly.LoadFrom(@"C:\Symbolicon\CSC-301\SRC\Module5\Symbion\bin\Release\Symbion.dll");
			Assembly a9 = Assembly.LoadFrom("Symbion.dll");
			Console.WriteLine(a6.FullName);
		//	Console.WriteLine(a7.FullName);
		//	Console.WriteLine(a8.FullName);
			Console.WriteLine(a9.FullName);

			string id =
				"PresentationCore, Version = 4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";
			Assembly a10 = Assembly.Load(id);
			Console.WriteLine(a10.FullName);

			AssemblyName assemblyName = a10.GetName();
			Console.WriteLine(assemblyName.Name);
			Console.WriteLine(assemblyName.Version);
			Console.WriteLine(assemblyName.CultureInfo);
			byte[] token = assemblyName.GetPublicKeyToken();
			Console.WriteLine(BitConverter.ToString(token));
			Console.WriteLine(BitConverter.ToString(token).Replace("-", "").ToLower());

		//	DebugHelper.ShowTypes(a6);

			Type type = a6.GetType("Symbion.DebugLogger");
			object obj = Activator.CreateInstance(type);
			Console.WriteLine(obj is DebugLogger);
		}

	}
}
