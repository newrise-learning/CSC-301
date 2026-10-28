using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1 {
	class Program {
		static void Main(string[] args) {
			Type t1 = "This is a stting".GetType();
			Type t2 = typeof(DebugHelper);
			t1.ShowTypeInfo();
			t2.ShowTypeInfo();

			var item = new LoanAccount(
				100, "ABC Trading", 50000m, 0.06m, 5);

			Console.WriteLine(item.ToString());

			PropertyInfo p1 = t1.GetProperty("Balance");
			if (p1 == null) {
				Console.WriteLine("No balance property!");
				return;
			}
			if (p1.PropertyType != typeof(decimal)) {
				Console.WriteLine("Wrong property type.");
				return;
			}

			decimal balance = (decimal)p1.GetValue(item, null);
			balance -= 10000m;
			p1.SetValue(item, balance, null);
			Console.WriteLine(item.Balance);


			Type[] parameterTypes = { };
			MethodInfo m1 = t1.GetMethod("ToString", parameterTypes);
			if (m1 == null) {
				Console.WriteLine("Method not found.");
				return;
			}
			if (m1.ReturnType != typeof(string)) {
				Console.WriteLine("Not string method.");
				return;
			}
			Type[] parameters = { };
			string result = (string)m1.Invoke(item, parameters);
			Console.WriteLine(result);
		}
	}
}
