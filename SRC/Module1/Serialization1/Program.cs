using Symbion;

namespace Serialization1 {
	class Program {
		static void Main(string[] args) {
			ModuleItem item = new ModuleItem();
			ModuleList list = new ModuleList();
			item.Name = "SymBank.Banking.BankingModule";
			item.Path = "SymBank.Banking.Dll";
			item.Roles.Add("Administrators");
			item.Roles.Add("Banking");
			item.Roles.Add("Everyone");
			list.Items.Add(item);
			list.Save("Modules.xml");
		}
	}
}
