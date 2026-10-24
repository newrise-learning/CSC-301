using Symbion;

class Program {
	static void Main() {
		ModuleList list = new ModuleList();
		ModuleItem item = new ModuleItem();
		item.Name = "SymBank.Banking.BankingModule";
		item.Path = "SymBank.Banking.dll";
		item.Roles.Add("Administrators");
		item.Roles.Add("Banking");
		list.Items.Add(item);
		list.Save("Modules.xml");
	}
}
